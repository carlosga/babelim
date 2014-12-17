// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client.Presence
{
    /// <remarks/>
    [Serializable]
    [XmlType(Namespace = "jabber:client")]
    [XmlRoot("show", Namespace = "jabber:client", IsNullable = false)]
    public enum ShowType
    {
        /// <remarks/>
        [XmlEnumAttribute("away")]
        Away = 0,

        /// <remarks/>
        [XmlEnumAttribute("chat")]
        Online = 1,

        /// <remarks/>
        [XmlEnumAttribute("dnd")]
        Busy = 2,

        /// <remarks/>
        [XmlEnumAttribute("xa")]
        ExtendedAway = 4
    }
}
