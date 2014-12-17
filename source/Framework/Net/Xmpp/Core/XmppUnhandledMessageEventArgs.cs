// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Event args for the <see cref="XmppConnection.UnhandledMessage"/> event.
    /// </summary>
    public sealed class XmppUnhandledMessageEventArgs 
        : EventArgs
    {
        #region · Fields ·

        private object message;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the stanza instance.
        /// </summary>
        /// <value>The stanza instance.</value>
        public object StanzaInstance
        {
            get { return this.message; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppUnhandledMessageEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        internal XmppUnhandledMessageEventArgs(object message)
        {
            this.message = message;
        }

        #endregion
    }
}
