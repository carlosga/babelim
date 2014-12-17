// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Core;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;

namespace BabelIm.Net.Xmpp.InstantMessaging.PersonalEventing
{
    /// <summary>
    /// XMPP Activity
    /// </summary>
    public sealed class XmppActivity 
        : ObservableObject, IEnumerable<XmppEvent>, INotifyCollectionChanged
    {
        #region · INotifyCollectionChanged Members ·

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion

        #region · Fields ·

        private ObservableCollection<XmppEvent>	activities;
        private XmppSession						session;

        #region · Subscriptions ·

        private IDisposable sessionStateSubscription;
        private IDisposable messageSubscription;
        private IDisposable eventMessageSubscription;
        
        #endregion

        #endregion
      
        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppSession"/> class
        /// </summary>
        internal XmppActivity(XmppSession session)
        {
            this.session    = session;
            this.activities	= new ObservableCollection<XmppEvent>();

            this.SubscribeToSessionState();
        }

        #endregion
        
        #region · Methods ·
        
        /// <summary>
        /// Clears the activity list
        /// </summary>
        public void Clear()
        {
        	this.activities.Clear();

            this.InvokeAsynchronously
            (
                () =>
                {
                    if (this.CollectionChanged != null)
                    {
                        this.CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                    }
                }
            );
        }
        
        #endregion

        #region · IEnumerable<IActivity> Members ·

        IEnumerator<XmppEvent> IEnumerable<XmppEvent>.GetEnumerator()
        {
            return this.activities.GetEnumerator();
        }

        #endregion

        #region · IEnumerable Members ·

        public IEnumerator GetEnumerator()
        {
            return this.activities.GetEnumerator();
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
                        this.Clear();
                        this.Unsubscribe();
                    }
                }
            );
        }

        private void Subscribe()
        {
            this.messageSubscription = this.session
                .MessageReceived
                .Where(m => m.Type == MessageType.Headline || m.Type == MessageType.Normal)
                .Subscribe
            (
                message => { this.OnActivityMessage(message); }
            );

            this.eventMessageSubscription = this.session.Connection
                .OnEventMessage
                .Subscribe(message => this.OnEventMessage(message));

            this.activities.CollectionChanged += new NotifyCollectionChangedEventHandler(OnCollectionChanged);
        }

        private void Unsubscribe()
        {
            if (this.messageSubscription != null)
            {
                this.messageSubscription.Dispose();
                this.messageSubscription = null;
            }

            if (this.eventMessageSubscription != null)
            {
                this.eventMessageSubscription.Dispose();
                this.eventMessageSubscription = null;
            }

            this.activities.CollectionChanged -= new NotifyCollectionChangedEventHandler(OnCollectionChanged);
        }

        #endregion

        #region · Message Handlers ·

        private void OnActivityMessage(XmppMessage message)
        {
            switch (message.Type)
            {
                case MessageType.Normal:
                    this.activities.Add(new XmppMessageEvent(message));
                    break;

                case MessageType.Headline:
                    this.activities.Add(new XmppMessageEvent(message));
                    break;
            }            
        }

        private void OnEventMessage(XmppEventMessage message)
        {
        	// Add the activity based on the source event
        	if (XmppEvent.IsActivityEvent(message.Event))
        	{
                XmppEvent xmppevent = XmppEvent.Create(this.session.Roster[message.From.BareIdentifier], message.Event);

#warning TODO: see what to do when it's null
                if (xmppevent != null)
                {
#warning TODO: This needs to be changed
                    if (xmppevent is XmppUserTuneEvent && ((XmppUserTuneEvent)xmppevent).IsEmpty)
                    {
                        // And empty tune means no info available or that the user
                        // cancelled the tune notifications ??
                    }
                    else
                    {
                        this.activities.Add(xmppevent);
                    }
                }
        	}
        }

        #endregion

        #region · Change Notification ·

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            this.InvokeAsynchronouslyInBackground
            (
                () =>
                {
                    if (this.CollectionChanged != null)
                    {
                        this.CollectionChanged(this, e);
                    }
                }
            );
        }

        #endregion
    }
}
