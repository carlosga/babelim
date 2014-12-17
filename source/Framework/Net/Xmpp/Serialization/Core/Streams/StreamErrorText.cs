// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Streams
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(TypeName = "text", Namespace = "urn:ietf:params:xml:ns:xmpp-streams")]
    [XmlRootAttribute("text", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable = false)]
    public class StreamErrorText
    {
        #region · Fields ·

        private string langField;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("lang", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang
        {
            get { return this.langField; }
            set { this.langField = value; }
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

        public StreamErrorText()
        {
        }

        #endregion
    }
}
