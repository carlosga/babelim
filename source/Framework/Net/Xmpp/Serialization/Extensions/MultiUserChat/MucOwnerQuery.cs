// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.DataForms;
using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat 
{
    /// <summary>
    /// XEP-0045: Multi-User Chat
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace="http://jabber.org/protocol/muc#owner")]
    [XmlRootAttribute("query", Namespace="http://jabber.org/protocol/muc#owner", IsNullable=false)]
    public class MucOwnerQuery
    {
        #region · Fields ·

        private object item;

        #endregion
     
        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("x", typeof(DataForm), Namespace="jabber:x:data")]
        [XmlElementAttribute("destroy", typeof(MucUserDestroy))]
        public object Item
        {
            get { return this.item; }
            set { this.item = value; }
        }

        #endregion

        #region · Constructors ·

        public MucOwnerQuery()
        {
        }

        #endregion
    }    
}
