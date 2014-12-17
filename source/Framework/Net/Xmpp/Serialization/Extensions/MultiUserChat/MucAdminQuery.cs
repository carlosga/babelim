// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat
{
    /// <summary>
    /// XEP-0045: Multi-User Chat
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace="http://jabber.org/protocol/muc#admin")]
    [XmlRootAttribute("query", Namespace="http://jabber.org/protocol/muc#admin", IsNullable=false)]
    public class MucAdminQuery 
    {
    	#region · Fields ·

        private List<MucAdminItem> items;
    	
    	#endregion
    	
    	#region · Properties ·
    	
        /// <remarks/>
        [XmlElementAttribute("item")]
        public List<MucAdminItem> Items
        {
        	get 
        	{ 
        		if (this.items == null)
        		{
        			this.items = new List<MucAdminItem>();
        		}
        		return this.items;
        	}
        }
        
        #endregion
        
        #region · Constructors ·
        
        public MucAdminQuery()
        {
        }
        
        #endregion
    }
}