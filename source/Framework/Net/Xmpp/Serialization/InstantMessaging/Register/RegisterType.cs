// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Register
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:register", IncludeInSchema = false)]
    public enum RegisterType
    {
        /// <remarks/>
        [XmlEnumAttribute("misc")]
        Misc,

        /// <remarks/>
        [XmlEnumAttribute("username")]
        Username,

        /// <remarks/>
        [XmlEnumAttribute("first")]
        First,

        /// <remarks/>
        [XmlEnumAttribute("url")]
        Url,

        /// <remarks/>
        [XmlEnumAttribute("remove")]
        Remove,

        /// <remarks/>
        [XmlEnumAttribute("phone")]
        Phone,

        /// <remarks/>
        [XmlEnumAttribute("name")]
        Name,

        /// <remarks/>
        [XmlEnumAttribute("state")]
        State,

        /// <remarks/>
        [XmlEnumAttribute("registered")]
        Registered,

        /// <remarks/>
        [XmlEnumAttribute("date")]
        Date,

        /// <remarks/>
        [XmlEnumAttribute("key")]
        Key,

        /// <remarks/>
        [XmlEnumAttribute("city")]
        City,

        /// <remarks/>
        [XmlEnumAttribute("instructions")]
        Instructions,

        /// <remarks/>
        [XmlEnumAttribute("zip")]
        Zip,

        /// <remarks/>
        [XmlEnumAttribute("nick")]
        Nick,

        /// <remarks/>
        [XmlEnumAttribute("password")]
        Password,

        /// <remarks/>
        [XmlEnumAttribute("email")]
        Email,

        /// <remarks/>
        [XmlEnumAttribute("address")]
        Address,

        /// <remarks/>
        [XmlEnumAttribute("text")]
        Text,

        /// <remarks/>
        [XmlEnumAttribute("last")]
        Last
    }
}
