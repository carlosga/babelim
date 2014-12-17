// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Streams
{
    /// <summary>
    /// http://xmpp.org/rfcs/rfc3921.html
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:xmpp-session")]
    [XmlRootAttribute("session", Namespace = "urn:ietf:params:xml:ns:xmpp-session")]
    public class Session
    {
        #region · Fields ·

        private Empty           itemField;    
        private ItemChoiceType  itemElementNameField;

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

        #endregion

        #region · Constructors ·

        public Session()
        {
        }

        #endregion
    }
}
