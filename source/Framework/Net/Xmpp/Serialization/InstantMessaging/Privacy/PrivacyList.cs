// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Privacy
{
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:privacy")]
    [XmlRootAttribute("list", Namespace = "jabber:iq:privacy", IsNullable = false)]
    public class PrivacyList
    {
        #region · Fields ·

        private System.Collections.ArrayList itemField;
        private string nameField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("item", Type = typeof(PrivacyItem))]
        public System.Collections.ArrayList Items
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        #endregion

        #region · Constructors ·

        public PrivacyList()
        {
        }

        #endregion
    }
}
