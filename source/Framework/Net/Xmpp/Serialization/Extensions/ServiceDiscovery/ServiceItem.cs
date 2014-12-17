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
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/disco#items")]
    [XmlRootAttribute("item", Namespace = "http://jabber.org/protocol/disco#items", IsNullable = false)]
    public class ServiceItem
    {
        #region · Fields ·

        private ServiceActionType actionField;
        private bool actionFieldSpecified;
        private string jidField;
        private string nameField;
        private string nodeField;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("action")]
        public ServiceActionType Action
        {
            get { return this.actionField; }
            set { this.actionField = value; }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool actionSpecified
        {
            get { return this.actionFieldSpecified; }
            set { this.actionFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
            get { return this.jidField; }
            set { this.jidField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("name")]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("node")]
        public string Node
        {
            get { return this.nodeField; }
            set { this.nodeField = value; }
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

        public ServiceItem()
        {
        }

        #endregion
    }
}
