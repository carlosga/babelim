// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.ServiceDiscovery
{
    /// <summary>
    /// XEP-0030: Service Discovery
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/disco#info")]
    [XmlRootAttribute("query", Namespace = "http://jabber.org/protocol/disco#info", IsNullable = false)]
    public class ServiceQuery
    {
        #region · Fields ·

        private ArrayList   identitiesField;
        private ArrayList   featuresField;
        private string      node;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("identity", typeof(ServiceIdentity), Namespace = "http://jabber.org/protocol/disco#info")]
        public ArrayList Identities
        {
            get { return this.identitiesField; }
            set { this.identitiesField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("feature", typeof(ServiceFeature), Namespace = "http://jabber.org/protocol/disco#info")]
        public ArrayList Features
        {
            get { return this.featuresField; }
            set { this.featuresField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("node")]
        public string Node
        {
            get { return this.node; }
            set { this.node = value; }
        }

        #endregion

        #region · Constructors ·

        public ServiceQuery()
        {
            this.identitiesField    = new ArrayList();
            this.featuresField      = new ArrayList();
        }

        #endregion
    }
}
