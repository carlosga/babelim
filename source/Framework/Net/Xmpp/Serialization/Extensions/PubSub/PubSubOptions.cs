// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("options", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubOptions
    {
        #region · Fields ·

        private System.Xml.XmlElement anyField;
        private string jidField;
        private string nodeField;
        private string subidField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAnyElementAttribute()]
        public System.Xml.XmlElement Any
        {
            get { return this.anyField; }
            set { this.anyField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
            get { return this.jidField; }
            set { this.jidField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("node")]
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

        #endregion

        #region · Constructors ·

        #endregion
    }
}
