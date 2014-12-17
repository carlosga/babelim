// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.Bosh
{
    /// <summary>
    /// XEP-0124: Bidirectional-streams Over Synchronous HTTP (BOSH)
    /// XEP-0206: XMPP Over BOSH
    /// </summary>
    [SerializableAttribute()]
    [XmlTypeAttribute("bodyCondition", AnonymousType = true, Namespace = "http://jabber.org/protocol/httpbind")]
    public enum BodyCondition
    {
        [XmlEnumAttribute("bad-request")]
        BadRequest,
        [XmlEnumAttribute("host-gone")]
        HostHone,
        [XmlEnumAttribute("host-unknown")]
        HostUnknown,
        [XmlEnumAttribute("improper-addressing")]
        ImproperAddressing,
        [XmlEnumAttribute("internal-server-error")]
        InternalServerError,
        [XmlEnumAttribute("item-not-found")]
        ItemNotFound,
        [XmlEnumAttribute("other-request")]
        OtherRequest,
        [XmlEnumAttribute("policy-violation")]
        PolicyViolation,
        [XmlEnumAttribute("remote-connection-failed")]
        RemoteConnectionFailed,
        [XmlEnumAttribute("remote-stream-error")]
        RemoteStreamError,
        [XmlEnumAttribute("see-other-uri")]
        SeeOtherUri,
        [XmlEnumAttribute("system-shutdown")]
        SystemShutdown,
        [XmlEnumAttribute("undefined-condition")]
        UndefinedCondition,
    }
}
