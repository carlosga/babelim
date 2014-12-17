// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

namespace BabelIm.Net.Xmpp.InstantMessaging.ServiceDiscovery
{
    /// <summary>
    /// Represents a <see cref="XmppService"/> item.
    /// </summary>
    public sealed class XmppServiceItem
        : XmppServiceDiscoveryObject
    {
        #region · Constructors ·

        internal XmppServiceItem(XmppSession session, string identifier)
            : base(session, identifier)
        {
        }

        #endregion
    }
}
