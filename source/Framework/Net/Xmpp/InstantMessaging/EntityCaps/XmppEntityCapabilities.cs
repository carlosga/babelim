// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client;
using System;
using System.Linq;
using System.Reactive.Linq;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// Client capabilities (XEP-0115)
    /// </summary>
    public abstract class XmppEntityCapabilities 
        : XmppClientCapabilities
    {
        #region · Consts ·

        /// <summary>
        /// Default hash algorithm name
        /// </summary>
        /// <remarks>
        /// SHA-1
        /// </remarks>
        public static readonly string DefaultHashAlgorithmName = "sha-1";

        #endregion

        #region · Fields ·

        private XmppSession	session;

        #region · Subscriptions ·

        private IDisposable sessionStateSubscription;
        private IDisposable infoQueryErrorSubscription;
        private IDisposable serviceDiscoverySubscription;

        #endregion

        #endregion

        #region · Protected Properties ·

        /// <summary>
        /// Gets the <see cref="XmppSession">Session</see>
        /// </summary>
        protected XmppSession Session
        {
            get { return this.session; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppEntityCapabilities"/> class.
        /// </summary>
        protected XmppEntityCapabilities(XmppSession session)
        	: base()
        {
            this.session = session;

            this.SubscribeToSessionState();
        }

        #endregion

        #region · Message Subscriptions ·

        private void SubscribeToSessionState()
        {
            this.sessionStateSubscription = this.session
                .StateChanged
                .Where(s => s == XmppSessionState.LoggingIn || s == XmppSessionState.LoggingOut)
                .Subscribe
            (
                newState =>
                {
                    if (newState == XmppSessionState.LoggingOut)
                    {
                        this.Subscribe();
                    }
                    else if (newState == XmppSessionState.LoggingOut)
                    {
                        this.Unsubscribe();
                    }
                }
            );
        }

        protected virtual void Subscribe()
        {
            this.infoQueryErrorSubscription = this.session.Connection
                .OnInfoQueryMessage
                .Where(message => message.Type == IQType.Error)
                .Subscribe(message => this.OnQueryErrorMessage(message));

            this.serviceDiscoverySubscription = this.session.Connection
                .OnServiceDiscoveryMessage
                .Subscribe(message => this.OnServiceDiscoveryMessage(message));
        }

        protected virtual void Unsubscribe()
        {
            if (this.infoQueryErrorSubscription != null)
            {
                this.infoQueryErrorSubscription.Dispose();
                this.infoQueryErrorSubscription = null;
            }

            if (this.serviceDiscoverySubscription != null)
            {
                this.serviceDiscoverySubscription.Dispose();
                this.serviceDiscoverySubscription = null;
            }
        }
                
        #endregion

        #region · Message Handlers ·

        protected abstract void OnServiceDiscoveryMessage(IQ message);

        protected virtual void OnQueryErrorMessage(IQ message)
        {
        }

        #endregion
    }
}
