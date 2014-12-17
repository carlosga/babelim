// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:client")]
    public enum IQType
    {
        /// <remarks/>
        [XmlEnumAttribute("error")]
        Error,

        /// <remarks/>
        [XmlEnumAttribute("get")]
        Get,

        /// <remarks/>
        [XmlEnumAttribute("result")]
        Result,

        /// <remarks/>
        [XmlEnumAttribute("set")]
        Set,
    }
}
