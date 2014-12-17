// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("items", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubItems
    {
        #region · Fields ·

        private List<PubSubItem> itemField;
        private string maxItemsField;
        private string nodeField;
        private string subidField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("item")]
        public List<PubSubItem> Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("max_items", DataType = "positiveInteger")]
        public string MaxItems
        {
            get { return this.maxItemsField; }
            set { this.maxItemsField = value; }
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

        #endregion

        #region · Constructors ·

        public PubSubItems()
        {
            if ((this.itemField == null))
            {
                this.itemField = new List<PubSubItem>();
            }
        }

        #endregion
    }
}
