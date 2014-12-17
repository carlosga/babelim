// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("pubsub", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSub
    {
        #region · Fields ·

        private List<object> itemsField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("affiliations", typeof(PubSubAffiliations))]
        [XmlElementAttribute("configure", typeof(PubSubConfigure))]
        [XmlElementAttribute("create", typeof(PubSubCreate))]
        [XmlElementAttribute("items", typeof(PubSubItems))]
        [XmlElementAttribute("options", typeof(PubSubOptions))]
        [XmlElementAttribute("publish", typeof(PubSubPublish))]
        [XmlElementAttribute("retract", typeof(PubSubRetract))]
        [XmlElementAttribute("subscribe", typeof(PubSubSubscribe))]
        [XmlElementAttribute("subscription", typeof(PubSubSubscription))]
        [XmlElementAttribute("subscriptions", typeof(PubSubSubscriptions))]
        [XmlElementAttribute("unsubscribe", typeof(PubSubUnsubscribe))]
        public List<object> Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSub()
        {
            if ((this.itemsField == null))
            {
                this.itemsField = new List<object>();
            }
        }

        #endregion
    }
}
