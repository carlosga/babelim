// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.UserMood;
using BabelIm.Net.Xmpp.Serialization.Extensions.UserTune;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("item", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubItem
    {
        #region · Fields ·

        private object item;
        private string idField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("tune", typeof(Tune), Namespace = "http://jabber.org/protocol/tune")]
        [XmlElementAttribute("mood", typeof(Mood), Namespace = "http://jabber.org/protocol/mood")]
        public object Item
        {
            get { return this.item; }
            set { this.item = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("id")]
        public string Id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSubItem()
        {
        }

        #endregion
    }
}
