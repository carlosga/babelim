// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Core.Sasl;
using System;
using System.Text;
using System.Threading;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// <see cref="XmppAuthenticator" /> implementation for the SASL Plain Authentication mechanism.
    /// </summary>
    /// <remarks>
    /// References:
    ///     http://www.ietf.org/html.charters/sasl-charter.html
    ///     http://www.ietf.org/internet-drafts/draft-ietf-sasl-plain-09.txt
    /// </remarks>
    internal sealed class XmppSaslPlainAuthenticator 
        : XmppAuthenticator
    {
        #region · Fields ·

        private AutoResetEvent waitEvent;

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppSaslPlainAuthenticator"/> class.
        /// </summary>
        public XmppSaslPlainAuthenticator(XmppConnection connection) 
            : base(connection)
        {
            this.waitEvent = new AutoResetEvent(false);
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Performs the authentication using the SASL Plain authentication mechanism.
        /// </summary>
        public override void Authenticate()
        {
            // Send authentication mechanism
            Auth auth = new Auth();

            auth.Mechanism  = XmppCodes.SaslPlainMechanism;
            auth.Value      = this.BuildMessage();

            this.Connection.Send(auth);

            this.waitEvent.WaitOne();

            if (!this.AuthenticationFailed)
            {
                // Re-Initialize XMPP Stream
                this.Connection.InitializeXmppStream();

                // Wait until we receive the Stream features
                this.Connection.WaitForStreamFeatures();
            }
        }

        #endregion

        #region · Protected Methods ·

        protected override void OnUnhandledMessage(object sender, XmppUnhandledMessageEventArgs e)
        {
            if (e.StanzaInstance is Success)
            {
                this.waitEvent.Set();
            }
        }

        protected override void OnAuthenticationError(object sender, XmppAuthenticationFailiureEventArgs e)
        {
            base.OnAuthenticationError(sender, e);

            this.waitEvent.Set();
        }

        #endregion

        #region · Private Methods ·

        private string BuildMessage()
        {
            string message  = String.Format("\0{0}\0{1}", this.Connection.UserId.BareIdentifier, this.Connection.UserPassword);

            return Encoding.UTF8.GetBytes(message).ToBase64String();
        }

        #endregion
    }
}
