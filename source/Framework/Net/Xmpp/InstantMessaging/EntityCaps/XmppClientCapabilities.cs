// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.InstantMessaging.ServiceDiscovery;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// Client capabilities (XEP-0115)
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "")]
    [XmlRootAttribute("client", Namespace = "", IsNullable = false)]
    public class XmppClientCapabilities
    {
        #region · Fields ·

        private string                      node;
        private string                      hashAlgorithmName;
        private string                      verificationString;
        private List<XmppServiceIdentity>   identities;
        private List<XmppServiceFeature>    supportedFeatures;
        
        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets or sets the client node
        /// </summary>
        [XmlAttribute("node")]
        public string Node
        {
            get { return this.node; }
            set { this.node = value; }
        }

        /// <summary>
        /// Gets or sets the client version
        /// </summary>
        [XmlAttribute("ver")]
        public string VerificationString
        {
            get { return this.verificationString; }
            set { this.verificationString = value; }
        }

        /// <summary>
        /// Gets or sets the hash algorithm name
        /// </summary>
        [XmlAttribute("hash")]
        public string HashAlgorithmName
        {
            get { return hashAlgorithmName; }
            set { this.hashAlgorithmName = value; }
        }

        /// <summary>
        /// Gets or sets the identity.
        /// </summary>
        /// <value>The identity.</value>
        [XmlArray("identities")]
        [XmlArrayItem("identity", typeof(XmppServiceIdentity))]
        public List<XmppServiceIdentity> Identities
        {
            get
            {
                if (this.identities == null)
                {
                    this.identities = new List<XmppServiceIdentity>();
                }

                return this.identities;
            }
        }

        /// <summary>
        /// Gets the list of supported features
        /// </summary>
        [XmlArray("features")]
        [XmlArrayItem("feature", typeof(XmppServiceFeature))]
        public List<XmppServiceFeature> Features
        {
            get
            {
                if (this.supportedFeatures == null)
                {
                    this.supportedFeatures = new List<XmppServiceFeature>();
                }

                return this.supportedFeatures;
            }
        }

        /// <summary>
        /// Gets the discovery info node
        /// </summary>
        [XmlIgnore]
        public string DiscoveryInfoNode
        {
            get { return String.Format("{0}#{1}", this.Node, this.VerificationString); }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppClientCapabilities"/> class.
        /// </summary>
        public XmppClientCapabilities()
        {
        }

        #endregion
    }
}
