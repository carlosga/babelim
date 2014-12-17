// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:client")]
    public enum ErrorType
    {
        /// <remarks/>
        [XmlEnumAttribute("auth")]
        Auth,

        /// <remarks/>
        [XmlEnumAttribute("cancel")]
        Cancel,

        /// <remarks/>
        [XmlEnumAttribute("continue")]
        Continue,

        /// <remarks/>
        [XmlEnumAttribute("modify")]
        Modify,

        /// <remarks/>
        [XmlEnumAttribute("wait")]
        Wait,
    }
}
