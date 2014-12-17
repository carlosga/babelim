// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Privacy
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:privacy")]
    [XmlRootAttribute("item", Namespace = "jabber:iq:privacy", IsNullable = false)]
    public class PrivacyItem
    {
        #region · Fields ·

        private Empty iqField;
        private bool iqFieldSpecified;
        private Empty messageField;
        private bool messageFieldSpecified;
        private Empty presenceinField;
        private bool presenceinFieldSpecified;
        private Empty presenceoutField;
        private bool presenceoutFieldSpecified;
        private PrivacyActionType actionField;
        private int orderField;
        private PrivacyType typeField;
        private bool typeFieldSpecified;
        private string valueField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("iq")]
        public Empty IQ
        {
            get { return this.iqField; }
            set { this.iqField = value; }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool IQSpecified
        {
            get { return this.iqFieldSpecified; }
            set { this.iqFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElement("message")]
        public Empty Message
        {
            get { return this.messageField; }
            set { this.messageField = value; }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool messageSpecified
        {
            get { return this.messageFieldSpecified; }
            set { this.messageFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("presence-in")]
        public Empty PresenceIn
        {
            get { return this.presenceinField; }
            set { this.presenceinField = value; }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool PresenceinSpecified
        {
            get { return this.presenceinFieldSpecified; }
            set { this.presenceinFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("presence-out")]
        public Empty PresenceOut
        {
            get { return this.presenceoutField; }
            set { this.presenceoutField = value; }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool PresenceOutSpecified
        {
            get { return this.presenceoutFieldSpecified; }
            set { this.presenceoutFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("action")]
        public PrivacyActionType Action
        {
            get { return this.actionField; }
            set { this.actionField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("order")]
        public int order
        {
            get { return this.orderField; }
            set { this.orderField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("type")]
        public PrivacyType Type
        {
            get { return this.typeField; }
            set { this.typeField = value; }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool TypeSpecified
        {
            get { return this.typeFieldSpecified; }
            set { this.typeFieldSpecified = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("value")]
        public string Value
        {
            get { return this.valueField; }
            set { this.valueField = value; }
        }

        #endregion

        #region · Constructors ·

        public PrivacyItem()
        {
        }

        #endregion
    }
}
