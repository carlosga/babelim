// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat
{
    /// <summary>
    /// XEP-0045: Multi-User Chat
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace="http://jabber.org/protocol/muc#user")]
    [XmlRootAttribute("decline", Namespace="http://jabber.org/protocol/muc#user", IsNullable=false)]
    public class MucUserDecline 
    {
    	#region · Fields ·
        
        private string reason;
        private string from;
        private string to;

        #endregion
    	
    	#region · Properties ·
    	
        /// <remarks/>
        [XmlElementAttribute("reason")]
        public string Reason
        {
        	get { return this.reason; }
        	set { this.reason = value; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("from")]
        public string From
        {
        	get { return this.from; }
        	set { this.from = value; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("to")]
        public string To
        {
        	get { return this.to; }
        	set { this.to = value; }
        }
    	
    	#endregion
    	
    	#region · Constructors ·
    	
    	public MucUserDecline()
    	{
    	}
    	
    	#endregion    	
    }
}
