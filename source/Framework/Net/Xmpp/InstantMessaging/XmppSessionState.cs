// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// Session states
    /// </summary>
    [Serializable]
    public enum XmppSessionState
    {
        /// <summary>
        /// Loggin out
        /// </summary>
        LoggingOut,
        /// <summary>
        /// Logged out
        /// </summary>
        LoggedOut,
        /// <summary>
        /// Logging in
        /// </summary>
        LoggingIn,
        /// <summary>
        /// Logged in
        /// </summary>
        LoggedIn,
        /// <summary>
        /// Error
        /// </summary>
        Error,
    }
}
