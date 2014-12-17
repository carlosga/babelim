// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://jabber.org/features/iq-register")]
    [XmlRootAttribute("register", Namespace = "http://jabber.org/features/iq-register", IsNullable = false)]
    public class RegisterIQ
    {
    }
}