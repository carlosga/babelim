// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Sasl
{
    [Serializable]
    [XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:xmpp-sasl")]
    [XmlRootAttribute("challenge", Namespace = "urn:ietf:params:xml:ns:xmpp-sasl", IsNullable = false)]
    public class Challenge
    {
        #region · Fields ·

        private string value;

        #endregion

        #region · Properties ·

        [XmlTextAttribute()]
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        #endregion

        #region · Constructors ·

        public Challenge()
        {
        }

        #endregion
    }
}
