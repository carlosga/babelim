/*
    Copyright (c) 2007 - 2010, Carlos Guzm�n �lvarez

    All rights reserved.

    Redistribution and use in source and binary forms, with or without modification, 
    are permitted provided that the following conditions are met:

        * Redistributions of source code must retain the above copyright notice, 
          this list of conditions and the following disclaimer.
        * Redistributions in binary form must reproduce the above copyright notice, 
          this list of conditions and the following disclaimer in the documentation and/or 
          other materials provided with the distribution.
        * Neither the name of the author nor the names of its contributors may be used to endorse or 
          promote products derived from this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
    "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
    LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
    A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
    CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
    EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
    PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
    PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
    LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
    NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections;
using System.Xml.Serialization;
using BabelIm.Net.Xmpp.Serialization.Core.ResourceBinding;
using BabelIm.Net.Xmpp.Serialization.Core.Sasl;
using BabelIm.Net.Xmpp.Serialization.Core.Tls;
using BabelIm.Net.Xmpp.Serialization.Extensions.EntityCapabilities;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging;

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
        #region � Fields �

        private StartTls                starttlsField;
        private Mechanisms              mechanismsField;
        private EntityCapabilities      entityCapabilitiesField;
        private Bind                    bindField;
        private Session                 sessionField;
        private RosterVersioningFeature rosterVersioningField;
        private ArrayList               itemsField;
        private bool                    sessionFieldSpecified;

        #endregion

        #region � Properties �

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

        #region � Constructors �

        public StreamFeatures()
        {
            this.itemsField = new ArrayList();
        }

        #endregion
    }
}