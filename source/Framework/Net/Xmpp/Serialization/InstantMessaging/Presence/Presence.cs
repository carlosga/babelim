// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.EntityCapabilities;
using BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat;
using BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat.User;
using BabelIm.Net.Xmpp.Serialization.Extensions.VCard;
using System;
using System.Collections;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client.Presence
{
    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "jabber:client")]
    [XmlRoot("presence", Namespace = "jabber:client", IsNullable = false)]
    public class Presence
    {
        #region · Fields ·

        private ArrayList itemsField;
        private Error errorField;
        private string fromField;
        private string idField;
        private string toField;
        private PresenceType typeField;
        private bool typeFieldSpecified;
        private string langField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElement("status", Type = typeof(Status))]
        [XmlElement("show", Type = typeof(ShowType))]
        [XmlElement("priority", Type = typeof(sbyte))]
        [XmlElement("c", Namespace = "http://jabber.org/protocol/caps", Type = typeof(EntityCapabilities))]
        [XmlElement("x", Namespace = "vcard-temp:x:update", Type = typeof(VCardAvatar))]
        [XmlElement("x", Type = typeof(Muc), Namespace="http://jabber.org/protocol/muc")]
        [XmlElement("x", Type = typeof(MucUser), Namespace = "http://jabber.org/protocol/muc#user")]
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
        public string Id
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
        public PresenceType Type
        {
            get { return this.typeField; }
            set
            {
                this.typeField = value;
                this.typeFieldSpecified = true;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool TypeSpecified
        {
            get { return this.typeFieldSpecified; }
            set { this.typeFieldSpecified = value; }
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

        public Presence()
        {
            this.itemsField = new ArrayList();
        }

        #endregion
    }
}
