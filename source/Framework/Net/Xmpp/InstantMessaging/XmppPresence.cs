// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Core;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client.Presence;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// Presence handling
    /// </summary>
    public sealed class XmppPresence
    {
        #region · Fields ·

        private XmppSession session;

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppPresence"/> class using
        /// the given session.
        /// </summary>
        /// <param name="session"></param>
        internal XmppPresence(XmppSession session)
        {
            this.session = session;
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Gets the presence of the given user.
        /// </summary>
        /// <param name="targetJid">User JID</param>
        public void GetPresence(XmppJid targetJid)
        {
            Presence presence = new Presence
            {
                Id      = XmppIdentifierGenerator.Generate(),
                Type    = PresenceType.Probe,
                From    = this.session.UserId,
                To      = targetJid
            };

            this.session.Send(presence);
        }

        /// <summary>
        /// Sets the initial presence status.
        /// </summary>
        public void SetInitialPresence()
        {
            this.SetInitialPresence(null);
        }

        /// <summary>
        /// Sets the initial presence against the given user.
        /// </summary>
        /// <param name="target">JID of the target user.</param>
        public void SetInitialPresence(XmppJid target)
        {
            Presence presence = new Presence();

            if (target != null && target.ToString().Length > 0)
            {
                presence.To = target.ToString();
            }

            this.session.Send(presence);
        }

        /// <summary>
        /// Set the presence as <see cref="XmppPresenceState.Available"/>
        /// </summary>
        public void SetPresence()
        {
            this.SetPresence(XmppPresenceState.Available);
        }

        /// <summary>
        /// Sets the presense state.
        /// </summary>
        /// <param name="presenceState"></param>
        public void SetPresence(XmppPresenceState presenceState)
        {
            this.SetPresence(presenceState, null);
        }

        /// <summary>
        /// Sets the presence state with the given state and status message
        /// </summary>
        /// <param name="showAs"></param>
        /// <param name="statusMessage"></param>
        public void SetPresence(XmppPresenceState showAs, string statusMessage)
        {
            this.SetPresence(showAs, statusMessage, 0);
        }

        /// <summary>
        /// Sets the presence state with the given state, status message and priority
        /// </summary>
        /// <param name="showAs"></param>
        /// <param name="statusMessage"></param>
        /// <param name="priority"></param>
        public void SetPresence(XmppPresenceState showAs, string statusMessage, int priority)
        {
            Presence    presence    = new Presence();
            Status      status      = new Status();

            status.Value    = statusMessage;
            presence.Id     = XmppIdentifierGenerator.Generate();

            presence.Items.Add((ShowType)showAs);
            presence.Items.Add(status);

            this.session.Send(presence);
        }

        /// <summary>
        /// Sets the presence as Unavailable
        /// </summary>
        public void SetUnavailable()
        {
            Presence presence = new Presence
            {
                Type = PresenceType.Unavailable
            };

            this.session.Send(presence);
        }

        /// <summary>
        /// Request subscription to the given user
        /// </summary>
        /// <param name="contactId"></param>
        public void RequestSubscription(XmppJid jid)
        {
            Presence presence = new Presence
            {
                Type   = PresenceType.Subscribe,
                To     = jid
            };
            
            this.session.Send(presence);
        }

        /// <summary>
        /// Subscribes to presence updates of the current user
        /// </summary>
        /// <param name="jid"></param>
        public void Subscribed(XmppJid jid)
        {
            Presence presence = new Presence
            {
                Type    = PresenceType.Subscribed,
                To      = jid
            };

            this.session.Send(presence);
        }

        /// <summary>
        /// Subscribes to presence updates of the current user
        /// </summary>
        /// <param name="jid"></param>
        public void Unsuscribed(XmppJid jid)
        {
            Presence presence = new Presence
            {
                Type    = PresenceType.Unsubscribed,
                To      = jid
            };

            this.session.Send(presence);
        }

        #endregion
    }
}
