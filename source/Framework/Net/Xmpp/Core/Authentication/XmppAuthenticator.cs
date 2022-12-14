// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Base class for authentication mechanims implementations.
    /// </summary>
    internal abstract class XmppAuthenticator 
        : IDisposable
    {
        #region · Fields ·

        private XmppConnection connection;
        private string         authenticationError;
        private bool           authenticationFailed;
        private List<string>   pendingMessages;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the authentication error.
        /// </summary>
        /// <value>The authentication error.</value>
        public string AuthenticationError
        {
            get { return this.authenticationError; }
        }

        /// <summary>
        /// Gets a value indicating whether the authentication has failed.
        /// </summary>
        /// <value><c>true</c> if authentication failed; otherwise, <c>false</c>.</value>
        public bool AuthenticationFailed
        {
            get { return this.authenticationFailed; }
            protected set { this.authenticationFailed = value; }
        }

        /// <summary>
        /// Gets the connection associated with the authenticator class.
        /// </summary>
        public XmppConnection Connection
        {
            get { return this.connection; }
        }

        /// <summary>
        /// Gets the list of message ID's pending of response
        /// </summary>
        public List<string> PendingMessages
        {
            get
            {
                if (this.pendingMessages == null)
                {
                    this.pendingMessages = new List<string>();
                }

                return this.pendingMessages;
            }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppAuthenticator"/> class.
        /// </summary>
        /// <param name="connection">A <see cref="XmppConnection"/> instance</param>
        protected XmppAuthenticator(XmppConnection connection)
        {
            this.connection = connection;

            this.Subscribe();
        }

        #endregion

        #region · Finalizers ·

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="T:BabelIm.Net.Xmpp.Core.XmppAuthenticator"/> is reclaimed by garbage collection.
        /// </summary>
        ~XmppAuthenticator()
        {
            this.Dispose(false);
        }

        #endregion

        #region · IDisposable Members ·

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the specified disposing.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Unsubscribe();

                if (this.pendingMessages != null)
                {
                    this.pendingMessages.Clear();
                }

                this.pendingMessages      = null;
                this.connection           = null;
                this.authenticationError  = null;
                this.authenticationFailed = false;
            }
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Performs the authentication.
        /// </summary>
        public abstract void Authenticate();

        #endregion

        #region · Protected Methods ·

        protected void Subscribe()
        {
            this.connection.UnhandledMessage    += new EventHandler<XmppUnhandledMessageEventArgs>(this.OnUnhandledMessage);
            this.connection.AuthenticationError += new EventHandler<XmppAuthenticationFailiureEventArgs>(this.OnAuthenticationError);
        }

        protected void Unsubscribe()
        {
            this.connection.UnhandledMessage    -= new System.EventHandler<XmppUnhandledMessageEventArgs>(this.OnUnhandledMessage);
            this.connection.AuthenticationError -= new System.EventHandler<XmppAuthenticationFailiureEventArgs>(this.OnAuthenticationError);
        }

        #endregion

        #region · Protected Event Handlers ·

        /// <summary>
        /// Called when an unhandled message is received
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="T:BabelIm.Net.Xmpp.Core.XmppUnhandledMessageEventArgs"/> instance containing the event data.</param>        
        protected abstract void OnUnhandledMessage(object sender, XmppUnhandledMessageEventArgs e);

        /// <summary>
        /// Called when an authentication failiure occurs.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="BabelIm.Net.Xmpp.Core.XmppAuthenticationFailiureEventArgs"/> instance containing the event data.</param>
        protected virtual void OnAuthenticationError(object sender, XmppAuthenticationFailiureEventArgs e)
        {
            if (this.pendingMessages != null)
            {
                this.pendingMessages.Clear();
            }

            this.authenticationError  = e.Message;
            this.authenticationFailed = true;
        }

        #endregion
    }
}
