// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#event")]
    [XmlRootAttribute("items", Namespace = "http://jabber.org/protocol/pubsub#event", IsNullable = false)]
    public class PubSubEventItems
    {
        #region · Fields ·

        private List<object> itemsField;
        private string nodeField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("item", typeof(PubSubItem))]
        [XmlElementAttribute("retract", typeof(PubSubEventRetract))]
        public List<object> Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
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

        public PubSubEventItems()
        {
            if ((this.itemsField == null))
            {
                this.itemsField = new List<object>();
            }
        }

        #endregion
    }
}
