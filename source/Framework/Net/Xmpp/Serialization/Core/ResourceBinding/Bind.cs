// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.ResourceBinding
{
    /// <summary>
    /// http://xmpp.org/rfcs/rfc3920.html
    /// http://xmpp.org/extensions/xep-0193.html
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:xmpp-bind")]
    [XmlRootAttribute("bind", Namespace = "urn:ietf:params:xml:ns:xmpp-bind", IsNullable = false)]
    public class Bind
    {
        #region · Fields ·

        private Empty           itemField;    
        private ItemChoiceType  itemElementNameField;
        private string          resourceField;
        private string          jidField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("optional", typeof(Empty))]
        [XmlElementAttribute("required", typeof(Empty))]
        [XmlChoiceIdentifierAttribute("ItemElementName")]
        public Empty Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }
    
        /// <remarks/>
        [XmlIgnoreAttribute]
        public ItemChoiceType ItemElementName
        {
            get { return this.itemElementNameField; }
            set { this.itemElementNameField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("resource")]
        public string Resource
        {
            get { return this.resourceField; }
            set { this.resourceField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("jid")]
        public string Jid
        {
            get { return this.jidField; }
            set { this.jidField = value; }
        }

        #endregion

        #region · Constructors ·

        public Bind()
        {
        }

        #endregion
    }
}
