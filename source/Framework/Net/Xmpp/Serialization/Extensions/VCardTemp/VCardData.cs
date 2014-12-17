// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.VCard
{
    /// <summary>
    /// XEP-0054: vcard-temp
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "vcard-temp")]
    [XmlRoot("x", Namespace = "vcard-temp", IsNullable = false)]
    public class VCardData
    {
        #region · Fields ·

        private string nickName;
        private string jabberId;
        private VCardPhoto photo;

        #endregion

        #region · Properties ·

        [XmlElement("NICKNAME")]
        public string NickName
        {
            get { return this.nickName; }
            set { this.nickName = value; }
        }

        [XmlElement("JABBERID")]
        public string JabberId
        {
            get { return this.jabberId; }
            set { this.jabberId = value; }
        }

        [XmlElement("PHOTO")]
        public VCardPhoto Photo
        {
            get 
            {
                if (this.photo == null)
                {
                    this.photo = new VCardPhoto();
                }
                return this.photo; 
            }
            set { this.photo = value; }
        }

        #endregion

        #region · Constructors ·

        public VCardData()
        {
        }

        #endregion
    }
}
