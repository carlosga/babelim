// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#event")]
    [XmlRootAttribute("event", Namespace = "http://jabber.org/protocol/pubsub#event", IsNullable = false)]
    public class PubSubEvent
    {
        #region · Fields ·

        private object itemField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("collection", typeof(PubSubEventCollection))]
        [XmlElementAttribute("configuration", typeof(PubSubEventConfiguration))]
        [XmlElementAttribute("delete", typeof(PubSubEventDelete))]
        [XmlElementAttribute("items", typeof(PubSubEventItems))]
        [XmlElementAttribute("purge", typeof(PubSubEventPurge))]
        [XmlElementAttribute("subscription", typeof(PubSubEventSubscription))]
        public object Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSubEvent()
        {
        }

        #endregion
    }
}
