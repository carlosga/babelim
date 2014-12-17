// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "jabber:iq:browse")]
    [XmlRootAttribute("query", Namespace = "jabber:iq:browse", IsNullable = false)]
    public class Browse
    {
        #region · Constructors ·

        public Browse()
        {
        }

        #endregion
    }
}
