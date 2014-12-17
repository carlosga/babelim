// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Privacy
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:privacy")]
    [XmlRootAttribute("default", Namespace = "jabber:iq:privacy", IsNullable = false)]
    public class Default
    {
        #region · Fields ·

        private string nameField;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("name")]
        public string Name
        {
            get { return this.nameField; }
            set { this.nameField = value; }
        }

        /// <remarks/>
        [XmlTextAttribute(DataType = "NMTOKEN")]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }

        #endregion

        #region · Constructors ·

        public Default()
        {
        }

        #endregion
    }
}
