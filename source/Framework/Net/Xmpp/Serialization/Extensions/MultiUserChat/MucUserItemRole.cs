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
    public enum MucUserItemRole 
    {
        /// <remarks/>
        [XmlEnumAttribute("moderator")]
        Moderator,
        
        /// <remarks/>
        [XmlEnumAttribute("none")]
        None,
        
        /// <remarks/>
        [XmlEnumAttribute("participant")]
       	Participant,
        
        /// <remarks/>
        [XmlEnumAttribute("visitor")]
        Visitor,
    }
}
