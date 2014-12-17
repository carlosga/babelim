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
    [XmlTypeAttribute(Namespace="http://jabber.org/protocol/muc#admin")]
    [XmlRootAttribute("item", Namespace="http://jabber.org/protocol/muc#admin", IsNullable=false)]
    public class MucAdminItem 
    {
    	#region · Fields ·
    	
        private MucAdminActor 			actor;
        private string                  reason;
        private MucAdminContinue        muccontinue;
        private MucAdminItemAffiliation affiliation;
        private bool                    affiliationSpecified;
        private string                  jid;
        private string                  nick;
        private MucAdminItemRole        role;
        private bool                    roleSpecified;
    	
    	#endregion
    	
    	#region · Properties ·
    	
        /// <remarks/>
        [XmlElement("actor")]
        public MucAdminActor Actor
        {
        	get { return this.actor; }
        	set { this.actor = value; }
        }
        
        /// <remarks/>
        [XmlElement("reason")]
        public string Reason
        {
        	get { return this.reason; }
        	set { this.reason = value; }
        }
        
        /// <remarks/>
        [XmlElement("continue")]
        public MucAdminContinue Continue
        {
        	get { return this.muccontinue; }
        	set { this.muccontinue = value; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("affiliation")]
        public MucAdminItemAffiliation Affiliation
        {
        	get { return this.affiliation; }
        	set 
        	{ 
        		this.affiliation 			= value;
        		this.affiliationSpecified 	= true;
        	}
        }
        
        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool AffiliationSpecified
        {
        	get { return this.affiliationSpecified; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
        	get { return this.jid; }
        	set { this.jid = value; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("nick")]
        public string Nick
        {
        	get { return this.nick; }
        	set { this.nick = value; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("role")]
        public MucAdminItemRole Role
        {
        	get { return this.role; }
        	set 
        	{ 
        		this.role 			= value;
        		this.roleSpecified	= true;
        	}
        }
        
        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool RoleSpecified
        {
        	get { return this.roleSpecified; }
        }
    	
    	#endregion
    	
    	#region · Constructors ·
    	
    	public MucAdminItem()
    	{
    	}
    	
    	#endregion
    }
}
