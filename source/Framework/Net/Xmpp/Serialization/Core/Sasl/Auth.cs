// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Sasl
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:xmpp-sasl")]
    [XmlRootAttribute("auth", Namespace = "urn:ietf:params:xml:ns:xmpp-sasl", IsNullable = false)]
    public class Auth
    {
        #region · Fields ·

        private string mechanismField;
        private string value;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("mechanism")]
        public string Mechanism
        {
            get { return this.mechanismField; }
            set { this.mechanismField = value; }
        }

        [XmlText]
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        #endregion

        #region · Constructors ·

        public Auth()
        {
        }

        #endregion
    }
}
