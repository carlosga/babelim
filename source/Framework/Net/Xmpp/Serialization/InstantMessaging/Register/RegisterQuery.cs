// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Register
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:register")]
    [XmlRootAttribute("query", Namespace = "jabber:iq:register", IsNullable = false)]
    public class RegisterQuery
    {
        #region · Fields ·

        private string usernameField;
        private string passwordField;
        private string removeField;
        // private object itemField;
        // private RegisterType itemElementNameField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("username")]
        public string UserName
        {
            get { return this.usernameField; }
            set { this.usernameField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("password", typeof(string))]
        public string Password
        {
            get { return this.passwordField; }
            set { this.passwordField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("remove", typeof(string))]
        public string Remove
        {
            get { return this.removeField; }
            set { this.removeField = value; }
        }

        /*
        /// <remarks/>
        [XmlElementAttribute("misc", typeof(string))]
        [XmlElementAttribute("username", typeof(string))]
        [XmlElementAttribute("first", typeof(string))]
        [XmlElementAttribute("url", typeof(string))]
        [XmlElementAttribute("remove", typeof(Empty))]
        [XmlElementAttribute("phone", typeof(string))]
        [XmlElementAttribute("name", typeof(string))]
        [XmlElementAttribute("state", typeof(string))]
        [XmlElementAttribute("registered", typeof(Empty))]
        [XmlElementAttribute("date", typeof(string))]
        [XmlElementAttribute("key", typeof(string))]
        [XmlElementAttribute("city", typeof(string))]
        [XmlElementAttribute("instructions", typeof(string))]
        [XmlElementAttribute("zip", typeof(string))]
        [XmlElementAttribute("nick", typeof(string))]
        [XmlElementAttribute("password", typeof(string))]
        [XmlElementAttribute("email", typeof(string))]
        [XmlElementAttribute("address", typeof(string))]
        [XmlElementAttribute("text", typeof(string))]
        [XmlElementAttribute("last", typeof(string))]
        [XmlChoiceIdentifierAttribute("ItemElementName")]
        public object Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public RegisterType Type
        {
            get { return this.itemElementNameField; }
            set { this.itemElementNameField = value; }
        }
        */

        #endregion
    }
}
