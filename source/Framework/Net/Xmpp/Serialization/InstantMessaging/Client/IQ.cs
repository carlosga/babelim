// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Core.ResourceBinding;
using BabelIm.Net.Xmpp.Serialization.Core.Streams;
using BabelIm.Net.Xmpp.Serialization.Extensions.PubSub;
using BabelIm.Net.Xmpp.Serialization.Extensions.ServiceDiscovery;
using BabelIm.Net.Xmpp.Serialization.Extensions.SimpleCommunicationsBlocking;
using BabelIm.Net.Xmpp.Serialization.Extensions.VCard;
using BabelIm.Net.Xmpp.Serialization.Extensions.XmppPing;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Register;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Roster;
using System;
using System.Collections;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client
{
    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "jabber:client")]
    [XmlRoot("iq", Namespace = "jabber:client", IsNullable = false)]
    public class IQ
    {
        #region · Fields ·

        private ArrayList items;
        private Error errorField;
        private string fromField;
        private string idField;
        private string toField;
        private IQType typeField;
        private string langField;

        #endregion

        #region · Properties ·
        
        /// <remarks/>
        [XmlElement("bind", Type = typeof(Bind), Namespace = "urn:ietf:params:xml:ns:xmpp-bind")]
        [XmlElement("session", Type = typeof(Session), Namespace = "urn:ietf:params:xml:ns:xmpp-session")]
        [XmlElement("ping", Type = typeof(Ping), Namespace = "urn:xmpp:ping")]
        [XmlElement("query", Type = typeof(Browse), Namespace = "jabber:iq:browse")]
        [XmlElement("query", Type = typeof(RegisterQuery), Namespace = "jabber:iq:register")]
        [XmlElement("query", Type = typeof(RosterQuery), Namespace = "jabber:iq:roster")]
        [XmlElement("pubsub", Type = typeof(PubSub), Namespace = "http://jabber.org/protocol/pubsub")]
        [XmlElement("query", Type = typeof(ServiceQuery), Namespace = "http://jabber.org/protocol/disco#info")]
        [XmlElement("query", Type = typeof(ServiceItemQuery), Namespace = "http://jabber.org/protocol/disco#items")]
        [XmlElement("vCard", Type = typeof(VCardData), Namespace = "vcard-temp")]
        [XmlElement("blocklist", Type = typeof(BlockList), Namespace = "urn:xmpp:blocking")]
        [XmlElement("block", Type = typeof(Block), Namespace = "urn:xmpp:blocking")]
        [XmlElement("unblock", Type = typeof(UnBlock), Namespace = "urn:xmpp:blocking")]
        public ArrayList Items
        {
            get { return this.items; }
        }

        /// <remarks/>
        [XmlElementAttribute("error")]
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
        public IQType Type
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

        public IQ()
        {
            this.items = new ArrayList();
        }

        #endregion
    }
}
