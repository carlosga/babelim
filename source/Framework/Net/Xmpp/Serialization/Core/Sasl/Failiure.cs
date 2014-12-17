// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Sasl
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:xmpp-sasl")]
    [XmlRootAttribute("failure", Namespace = "urn:ietf:params:xml:ns:xmpp-sasl", IsNullable = false)]
    public class Failure
    {
        #region · Fields ·

        private Empty itemField;
        private FailiureType itemElementNameField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("not-authorized", typeof(Empty))]
        [XmlElementAttribute("mechanism-too-weak", typeof(Empty))]
        [XmlElementAttribute("temporary-auth-failure", typeof(Empty))]
        [XmlElementAttribute("invalid-authzid", typeof(Empty))]
        [XmlElementAttribute("aborted", typeof(Empty))]
        [XmlElementAttribute("incorrect-encoding")]
        [XmlElementAttribute("invalid-mechanism", typeof(Empty))]
        [XmlChoiceIdentifierAttribute("FailiureType")]
        public Empty Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }

        /// <remarks/>
        [XmlIgnore()]
        public FailiureType FailiureType
        {
            get { return this.itemElementNameField; }
            set { this.itemElementNameField = value; }
        }

        #endregion

        #region · Constructors ·

        public Failure()
        {
        }

        #endregion
    }
}
