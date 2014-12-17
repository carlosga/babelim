// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// Presence states
    /// </summary>
    [Serializable]
    public enum XmppPresenceState
    {
        /// <summary>
        /// Away
        /// </summary>
        Away = 0,
        /// <summary>
        /// Available
        /// </summary>
        Available = 1,
        /// <summary>
        /// Busy
        /// </summary>
        Busy = 2,
        /// <summary>
        /// Extended away ( Idle )
        /// </summary>
        Idle = 4,
        /// <summary>
        /// Invisible
        /// </summary>
        Invisible = 5,
        /// <summary>
        /// Offline
        /// </summary>
        Offline = -1,
    }
}
