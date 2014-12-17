// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("subscribe-options", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubSubscribeOptions
    {
        #region · Fields ·

        private string requiredField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElement("required")]
        public string Required
        {
            get { return this.requiredField; }
            set { this.requiredField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSubSubscribeOptions()
        {
        }

        #endregion
    }
}
