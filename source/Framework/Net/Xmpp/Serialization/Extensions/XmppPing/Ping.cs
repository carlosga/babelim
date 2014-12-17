// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.XmppPing
{
    /// <summary>
    /// XEP-0199: XMPP Ping
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "urn:xmpp:ping")]
    [XmlRootAttribute("ping", Namespace = "urn:xmpp:ping", IsNullable = false)]
    public class Ping
    {
        #region · Constructors ·

        public Ping()
        {
        }

        #endregion
    }
}
