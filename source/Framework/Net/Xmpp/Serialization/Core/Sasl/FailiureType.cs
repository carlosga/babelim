// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Sasl
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:xmpp-sasl", IncludeInSchema = false)]
    public enum FailiureType
    {
        /// <remarks/>
        [XmlEnumAttribute("not-authorized")]
        NotAuthorized,

        /// <remarks/>
        [XmlEnumAttribute("mechanism-too-weak")]
        MechanismTooWeak,

        /// <remarks/>
        [XmlEnumAttribute("temporary-auth-failure")]
        TemporaryAuthFailure,

        /// <remarks/>
        [XmlEnumAttribute("invalid-authzid")]
        InvalidAuthzid,

        /// <remarks/>
        [XmlEnumAttribute("aborted")]
        Aborted,

        /// <remarks/>
        [XmlEnumAttribute("incorrect-encoding")]
        IncorrectEncoding,

        /// <remarks/>
        [XmlEnumAttribute("invalid-mechanism")]
        InvalidMechanism,
    }
}
