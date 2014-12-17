// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Specialized;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Sasl
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:xmpp-sasl")]
    [XmlRootAttribute("mechanisms", Namespace = "urn:ietf:params:xml:ns:xmpp-sasl", IsNullable = false)]
    public class Mechanisms
    {
        #region · Fields ·

        private StringCollection saslMechanisms;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("mechanism")]
        public StringCollection SaslMechanisms
        {
            get 
            {
                if (this.saslMechanisms == null)
                {
                    this.saslMechanisms = new StringCollection();
                }

                return this.saslMechanisms; 
            }
        }

        #endregion

        #region · Constructors ·

        public Mechanisms()
        {
        }

        #endregion
    }
}
