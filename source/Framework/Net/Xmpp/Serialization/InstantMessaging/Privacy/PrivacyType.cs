// Copyright (c) Carlos Guzm�n �lvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Privacy
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:privacy")]
    public enum PrivacyType
    {
        /// <remarks/>
        [XmlEnumAttribute("group")]
        Group,

        /// <remarks/>
        [XmlEnumAttribute("jid")]
        JID,

        /// <remarks/>
        [XmlEnumAttribute("subscription")]
        Subscription,
    }
}
