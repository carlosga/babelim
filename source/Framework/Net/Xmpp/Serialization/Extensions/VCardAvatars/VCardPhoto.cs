// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.VCard
{
    /// <summary>
    /// XEP-0153: vCard-Based Avatars
    /// </summary>
    [XmlTypeAttribute(Namespace = "vcard-temp")]
    [XmlRootAttribute("PHOTO", Namespace = "vcard-temp", IsNullable = false)]
    public class VCardPhoto
    {
        #region · Fields ·

        private string type;
        private byte[] photo;

        #endregion

        #region · Properties ·

        [XmlElement("TYPE")]
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        [XmlElement("BINVAL", DataType="base64Binary")]
        public byte[] Photo
        {
            get { return this.photo; }
            set { this.photo = value; }
        }

        #endregion

        #region · Constructors ·

        public VCardPhoto()
        {
        }

        #endregion
    }
}
