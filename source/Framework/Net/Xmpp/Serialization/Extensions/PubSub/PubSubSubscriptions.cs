// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("subscriptions", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubSubscriptions
    {
        #region · Fields ·

        private List<PubSubSubscription> subscriptionField;
        private string nodeField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("subscription")]
        public List<PubSubSubscription> Subscription
        {
            get { return this.subscriptionField; }
            set { this.subscriptionField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("node")]
        public string Node
        {
            get { return this.nodeField; }
            set { this.nodeField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSubSubscriptions()
        {
            if ((this.subscriptionField == null))
            {
                this.subscriptionField = new List<PubSubSubscription>();
            }
        }

        #endregion
    }
}
