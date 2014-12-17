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
    [XmlTypeAttribute(Namespace="http://jabber.org/protocol/muc")]
    [XmlRootAttribute("history", Namespace="http://jabber.org/protocol/muc", IsNullable=false)]
    public class MucHistory 
    {
    	#region · Fields ·

    	private int 		maxchars;
        private bool 		maxcharsSpecified;
        private int 		maxstanzas;
        private bool 		maxstanzasSpecified;
        private int 		seconds;
        private bool 		secondsSpecified;
        private DateTime 	since;
        private bool 		sinceSpecified;
        private string 		value;
    	
    	#endregion
    	
    	#region · Properties ·
    	
        /// <remarks/>
        [XmlAttributeAttribute("maxchars")]
        public int Maxchars
        {
        	get { return this.maxchars; }
        	set 
        	{
        		this.maxchars 			= value; 
        		this.maxcharsSpecified 	= true;
        	}
        }
        
        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool MaxcharsSpecified
        {
        	get { return this.maxcharsSpecified; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("maxstanzas")]
        public int Maxstanzas
        {
        	get { return this.maxstanzas; }
        	set 
        	{
        		this.maxstanzas = value;
        		this.maxstanzasSpecified = true;
        	}
        }
        
        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool MaxstanzasSpecified
        {
        	get { return this.maxstanzasSpecified; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("seconds")]
        public int Seconds
        {
        	get { return this.seconds; }
        	set 
        	{
        		this.seconds 			= value;
        		this.secondsSpecified 	= true;
        	}
        }
        
        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool SecondsSpecified
        {
        	get { return this.secondsSpecified; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("since")]
        public DateTime Since
        {
        	get { return this.since; }
        	set 
        	{
        		this.since 			= value;
        		this.sinceSpecified = true;
        	}
        }
        
        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool SinceSpecified
        {
        	get { return this.sinceSpecified; }
        }
        
        /// <remarks/>
        [XmlTextAttribute()]
        public string Value
        {
        	get { return this.value; }
        	set { this.value = value; }
        }
        
        #endregion
        
        #region · Constructors ·
        
        public MucHistory()
        {
        }
        
        #endregion
    }
}
