// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.SimpleCommunicationsBlocking
{
    /// <summary>
    /// XEP-0191: Simple Communications Blocking
    /// </summary>
    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:xmpp:blocking")]
    [XmlRootAttribute("item", Namespace = "urn:xmpp:blocking", IsNullable = false)]
    public sealed class BlockItem
    {
        #region · Fields ·

        private string jidField;

        #endregion

        #region · Properties ·

        /// <comentarios/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
            get { return this.jidField; }
            set { this.jidField = value; }
        }

        #endregion
    }
}