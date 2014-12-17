// Copyright (c) Carlos Guzm�n �lvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat 
{
    /// <summary>
    /// XEP-0045: Multi-User Chat
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace="http://jabber.org/protocol/muc#admin")]
    [XmlRootAttribute("actor", Namespace="http://jabber.org/protocol/muc#admin", IsNullable=false)]
    public class MucAdminActor 
    {
    	#region � Fields �

    	private string jid;
        private string value;
        
    	#endregion
        
    	#region � Properties �
        
    	/// <remarks/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
        	get { return this.jid; }
        	set { this.jid = value; }
        }
        
        /// <remarks/>
        [XmlTextAttribute()]
        public string Value
        {
        	get { return this.value; }
        	set { this.value = value;; }
        }

        #endregion
    	
    	#region � Constructors �
    	
    	public MucAdminActor()
    	{
    	}
    	
    	#endregion
    }
}
