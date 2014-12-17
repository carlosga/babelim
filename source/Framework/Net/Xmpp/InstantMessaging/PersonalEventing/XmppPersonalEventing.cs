// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Core;
using BabelIm.Net.Xmpp.Serialization.Extensions.ServiceDiscovery;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace BabelIm.Net.Xmpp.InstantMessaging.PersonalEventing
{
    /// <summary>
    /// XMPP Personal Eventing
    /// </summary>
    public sealed class XmppPersonalEventing 
        : ObservableObject
    {
        #region · Fields ·

        private XmppSession				session;
        private List<string>			features;
        private List<string>			pendingMessages;
        private AmipNowPlayingListerner	nowPlayingListener;
        private bool                    isUserTuneEnabled;

        #region · Subscriptions ·

        private IDisposable sessionStateSubscription;
        private IDisposable infoQueryErrorSubscription;
        private IDisposable serviceDiscoverySubscription;

        #endregion

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the collection of features ( if personal eventing is supported )
        /// </summary>
        public IEnumerable<string> Features
        {
            get 
            {
                foreach (string feature in this.features)
                {
                    yield return feature;
                }
            }
        }
        
        /// <summary>
        /// Gets a value that indicates if it supports user tunes
        /// </summary>
        public bool SupportsUserTune
        {
            get { return this.SupportsFeature(XmppFeatures.UserTune); }
        }
        
        /// <summary>
        /// Gets a value that indicates if it supports user moods
        /// </summary>
        public bool SupportsUserMood
        {
            get { return this.SupportsFeature(XmppFeatures.UserMood); }
        }

        /// <summary>
        /// Gets or sets a value that indicates if user tune is enabled
        /// </summary>
        public bool IsUserTuneEnabled
        {
            get { return this.isUserTuneEnabled; }
            set
            {
                if (this.isUserTuneEnabled != value)
                {
                    this.isUserTuneEnabled = value;
                    this.NotifyPropertyChanged(() => IsUserTuneEnabled);
                }
            }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppServiceDiscovery"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        internal XmppPersonalEventing(XmppSession session)
        {
            this.session            = session;
            this.pendingMessages    = new List<string>();
            this.features           = new List<string>();
            this.nowPlayingListener	= new AmipNowPlayingListerner(this.session);

            this.SubscribeToSessionState();
        }
        
        #endregion

        #region · Internal Methods ·

        /// <summary>
        /// Discover if we have personal eventing support enabled
        /// </summary>
        /// <returns></returns>
        internal void DiscoverSupport()
        {
            ServiceItemQuery	query   = new ServiceItemQuery();
            IQ                  iq      = new IQ();

            iq.ID   = XmppIdentifierGenerator.Generate();
            iq.Type = IQType.Get;
            iq.From = this.session.UserId;
            iq.To   = this.session.UserId.BareIdentifier;

            iq.Items.Add(query);

            this.pendingMessages.Add(iq.ID);
            this.features.Clear();

            this.session.Send(iq);
        }
        
        #endregion
        
        #region · Private Methods ·
        
        private bool SupportsFeature(string featureName)
        {
            var q = from feature in this.features
                    where feature == featureName
                    select feature;
            
            return (q.Count() > 0);
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
                        this.features.Clear();
                        this.pendingMessages.Clear();
                        this.nowPlayingListener.Stop();
                        this.Unsubscribe();
                    }
                }
            );
        }

        private void Subscribe()
        {
            this.infoQueryErrorSubscription = this.session.Connection
                .OnInfoQueryMessage
                .Where(iq => iq.Type == IQType.Error)
                .Subscribe(message => this.OnQueryErrorMessage(message));

            this.infoQueryErrorSubscription = this.session.Connection
                .OnServiceDiscoveryMessage
                .Where(message => message.Type == IQType.Result && this.pendingMessages.Contains(message.ID))
                .Subscribe(message => this.OnServiceDiscoveryMessage(message));
        }

        private void Unsubscribe()
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

        private void OnServiceDiscoveryMessage(IQ message)
        {
            this.pendingMessages.Remove(message.ID);

            foreach (ServiceItemQuery item in message.Items)
            {
                foreach (ServiceItem sitem in item.Items)
                {
                    this.features.Add(sitem.Node);
                }

                this.NotifyPropertyChanged(() => SupportsUserTune);
                this.NotifyPropertyChanged(() => SupportsUserMood);
                    
                if (this.SupportsUserTune)
                {
                    this.nowPlayingListener.Start();
                }
            }
        }

        private void OnQueryErrorMessage(IQ message)
        {
            if (this.pendingMessages.Contains(message.ID))
            {
                this.pendingMessages.Remove(message.ID);
            }
        }

        #endregion
    }
}
