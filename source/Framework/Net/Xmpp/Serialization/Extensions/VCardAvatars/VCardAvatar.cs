// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.VCard
{
    /// <summary>
    /// XEP-0153: vCard-Based Avatars
    /// </summary>
    [Serializable]
    [XmlType(Namespace = "vcard-temp:x:update")]
    [XmlRoot("x", Namespace = "vcard-temp:x:update", IsNullable = false)]
    public class VCardAvatar
    {
        #region · Fields ·

        private string photo;

        #endregion

        #region · Properties ·

        [XmlElement("photo")]
        public string Photo
        {
            get { return this.photo; }
            set { this.photo = value; }
        }

        #endregion

        #region · Constructors ·

        public VCardAvatar()
        {
        }

        #endregion
    }
}
