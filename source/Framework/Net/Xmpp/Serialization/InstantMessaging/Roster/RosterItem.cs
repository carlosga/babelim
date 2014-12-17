// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Roster
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:roster")]
    [XmlRootAttribute("item", Namespace = "jabber:iq:roster", IsNullable = false)]
    public class RosterItem
    {
        #region · Fields ·

        private List<String> groupsField;
        private RosterAskType askField;
        private bool askFieldSpecified;
        private string jidField;
        private string nameField;
        private RosterSubscriptionType subscriptionField;
        private bool subscriptionFieldSpecified;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("group")]
        public List<string> Groups
        {
            get { return this.groupsField; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("ask")]
        public RosterAskType Ask
        {
            get { return this.askField; }
            set
            {
                this.askField = value;
                this.askFieldSpecified = true;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool AskSpecified
        {
            get { return this.askFieldSpecified; }
            set { this.askFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
            get { return this.jidField; }
            set { this.jidField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("name")]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("subscription")]
        public RosterSubscriptionType Subscription
        {
            get { return this.subscriptionField; }
            set
            {
                this.SubscriptionSpecified = true;
                this.subscriptionField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool SubscriptionSpecified
        {
            get { return this.subscriptionFieldSpecified; }
            set { this.subscriptionFieldSpecified = value; }
        }

        #endregion

        #region · Constructors ·

        public RosterItem()
        {
            this.groupsField = new List<string>();
        }

        #endregion
    }
}
