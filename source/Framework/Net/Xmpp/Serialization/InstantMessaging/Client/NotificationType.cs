// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/chatstates")]
    public class NotificationActive
    {
        #region · Constructors ·
        
        public NotificationActive()
        {
        }
        
        #endregion
    }
    
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/chatstates")]
    public class NotificationComposing
    {
        #region · Constructors ·
        
        public NotificationComposing()
        {
        }
        
        #endregion
    }	

    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/chatstates")]
    public class NotificationGone
    {
        #region · Constructors ·
        
        public NotificationGone()
        {
        }
        
        #endregion
    }	

    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/chatstates")]
    public class NotificationInactive
    {
        #region · Constructors ·
        
        public NotificationInactive()
        {
        }
        
        #endregion
    }	

    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/chatstates")]
    public class NotificationPaused
    {
        #region · Constructors ·
        
        public NotificationPaused()
        {
        }
        
        #endregion
    }	
}
