// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#errors")]
    [XmlRootAttribute("unsupported", Namespace = "http://jabber.org/protocol/pubsub#errors", IsNullable = false)]
    public class PubSubErrorUnsupported
    {
        #region · Fields ·

        private PubSubErrorUnsupportedFeatureType featureField;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("feature")]
        public PubSubErrorUnsupportedFeatureType Feature
        {
            get { return this.featureField; }
            set { this.featureField = value; }
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

        public PubSubErrorUnsupported()
        {
        }

        #endregion
    }

}
