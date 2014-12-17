// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("retract", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubRetract
    {
        #region · Fields ·

        private List<PubSubItem> itemField;
        private string nodeField;
        private bool notifyField;
        private bool notifyFieldSpecified;

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
        [XmlAttributeAttribute("node")]
        public string Node
        {
            get { return this.nodeField; }
            set { this.nodeField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("notify")]
        public bool Notify
        {
            get { return this.notifyField; }
            set
            {
                this.notifyField = value;
                this.notifyFieldSpecified = true;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool NotifySpecified
        {
            get { return this.notifyFieldSpecified; }
        }

        #endregion

        #region · Constructors ·

        public PubSubRetract()
        {
            if ((this.itemField == null))
            {
                this.itemField = new List<PubSubItem>();
            }
        }

        #endregion
    }
}
