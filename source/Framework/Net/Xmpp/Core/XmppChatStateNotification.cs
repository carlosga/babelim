// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Chat state notification types
    /// </summary>
    [Serializable]
    public enum XmppChatStateNotification
    {
        /// <summary>
        /// No notification
        /// </summary>
        None,
        /// <summary>
        /// The user is active
        /// </summary>
        Active,
        /// <summary>
        /// The user is composing a new message
        /// </summary>
        Composing,
        /// <summary>
        /// The user is "paused"
        /// </summary>
        Paused,
        /// <summary>
        /// The user is inactive
        /// </summary>
        Inactive,
        /// <summary>
        /// The user is gone
        /// </summary>
        Gone
    }
}
