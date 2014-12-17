// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#event")]
    [XmlRootAttribute("subscription", Namespace = "http://jabber.org/protocol/pubsub#event", IsNullable = false)]
    public class PubSubEventSubscription
    {
        #region · Fields ·

        private DateTime expiryField;
        private bool expiryFieldSpecified;
        private string jidField;
        private string nodeField;
        private string subidField;
        private PubSubEventSubscriptionType subscriptionType;
        private bool subscriptionTypeSpecified;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("expiry")]
        public DateTime Expiry
        {
            get { return this.expiryField; }
            set
            {
                this.expiryField = value;
                this.expiryFieldSpecified = true;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool ExpirySpecified
        {
            get { return this.expiryFieldSpecified; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
            get { return this.jidField; }
            set { this.jidField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string node
        {
            get { return this.nodeField; }
            set { this.nodeField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("subid")]
        public string Subid
        {
            get { return this.subidField; }
            set { this.subidField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("subscription")]
        public PubSubEventSubscriptionType SubscriptionType
        {
            get { return this.subscriptionType; }
            set
            {
                this.subscriptionType = value;
                this.subscriptionTypeSpecified = true;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool SubscriptionTypeSpecified
        {
            get { return this.subscriptionTypeSpecified; }
        }

        /// <remarks/>
        [XmlTextAttribute()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSubEventSubscription()
        {
        }

        #endregion
    }
}
