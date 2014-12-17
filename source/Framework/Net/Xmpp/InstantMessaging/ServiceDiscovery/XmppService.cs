// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

namespace BabelIm.Net.Xmpp.InstantMessaging.ServiceDiscovery
{
    /// <summary>
    /// Represents a XMPP Service
    /// </summary>
    public class XmppService
        : XmppServiceDiscoveryObject
    {
        #region · Constructors ·

        internal XmppService(XmppSession session, string identifier)
            : base(session, identifier)
        {
        }

        #endregion
    }
}
