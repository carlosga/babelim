// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("unsubscribe", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubUnsubscribe
    {
        #region · Fields ·

        private string jidField;
        private string nodeField;
        private string subidField;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
            get { return this.jidField; }
            set { this.jidField = value; }
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
        [XmlTextAttribute()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSubUnsubscribe()
        {
        }

        #endregion
    }
}
