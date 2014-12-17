// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client.Presence
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:client")]
    public enum PresenceType
    {
        /// <remarks/>
        [XmlEnumAttribute("error")]
        Error,

        /// <remarks/>
        [XmlEnumAttribute("probe")]
        Probe,

        /// <remarks/>
        [XmlEnumAttribute("subscribe")]
        Subscribe,

        /// <remarks/>
        [XmlEnumAttribute("subscribed")]
        Subscribed,

        /// <remarks/>
        [XmlEnumAttribute("unavailable")]
        Unavailable,

        /// <remarks/>
        [XmlEnumAttribute("unsubscribe")]
        Unsubscribe,

        /// <remarks/>
        [XmlEnumAttribute("unsubscribed")]
        Unsubscribed,
    }
}
