// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// An ID generator for XMPP messages.
    /// </summary>
    public static class XmppIdentifierGenerator
    {
        #region · Static Methods ·

        /// <summary>
        /// Generates a new message ID.
        /// </summary>
        /// <returns>The message ID as a string.</returns>
        public static string Generate()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }

        #endregion
    }
}
