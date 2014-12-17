// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Core;
using BabelIm.Net.Xmpp.InstantMessaging.Configuration;
using BabelIm.Net.Xmpp.InstantMessaging.MultiUserChat;
using BabelIm.Net.Xmpp.InstantMessaging.PersonalEventing;
using BabelIm.Net.Xmpp.InstantMessaging.ServiceDiscovery;
using BabelIm.Net.Xmpp.Serialization.Extensions.UserMood;
using System;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// Interface for XMPP session implementations
    /// </summary>
    public interface IXmppSession
    {
        #region · Events ·

        event EventHandler<XmppAuthenticationFailiureEventArgs> AuthenticationFailed;

        #endregion

        #region · Observable Actions ·

        IObservable<XmppMessage> MessageReceived
        {
            get;
        }

        IObservable<XmppSessionState> StateChanged
        {
            get;
        }

        #endregion

        #region · Properties ·

        XmppPersonalEventing PersonalEventing
        {
            get;
        }
        
        XmppPresence Presence
        {
            get;
        }

        XmppRoster Roster
        {
            get;
        }

        XmppServiceDiscovery ServiceDiscovery
        {
            get;
        }

        XmppSessionState State
        {
            get;
        }

        XmppJid UserId
        {
            get;
        }

        XmppActivity Activity
        {
            get;
        }

        AvatarStorage AvatarStorage
        {
            get;
        }

        XmppSessionEntityCapabilities Capabilities
        {
            get;
        }

        #endregion

        #region · Methods ·

        IXmppSession Open(string connectionString);

        IXmppSession PublishAvatar(string mimetype, string hash, System.Drawing.Image avatarImage);

        IXmppSession PublishDisplayName(string displayName);

        IXmppSession PublishMood(XmppUserMoodEvent moodEvent);

        IXmppSession PublishMood(MoodType mood, string description);

        IXmppSession PublishTune(XmppUserTuneEvent tuneEvent);

        IXmppSession SetPresence(XmppPresenceState newPresence);

        IXmppSession SetPresence(XmppPresenceState newPresence, string status);

        IXmppSession SetPresence(XmppPresenceState newPresence, string status, int priority);

        IXmppSession SetUnavailable();

        IXmppSession StopTunePublication();

        IXmppSession Close();

        XmppChat CreateChat(XmppJid contactId);

        XmppChat CreateChat(string contactId);

        XmppChatRoom EnterChatRoom();

        XmppChatRoom EnterChatRoom(string chatRoomName);

        bool HasOpenChat(XmppJid contactId);

        bool HasOpenChat(string contactId);

        #endregion
    }
}