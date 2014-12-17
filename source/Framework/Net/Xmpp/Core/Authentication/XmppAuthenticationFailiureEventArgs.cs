// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// EventArgs for the <see cref="XmppConnection.AuthenticationFailiure"/> event.
    /// </summary>
    public sealed class XmppAuthenticationFailiureEventArgs 
        : EventArgs
    {
        #region · Fields ·

        private string message;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the authentication failiure message.
        /// </summary>
        /// <value>The message.</value>
        public string Message
        {
            get { return this.message; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppAuthenticationFailiureEventArgs"/> class.
        /// </summary>
        /// <param name="message">The authentication failiure message.</param>
        internal XmppAuthenticationFailiureEventArgs(string message)
        {
            this.message = message;
        }

        #endregion
    }
}
