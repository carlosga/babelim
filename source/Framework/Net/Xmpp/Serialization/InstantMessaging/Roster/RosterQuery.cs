// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Roster
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:roster")]
    [XmlRootAttribute("query", Namespace = "jabber:iq:roster", IsNullable = false)]
    public class RosterQuery
    {
        #region · Fields ·

        private RosterItemCollection itemsField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("item")]
        public RosterItemCollection Items
        {
            get { return this.itemsField; }
        }

        #endregion

        #region · Constructors ·

        public RosterQuery()
        {
            this.itemsField = new RosterItemCollection();
        }

        #endregion
    }
}
