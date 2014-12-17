// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("publish", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubPublish
    {
        #region · Fields ·

        private List<PubSubItem> itemField;
        private string nodeField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("item")]
        public List<PubSubItem> Items
        {
            get { return this.itemField; }
            set { this.itemField = value; }
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

        public PubSubPublish()
        {
            if ((this.itemField == null))
            {
                this.itemField = new List<PubSubItem>();
            }
        }

        #endregion
    }
}
