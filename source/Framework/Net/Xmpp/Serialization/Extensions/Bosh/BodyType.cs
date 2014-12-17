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
    [XmlTypeAttribute("bodyType", AnonymousType = true, Namespace = "http://jabber.org/protocol/httpbind")]
    public enum BodyType
    {
        [XmlEnumAttribute("error")]
        Error,
        [XmlEnumAttribute("terminate")]
        Terminate,
    }
}
