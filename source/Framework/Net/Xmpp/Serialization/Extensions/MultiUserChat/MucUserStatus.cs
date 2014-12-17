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
    [XmlRootAttribute("status", Namespace="http://jabber.org/protocol/muc#user", IsNullable=false)]
    public class MucUserStatus 
    {
        #region · Fields ·

        private int code;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlAttributeAttribute("code")]
        public int Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

        #endregion
        
        #region · Constructors ·

        public MucUserStatus()
        {		
        }
        
        #endregion
    }
}
