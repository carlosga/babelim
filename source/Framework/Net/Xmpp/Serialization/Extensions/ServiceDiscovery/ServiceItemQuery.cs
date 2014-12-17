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
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/disco#items")]
    [XmlRootAttribute("query", Namespace = "http://jabber.org/protocol/disco#items", IsNullable = false)]
    public class ServiceItemQuery
    {
        #region · Fields ·

        private ArrayList itemsField;
        private string nodeField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("item", typeof(ServiceItem), Namespace = "http://jabber.org/protocol/disco#items")]
        public ArrayList Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("node")]
        public string Node
        {
            get { return this.nodeField; }
            set { this.nodeField = value; }
        }

        #endregion

        #region · Constructors ·

        public ServiceItemQuery()
        {
            this.itemsField = new ArrayList();
        }

        #endregion
    }
}
