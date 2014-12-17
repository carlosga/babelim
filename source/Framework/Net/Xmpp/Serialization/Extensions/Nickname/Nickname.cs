// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.Nickname
{
    /// <summary>
    /// XEP-0172: User Nickname
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/nick")]
    [XmlRootAttribute("nick", Namespace = "http://jabber.org/protocol/nick", IsNullable = false)]
    public class Nickname
    {
        #region · Fields ·

        private string nick;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("nick", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://jabber.org/protocol/nick")]
        public string Nick
        {
            get { return this.nick; }
            set { this.nick = value; }
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

        public Nickname()
        {
        }

        #endregion
    }
}
