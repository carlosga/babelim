// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat.User;
using BabelIm.Net.Xmpp.Serialization.Extensions.PubSub;
using System;
using System.Collections;
using System.ComponentModel;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:client")]
    [XmlRootAttribute("message", Namespace = "jabber:client", IsNullable = false)]
    public class Message
    {
        #region · Fields ·

        private ArrayList itemsField;
        private Error errorField;
        private string fromField;
        private string idField;
        private string toField;
        private MessageType typeField;
        private string langField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("subject", typeof(MessageSubject))]
        [XmlElementAttribute("body", typeof(MessageBody))]
        [XmlElementAttribute("thread", typeof(string), DataType = "NMTOKEN")]
        [XmlElementAttribute("active", typeof(NotificationActive), Namespace = "http://jabber.org/protocol/chatstates")]
        [XmlElementAttribute("composing", typeof(NotificationComposing), Namespace = "http://jabber.org/protocol/chatstates")]
        [XmlElementAttribute("gone", typeof(NotificationGone), Namespace = "http://jabber.org/protocol/chatstates")]
        [XmlElementAttribute("inactive", typeof(NotificationInactive), Namespace = "http://jabber.org/protocol/chatstates")]
        [XmlElementAttribute("paused", typeof(NotificationPaused), Namespace = "http://jabber.org/protocol/chatstates")]
        [XmlElementAttribute("event", typeof(PubSubEvent), Namespace = "http://jabber.org/protocol/pubsub#event")]
        [XmlElementAttribute("x", Type = typeof(MucUser), Namespace = "http://jabber.org/protocol/muc#user")]
        public ArrayList Items
        {
            get { return this.itemsField; }
        }

        /// <remarks/>
        [XmlElement("error")]
        public Error Error
        {
            get { return this.errorField; }
            set { this.errorField = value; }
        }
                
        /// <remarks/>
        [XmlAttributeAttribute("from")]
        public string From
        {
            get { return this.fromField; }
            set { this.fromField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("id", DataType = "NMTOKEN")]
        public string ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("to")]
        public string To
        {
            get { return this.toField; }
            set { this.toField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("type")]
        [DefaultValueAttribute(MessageType.Normal)]
        public MessageType Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("lang", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang
        {
            get { return this.langField; }
            set { this.langField = value; } 
        }

        #endregion

        #region · Constructors ·

        public Message()
        {
            this.typeField	= MessageType.Normal;
            this.itemsField = new ArrayList();
        }

        #endregion
    }
}
