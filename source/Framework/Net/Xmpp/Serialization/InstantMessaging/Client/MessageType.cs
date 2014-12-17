// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:client")]
    public enum MessageType
    {
        /// <remarks/>
        [XmlEnumAttribute("chat")]
        Chat,

        /// <remarks/>
        [XmlEnumAttribute("error")]
        Error,

        /// <remarks/>
        [XmlEnumAttribute("groupchat")]
        GroupChat,

        /// <remarks/>
        [XmlEnumAttribute("headline")]
        Headline,

        /// <remarks/>
        [XmlEnumAttribute("normal")]
        Normal,
    }
}
