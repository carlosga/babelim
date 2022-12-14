// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Core;
using BabelIm.Net.Xmpp.InstantMessaging.ServiceDiscovery;
using BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat;
using BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat.User;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client.Presence;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;

namespace BabelIm.Net.Xmpp.InstantMessaging.MultiUserChat
{
    /// <summary>
    /// Represents a conversation in a conference room
    /// </summary>
    public sealed class XmppChatRoom
        : XmppServiceDiscoveryObject
    {
        #region · Fields ·

        private ObservableCollection<XmppChatRoomUser>  users;
        private XmppService                             conferenceService;
        private AutoResetEvent                          seekEnterChatRoomEvent;
        private AutoResetEvent                          createChatRoomEvent;

        #region · Subscriptions ·

        private IDisposable messageReceivedSubscription;
        private IDisposable presenceSubscription;

        #endregion

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <value>The users.</value>
        public ObservableCollection<XmppChatRoomUser> Users
        {
            get
            {
                if (this.users == null)
                {
                    this.users = new ObservableCollection<XmppChatRoomUser>();
                }

                return this.users;
            }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppChatRoom"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="conferenceService">The conference service.</param>
        /// <param name="chatRoomId">The chat room id.</param>
        internal XmppChatRoom(XmppSession session, XmppService conferenceService, XmppJid chatRoomId)
            : base(session, chatRoomId)
        {
            this.conferenceService          = conferenceService;
            this.seekEnterChatRoomEvent     = new AutoResetEvent(false);
            this.createChatRoomEvent        = new AutoResetEvent(false);
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Enters to the chat room
        /// </summary>
        /// <returns></returns>
        public XmppChatRoom Enter()
        {
            Presence presence = new Presence
            {
                From = this.Session.UserId,
                To = this.Identifier
            };

            presence.Items.Add(new Muc());

            this.Session.Send(presence);

            this.createChatRoomEvent.WaitOne();

            return this;
        }

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        public XmppChatRoom SendMessage(string message)
        {
            Message chatMessage = new Message
            {
                ID      = XmppIdentifierGenerator.Generate(),
                Type    = MessageType.GroupChat,
                From    = this.Session.UserId.ToString(),
                To      = this.Identifier
            };

            chatMessage.Items.Add
            (
                new MessageBody
                {
                    Value = message
                }
            );

            this.Session.Send(chatMessage);

            return this;
        }
        
        /// <summary>
        /// Invites the given contact to the chat room
        /// </summary>
        /// <param name="contact"></param>
        public XmppChatRoom Invite(XmppContact contact)
        {
            MucUser user    = new MucUser();
            Message message = new Message
            {
                From    = this.Session.UserId,
                To      = this.Identifier.BareIdentifier,
            };
            MucUserInvite   invite  = new MucUserInvite
            {
                To      = contact.ContactId.BareIdentifier,
                Reason  = "Ninja invite"
            };

            user.Items.Add(invite);
            message.Items.Add(user);

            this.Session.Send(message);

            return this;
        }

        /// <summary>
        /// Closes the chatroom
        /// </summary>
        public void Close()
        {
            Presence presence = new Presence
            {
                Id      = XmppIdentifierGenerator.Generate(),
                To      = this.Identifier,
                Type    = PresenceType.Unavailable
            };

            this.PendingMessages.Add(presence.Id);

            this.Session.Send(presence);
        }

        #endregion

        #region · Message Subscriptions ·

        protected override void Subscribe()
        {
            base.Subscribe();

            this.messageReceivedSubscription = this.Session
                .MessageReceived
                .Where(m => m.Type == MessageType.GroupChat && m.From.BareIdentifier.Equals(this.Identifier.BareIdentifier))
                .Subscribe(message => this.OnMultiUserChatMessageReceived(message));
            
            this.presenceSubscription = this.Session.Connection
                .OnPresenceMessage
                .Where(message => message.From.Equals(this.Identifier.ToString()))
                .Subscribe(message => this.OnPresenceMessageReceived(message));
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();

            if (this.messageReceivedSubscription != null)
            {
                this.messageReceivedSubscription.Dispose();
                this.messageReceivedSubscription = null;
            }

            if (this.presenceSubscription != null)
            {
                this.presenceSubscription.Dispose();
                this.presenceSubscription = null;
            }
        }

        #endregion

        #region · Message Handlers ·

        private void OnMultiUserChatMessageReceived(XmppMessage message)
        {
            this.createChatRoomEvent.Set();
            this.seekEnterChatRoomEvent.Set();
        }

        private void OnPresenceMessageReceived(Presence message)
        {
            //<presence to='carlosga@neko.im/Home' from='babelimtest@conference.neko.im/carlosga'>
            //    <x xmlns='http://jabber.org/protocol/muc#user'>
            //        <item jid='carlosga@neko.im/Home' affiliation='owner' role='moderator'/>
            //        <status code='110'/>
            //    </x>
            //</presence>

            if (message.Items != null && message.Items.Count > 0)
            {
                foreach (object item in message.Items)
                {
                    if (item is MucUser)
                    {
                        this.ProcessMucUser(item as MucUser);
                    }
                }
            }
         
            this.createChatRoomEvent.Set();
            this.seekEnterChatRoomEvent.Set();
        }

        #endregion

        #region · Private Methods ·

        private void ProcessMucUser(MucUser item)
        {
            // Get the Status code
            MucUserStatus status = item.Items.OfType<MucUserStatus>().FirstOrDefault();

            if (status != null)
            {
                switch (status.Code)
                {
                    case 100:
                        // stanza : message or presence
                        // context: Entering a room
                        // purpose: Inform user that any occupant is allowed to see the user's full JID
                        break;

                    case 101:
                        // stanza : message (out of band)
                        // context: Affiliation change
                        // purpose: Inform user that his or her affiliation changed while not in the room
                        break;

                    case 102:
                        // stanza : message
                        // context: Configuration change
                        // purpose: Inform occupants that room now shows unavailable members
                        break;
                    
                    case 103:
                        // stanza : message
                        // context: Configuration change
                        // purpose: Inform occupants that room now does not show unavailable members
                        break;

                    case 104:
                        // stanza : message
                        // context: Configuration change
                        // purpose: Inform occupants that a non-privacy-related room configuration change has occurred
                        break;

                    case 110:
                        // stanza : presence
                        // context: Any room presence
                        // purpose: Inform user that presence refers to one of its own room occupants</purpose>
                        break;

                    case 170:
                        // stanza : message or initial presence
                        // context: Configuration change
                        // purpose: Inform occupants that room logging is now enabled
                        break;

                    case 171:
                        // stanza : message
                        // context: Configuration change
                        // purpose: Inform occupants that room logging is now disabled
                        break;

                    case 172:
                        // stanza : message
                        // context: Configuration change
                        // purpose: Inform occupants that the room is now non-anonymous
                        break;

                    case 173:
                        // stanza : message
                        // context: Configuration change
                        // purpose: Inform occupants that the room is now semi-anonymous
                        break;

                    case 174:
                        // stanza : message
                        // context: Configuration change
                        // purpose: Inform occupants that the room is now fully-anonymous
                        break;

                    case 201:
                        // stanza : presence
                        // context: Entering a room
                        // purpose: Inform user that a new room has been created
                        break;

                    case 210:
                        // stanza : presence
                        // context: Entering a room
                        // purpose: Inform user that service has assigned or modified occupant's roomnick
                        break;

                    case 301:
                        // stanza : presence
                        // context: Removal from room
                        // purpose: Inform user that he or she has been banned from the room
                        break;

                    case 303:
                        // stanza : presence
                        // context: Exiting a room
                        // purpose: Inform all occupants of new room nickname
                        break;

                    case 307:
                        // stanza : presence
                        // context: Removal from room
                        // purpose: Inform user that he or she has been kicked from the room
                        break;

                    case 321:
                        // stanza : presence
                        // context: Removal from room
                        // purpose: Inform user that he or she is being removed from the room
                        //          because of an affiliation change
                        break;

                    case 322:
                        // stanza : presence
                        // context: Removal from room
                        // purpose: Inform user that he or she is being removed from the room
                        //          because the room has been changed to members-only and the user
                        //          is not a member
                        break;

                    case 332:
                        // stanza : presence
                        // context: Removal from room
                        // purpose: Inform user that he or she is being removed from the room
                        //          because of a system shutdown
                        break;
                }
            }
        }

        #endregion
    }
}
