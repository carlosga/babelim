// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.ServiceDiscovery
{
    /// <summary>
    /// XEP-0030: Service Discovery
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/disco#info")]
    [XmlRootAttribute("identity", Namespace = "http://jabber.org/protocol/disco#info", IsNullable = false)]
    public class ServiceIdentity
    {
        #region · Fields ·

        private string categoryField;
        private string nameField;
        private string typeField;
        // private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("category")]
        public string Category
        {
            get { return this.categoryField; }
            set { this.categoryField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("name")]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("type")]
        public string Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        #endregion

        #region · Constructors ·

        public ServiceIdentity()
        {
        }

        #endregion
    }
}
