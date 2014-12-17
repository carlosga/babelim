// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#event")]
    [XmlRootAttribute("retract", Namespace = "http://jabber.org/protocol/pubsub#event", IsNullable = false)]
    public class PubSubEventRetract
    {
        #region · Fields ·

        private string idField;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("id")]
        public string Id
        {
            get { return this.idField; }
            set { this.idField = value; }
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

        #endregion
    }
}
