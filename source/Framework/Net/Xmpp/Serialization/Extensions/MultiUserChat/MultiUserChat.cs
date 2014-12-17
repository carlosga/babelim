// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat 
{
    /// <summary>
    /// XEP-0045: Multi-User Chat
    /// </summary>
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/muc")]
    [XmlRootAttribute("x", Namespace="http://jabber.org/protocol/muc", IsNullable=false)]
    public class Muc
    {        
    	#region · Fields ·
    	    	
        private MucHistory  history;
        private string      password;
    	
    	#endregion
    	
    	#region · Properties ·
    	
        /// <remarks/>
        [XmlElementAttribute("history")]
        public MucHistory History
        {
        	get { return this.history; }
        	set { this.history = value; }
        }
        
        /// <remarks/>
        [XmlElementAttribute("password")]
        public string Password
        {
        	get { return this.password; }
        	set { this.password = value; }
        }
        
        #endregion
        
        #region · Constructors ·
        
        public Muc()
        {
        }
        
        #endregion
    }    
}
