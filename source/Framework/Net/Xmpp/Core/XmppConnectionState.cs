// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Describes the current state of the connection to a XMPP Server.
    /// </summary>
    [Serializable]
    public enum XmppConnectionState
    {
        /// <summary>
        /// The connection is being closed.
        /// </summary>
        Closing,

        /// <summary>
        /// The connection is closed.
        /// </summary>
        Closed,

        /// <summary>
        /// The connection is being opened
        /// </summary>
        Opening,
        
        /// <summary>
        /// The connection is open and the authentication has been done correctly.
        /// </summary>
        Open,
    }
}
