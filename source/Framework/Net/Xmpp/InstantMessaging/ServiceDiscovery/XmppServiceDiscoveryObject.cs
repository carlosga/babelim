// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Core;
using BabelIm.Net.Xmpp.Serialization.Extensions.ServiceDiscovery;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;

namespace BabelIm.Net.Xmpp.InstantMessaging.ServiceDiscovery
{
    public abstract class XmppServiceDiscoveryObject
        : ObservableObject
    {
        #region · Fields ·

        private List<XmppServiceIdentity>   identities;
        private bool                        featuresRequested;
        private bool                        itemsRequested;
        private XmppSession                 session;
        private XmppJid                     identifier;
        private AutoResetEvent              waitEvent;
        private List<XmppServiceItem>       items;
        private List<XmppServiceFeature>    features;
        private List<string>                pendingMessages;

        #region · Subscriptions ·

        private IDisposable sessionStateSubscription;
        private IDisposable infoQuerySubscription;
        private IDisposable serviceDiscoverySubscription;

        #endregion

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the XMPP Identifier (JID)
        /// </summary>
        public XmppJid Identifier
        {
            get { return this.identifier; }
        }

        /// <summary>
        /// Gets the object identity.
        /// </summary>
        public List<XmppServiceIdentity> Identities
        {
            get
            {
                if (!this.featuresRequested)
                {
                    this.DiscoverFeatures();
                }

                return this.identities;
            }
        }

        /// <summary>
        /// Gets the list of features supported by the XMPP Service
        /// </summary>
        public List<XmppServiceFeature> Features
        {
            get
            {
                if (!this.featuresRequested)
                {
                    this.DiscoverFeatures();
                }

                return this.features;
            }
        }

        /// <summary>
        /// Gets the list of items for the XMPP Service
        /// </summary>
        public List<XmppServiceItem> Items
        {
            get 
            {
                if (!this.itemsRequested)
                {
                    this.DiscoverItems();
                }

                return this.items;
            }
        }

        #endregion

        #region · Protected Properties ·

        /// <summary>
        /// Gets the Xmpp Session
        /// </summary>
        protected XmppSession Session
        {
            get { return this.session; }
        }

        /// <summary>
        /// Gets the list of message id's pending of response
        /// </summary>
        protected List<string> PendingMessages
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
        /// Initializes a new instance of the <see cref="XmppServiceDiscoveryObject"/> class.
        /// </summary>
        protected XmppServiceDiscoveryObject(XmppSession session, string identifier)
        {
            this.session    = session;
            this.identifier = identifier;
            this.waitEvent  = new AutoResetEvent(false);

            this.Subscribe();
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Discover item features
        /// </summary>
        /// <param name="serviceJid"></param>
        public virtual void DiscoverFeatures()
        {
            if (this.features == null)
            {
                this.features = new List<XmppServiceFeature>();
            }
            else
            {
                this.features.Clear();
            }

            // Get Service Info
            IQ iq = new IQ
            {
                ID   = XmppIdentifierGenerator.Generate(),
                Type = IQType.Get,
                From = this.session.UserId,
                To   = this.Identifier
            };

            iq.Items.Add(new ServiceQuery());

            this.featuresRequested = true;
            this.PendingMessages.Add(iq.ID);
            this.session.Send(iq);

            this.waitEvent.WaitOne();
        }

        /// <summary>
        /// Discover item items.
        /// </summary>
        public virtual void DiscoverItems()
        {
            if (!this.featuresRequested)
            {
                this.DiscoverFeatures();
            }

            if (this.items == null)
            {
                this.items = new List<XmppServiceItem>();
            }
            else
            {
                this.items.Clear();
            }

            // Get Service Details
            IQ iq = new IQ
            {
                ID      = XmppIdentifierGenerator.Generate(),
                Type    = IQType.Get,
                From    = this.session.UserId,
                To      = this.Identifier
            };

            iq.Items.Add(new ServiceItemQuery());

            this.itemsRequested = true;
            this.PendingMessages.Add(iq.ID);
            this.session.Send(iq);

            this.waitEvent.WaitOne();
        }

        #endregion

        #region · Overriden Methods ·

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return this.Identifier;
        }

        /// <summary>
        /// Check if the item is on the given service category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool IsOnCategory(XmppServiceCategory category)
        {
            return (this.identities.Where(s => s.Category == XmppServiceCategory.Conference).Count() > 0);
        }

        #endregion

        #region · Message Subscriptions ·

        private void SubscribeToSessionState()
        {
            this.sessionStateSubscription = this.session
                .StateChanged
                .Where(s => s == XmppSessionState.LoggingIn || s == XmppSessionState.LoggingOut)
                .Subscribe(newState => this.OnSessionStateChanged(newState));
        }

        protected virtual void Subscribe()
        {
            this.infoQuerySubscription = this.session.Connection
                .OnInfoQueryMessage
                .Where(message => message.Type == IQType.Error)
                .Subscribe(message => this.OnQueryErrorMessage(message));

            this.serviceDiscoverySubscription = this.session.Connection
                .OnServiceDiscoveryMessage
                .Where(message => this.PendingMessages.Contains(message.ID))
                .Subscribe(message => this.OnServiceDiscoveryMessage(message));
        }

        protected virtual void Unsubscribe()
        {
            if (this.sessionStateSubscription != null)
            {
                this.sessionStateSubscription.Dispose();
                this.sessionStateSubscription = null;
            }

            if (this.infoQuerySubscription != null)
            {
                this.infoQuerySubscription.Dispose();
                this.infoQuerySubscription = null;
            }

            if (this.serviceDiscoverySubscription != null)
            {
                this.serviceDiscoverySubscription.Dispose();
                this.serviceDiscoverySubscription = null;
            }
        }

        #endregion

        #region · Message Handlers ·

        protected virtual void OnSessionStateChanged(XmppSessionState newState)
        {
            this.SubscribeToSessionState();

            if (newState == XmppSessionState.LoggingIn)
            {
                this.Subscribe();
            }
            else if (newState == XmppSessionState.LoggingOut)
            {
                this.Unsubscribe();
            }

            this.NotifyAllPropertiesChanged();
        }

        private void OnServiceDiscoveryMessage(IQ message)
        {
            if (this.PendingMessages.Contains(message.ID))
            {
                this.PendingMessages.Remove(message.ID);

                foreach (object item in message.Items)
                {
                    if (item is ServiceItemQuery)
                    {
                        foreach (ServiceItem serviceItem in ((ServiceItemQuery)item).Items)
                        {
                            this.items.Add(new XmppServiceItem(this.session, serviceItem.Jid));
                        }

                        this.NotifyPropertyChanged(() => Items);
                    }
                    else if (item is ServiceQuery)
                    {
                        // Details of available services
                        ServiceQuery query = (ServiceQuery)item;

                        if (this.identities == null)
                        {
                            this.identities = new List<XmppServiceIdentity>();
                        }

                        this.identities.Clear();

                        foreach (ServiceIdentity identity in query.Identities)
                        {
                            this.identities.Add(new XmppServiceIdentity(identity.Name, identity.Category, identity.Type));
                        }

                        foreach (ServiceFeature feature in query.Features)
                        {
                            this.features.Add(new XmppServiceFeature(feature.Name));
                        }

                        this.NotifyPropertyChanged(() => Identities);
                        this.NotifyPropertyChanged(() => Features);
                    }
                }
                
                this.waitEvent.Set();
            }
        }

        private void OnQueryErrorMessage(IQ message)
        {
            if (this.PendingMessages.Contains(message.ID))
            {
                this.PendingMessages.Remove(message.ID);

                this.waitEvent.Set();
            }
        }

        #endregion
    }
}
