// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("subscription", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubSubscription
    {
        #region · Fields ·

        private PubSubSubscribeOptions subscribeoptionsField;
        private string jidField;
        private string nodeField;
        private string subidField;
        private PubSubSubscriptionType subscriptionField;
        private bool subscriptionFieldSpecified;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("subscribe-options")]
        public PubSubSubscribeOptions SubscribeOptions
        {
            get { return this.subscribeoptionsField; }
            set { this.subscribeoptionsField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
            get
            {
                return this.jidField;
            }
            set
            {
                this.jidField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute("node")]
        public string Node
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
        public PubSubSubscriptionType Subscription
        {
            get { return this.subscriptionField; }
            set
            {
                this.subscriptionField = value;
                this.subscriptionFieldSpecified = true;
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

        public PubSubSubscription()
        {
            if ((this.subscribeoptionsField == null))
            {
                this.subscribeoptionsField = new PubSubSubscribeOptions();
            }
        }

        #endregion
    }
}
