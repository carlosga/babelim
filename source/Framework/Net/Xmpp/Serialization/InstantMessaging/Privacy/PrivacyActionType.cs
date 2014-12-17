// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Privacy
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:privacy")]
    public enum PrivacyActionType
    {
        /// <remarks/>
        [XmlEnumAttribute("allow")]
        Allow,

        /// <remarks/>
        [XmlEnumAttribute("deny")]
        Deny,
    }
}
