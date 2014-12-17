// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Privacy
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:privacy")]
    [XmlRootAttribute("query", Namespace = "jabber:iq:privacy", IsNullable = false)]
    public class PrivacyQuery
    {
        #region · Fields ·

        private Active activeField;
        private Default defaultField;
        private PrivacyList[] listField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElement("active")]
        public Active Active
        {
            get { return this.activeField; }
            set { this.activeField = value; }
        }

        /// <remarks/>
        [XmlElement("default")]
        public Default Default
        {
            get { return this.defaultField; }
            set { this.defaultField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("list")]
        public PrivacyList[] List
        {
            get { return this.listField; }
            set { this.listField = value; }
        }

        #endregion

        #region · Constructors ·

        public PrivacyQuery()
        {
        }

        #endregion
    }
}
