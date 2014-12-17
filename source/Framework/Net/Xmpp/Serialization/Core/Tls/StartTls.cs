// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Tls
{
    [Serializable]
    [XmlTypeAttribute(Namespace = "urn:ietf:params:xml:ns:xmpp-tls")]
    [XmlRootAttribute("starttls", Namespace = "urn:ietf:params:xml:ns:xmpp-tls", IsNullable = false)]
    public class StartTls
    {
        #region · Constructors ·

        public StartTls()
        {
        }

        #endregion
    }
}
