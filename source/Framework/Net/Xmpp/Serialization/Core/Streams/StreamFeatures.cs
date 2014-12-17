// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Core.ResourceBinding;
using BabelIm.Net.Xmpp.Serialization.Core.Sasl;
using BabelIm.Net.Xmpp.Serialization.Core.Tls;
using BabelIm.Net.Xmpp.Serialization.Extensions.EntityCapabilities;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging;
using System;
using System.Collections;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Streams
{
    /// <summary>
    /// http://xmpp.org/rfcs/rfc3920.html
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://etherx.jabber.org/streams")]
    [XmlRootAttribute("features", Namespace = "http://etherx.jabber.org/streams", IsNullable = false)]
    public class StreamFeatures
    {
        #region · Fields ·

        private StartTls                starttlsField;
        private Mechanisms              mechanismsField;
        private EntityCapabilities      entityCapabilitiesField;
        private Bind                    bindField;
        private Session                 sessionField;
        private RosterVersioningFeature rosterVersioningField;
        private ArrayList               itemsField;
        private bool                    sessionFieldSpecified;

        #endregion

        #region · Properties ·

        [XmlElementAttribute("c", Namespace = "http://jabber.org/protocol/caps")]
        public EntityCapabilities EntityCapabilities
        {
            get { return this.entityCapabilitiesField; }
            set { this.entityCapabilitiesField = value; }
        }

        [XmlElementAttribute("ver", Namespace = "urn:xmpp:features:rosterver")]
        public RosterVersioningFeature RosterVersioning
        {
            get { return this.rosterVersioningField; }
            set { this.rosterVersioningField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("starttls", Namespace = "urn:ietf:params:xml:ns:xmpp-tls")]
        public StartTls StartTls
        {
            get { return this.starttlsField; }
            set { this.starttlsField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("mechanisms", Namespace = "urn:ietf:params:xml:ns:xmpp-sasl")]
        public Mechanisms Mechanisms
        {
            get { return this.mechanismsField; }
            set { this.mechanismsField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("bind", Namespace = "urn:ietf:params:xml:ns:xmpp-bind")]
        public Bind Bind
        {
            get { return this.bindField; }
            set { this.bindField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("session", Namespace = "urn:ietf:params:xml:ns:xmpp-session")]
        public Session Session
        {
            get { return this.sessionField; }
            set
            {
                this.SessionSpecified = true;
                this.sessionField = value;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool SessionSpecified
        {
            get { return this.sessionFieldSpecified; }
            set { this.sessionFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("register", typeof(RegisterIQ), Namespace = "http://jabber.org/features/iq-register")]
        public ArrayList Items
        {
            get { return this.itemsField; }
        }

        #endregion

        #region · Constructors ·

        public StreamFeatures()
        {
            this.itemsField = new ArrayList();
        }

        #endregion
    }
}
