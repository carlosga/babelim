// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.InstantMessaging.MultiUserChat
{
    /// <summary>
    /// Chat Room Supported Features 
    /// </summary>
    [Flags]
    public enum XmppChatRoomFeatures
    {
        /// <summary>
        /// Public
        /// </summary>
        Public              = 1,
        /// <summary>
        /// Persistent
        /// </summary>
        Persistent          = 2,
        /// <summary>
        /// Open
        /// </summary>
        Open                = 4,
        /// <summary>
        /// Semi Anonymous
        /// </summary>
        SemiAnonymous       = 8,
        /// <summary>
        /// Unmoderated
        /// </summary>
        Unmoderated         = 16,
        /// <summary>
        /// Unsecured
        /// </summary>
        Unsecured           = 32,
        /// <summary>
        /// Hidden
        /// </summary>
        Hidden              = 64,
        /// <summary>
        /// Password Protected
        /// </summary>
        PasswordProtected   = 128,
        /// <summary>
        /// Temporary
        /// </summary>
        Temporary           = 256,
        /// <summary>
        /// NonAnonymous
        /// </summary>
        NonAnonymous        = 512
    }
}
