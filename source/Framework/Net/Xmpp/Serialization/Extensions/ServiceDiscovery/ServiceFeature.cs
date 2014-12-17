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
    [XmlRootAttribute("feature", Namespace = "http://jabber.org/protocol/disco#info", IsNullable = false)]
    public class ServiceFeature
    {
        #region · Fields ·

        private string name;
        // private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("var")]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /*
        /// <remarks/>
        [XmlTextAttribute()]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }
        */

        #endregion

        #region · Constructors

        public ServiceFeature()
        {
        }

        #endregion
    }
}
