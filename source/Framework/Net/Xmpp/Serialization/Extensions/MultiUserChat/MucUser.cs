// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat.User 
{
    /// <summary>
    /// XEP-0045: Multi-User Chat
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace="http://jabber.org/protocol/muc#user")]
    [XmlRootAttribute("x", Namespace="http://jabber.org/protocol/muc#user", IsNullable=false)]
    public class MucUser 
    {
        #region · Fields ·

        private List<object> items;

        #endregion

        #region · Properties ·
        
        /// <remarks/>
        [XmlElementAttribute("password", typeof(string))]
        [XmlElementAttribute("destroy", typeof(MucUserDestroy))]
        [XmlElementAttribute("invite", typeof(MucUserInvite))]
        [XmlElementAttribute("status", typeof(MucUserStatus))]
        [XmlElementAttribute("decline", typeof(MucUserDecline))]
        [XmlElementAttribute("item", typeof(MucUserItem))]
        public List<object> Items
        {
            get
            {
                if (this.items == null)
                {
                    this.items = new List<object>();
                }
                
                return this.items;
            }
        }

        #endregion

        #region · Constructors ·

        public MucUser()
        {
        }

        #endregion
    }    
}
