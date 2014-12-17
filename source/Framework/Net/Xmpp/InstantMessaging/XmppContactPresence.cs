// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client.Presence;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// XMPP Contact presence information
    /// </summary>
    public sealed class XmppContactPresence 
        : ObservableObject
    {
        #region · Fields ·

        private XmppPresenceState   presenceStatus;
        private XmppSession         session;
        private int                 priority;
        private string              statusMessage;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets or sets the presence priority.
        /// </summary>
        /// <value>The priority.</value>
        public int Priority
        {
            get { return this.priority; }
            set
            {
                if (this.priority != value)
                {
                    this.priority = value;
                    this.NotifyPropertyChanged(() => Priority);
                }
            }
        }

        /// <summary>
        /// Gets or sets the presence status.
        /// </summary>
        /// <value>The presence status.</value>
        public XmppPresenceState PresenceStatus
        {
            get { return this.presenceStatus; }
            set
            {
                if (this.presenceStatus != value)
                {
                    this.presenceStatus = value;
                    this.NotifyPropertyChanged(() => PresenceStatus);
                    this.session.Roster.OnContactPresenceChanged();
                }                
            }
        }

        /// <summary>
        /// Gets or sets the presence status message.
        /// </summary>
        /// <value>The presence status message.</value>
        public string StatusMessage
        {
            get { return this.statusMessage; }
            set
            {
                if (this.statusMessage != value)
                {
                    this.statusMessage = value;
                    this.NotifyPropertyChanged(() => StatusMessage);
                }
            }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="">XmppContactPresence</see>
        /// </summary>
        /// <param name="session"></param>
        internal XmppContactPresence(XmppSession session)
        {
            this.session        = session;
            this.presenceStatus = XmppPresenceState.Offline;
        }

        #endregion

        #region · Internal Methods ·

        internal void Update(Presence presence)
        {
            if (presence.TypeSpecified &&
                presence.Type == PresenceType.Unavailable)
            {
                this.PresenceStatus = XmppPresenceState.Offline;
            }
            else
            {
                this.PresenceStatus = XmppPresenceState.Available;
            }

            foreach (object item in presence.Items)
            {
                if (item is sbyte)
                {
                    this.Priority = (sbyte)item;
                }
                if (item is int)
                {
                    this.Priority = (int)item;
                }
                else if (item is ShowType)
                {
                    this.PresenceStatus = this.DecodeShowAs((ShowType)item);
                }
                else if (item is Status)
                {
                    this.StatusMessage = ((Status)item).Value;
                }
            }
        }

        #endregion

        #region · Private Methods ·

        private XmppPresenceState DecodeShowAs(ShowType showas)
        {
            switch (showas)
            {
                case ShowType.Away:
                    return XmppPresenceState.Away;

                case ShowType.Busy:
                    return XmppPresenceState.Busy;

                case ShowType.ExtendedAway:
                    return XmppPresenceState.Idle;

                case ShowType.Online:
                    return XmppPresenceState.Available;
            }

            return XmppPresenceState.Offline;
        }

        #endregion
    }
}
