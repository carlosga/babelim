// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Roster
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:roster")]
    public enum RosterSubscriptionType
    {
        /// <remarks/>
        [XmlEnumAttribute("both")]
        Both,

        /// <remarks/>
        [XmlEnumAttribute("from")]
        From,

        /// <remarks/>
        [XmlEnumAttribute("none")]
        None,

        /// <remarks/>
        [XmlEnumAttribute("remove")]
        Remove,

        /// <remarks/>
        [XmlEnumAttribute("to")]
        To,
    }
}
