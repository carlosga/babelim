// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("affiliation", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubAffiliation
    {
        #region · Fields ·

        private PubSubAffiliationType affiliationField;
        private string nodeField;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("affiliation")]
        public PubSubAffiliationType Affiliation
        {
            get { return this.affiliationField; }
            set { this.affiliationField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Node
        {
            get { return this.nodeField; }
            set { this.nodeField = value; }
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

        public PubSubAffiliation()
        {
        }

        #endregion
    }
}
