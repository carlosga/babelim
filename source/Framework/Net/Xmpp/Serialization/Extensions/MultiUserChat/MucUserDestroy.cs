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
    [XmlRootAttribute("destroy", Namespace="http://jabber.org/protocol/muc#user", IsNullable=false)]
    public class MucUserDestroy 
    {
        #region · Fields ·

        private string reason;        
        private string jid;

        #endregion

        #region · Properties ·
        
        /// <remarks/>
        [XmlText()]
        public string Reason
        {
            get { return this.reason; }
            set { this.reason = value; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("jid")]
        public string Jid
        {
            get { return this.jid; }
            set { this.jid = value; }
        }

        #endregion

        #region · Constructors ·

        public MucUserDestroy()
        {
        }

        #endregion
    }
}
