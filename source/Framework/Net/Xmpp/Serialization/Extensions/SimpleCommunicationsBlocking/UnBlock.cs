// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.SimpleCommunicationsBlocking
{
    /// <summary>
    /// XEP-0191: Simple Communications Blocking
    /// </summary>
    [SerializableAttribute()]
    [XmlTypeAttribute(AnonymousType = true, Namespace = "urn:xmpp:blocking")]
    [XmlRootAttribute("unblock", Namespace = "urn:xmpp:blocking", IsNullable = false)]
    public sealed class UnBlock
    {
        #region · Fields ·

        private List<BlockItem> itemsField;

        #endregion

        #region · Properties ·

        [XmlElementAttribute("item", Type = typeof(BlockItem), Namespace = "urn:xmpp:blocking")]
        public List<BlockItem> Items
        {
            get { return this.itemsField; }
            set { this.itemsField = value; }
        }

        #endregion
    }
}