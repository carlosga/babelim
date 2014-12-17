// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.PubSub;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Pub sub event message
    /// </summary>
    public sealed class XmppEventMessage 
    {
    	#region · Fields ·

    	private string  	identifier;
        private XmppJid 	from;
        private XmppJid 	to;
        private PubSubEvent eventMessage;
        
        #endregion
        
        #region · Properties ·

        /// <summary>
        /// Gets the XMPP Event Message ID
        /// </summary>
    	public string Identifier
    	{
    		get { return this.identifier; }
    	}
    	
        /// <summary>
        /// Gets the Event Message source JID
        /// </summary>
        public XmppJid From
        {
        	get { return this.from; }
        }

        /// <summary>
        /// Gets the Event Message target JID
        /// </summary>
        public XmppJid To
        {
        	get { return this.to; }
        }

        /// <summary>
        /// Gets the XMPP Event Message data
        /// </summary>
        public PubSubEvent Event
        {
        	get { return this.eventMessage; }
        }
        
        #endregion
        
        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppEventMessage"/> class.
        /// </summary>
        /// <param name="message">The event.</param>
        internal XmppEventMessage(Message message)
        {
        	this.identifier   = message.ID;
        	this.from 		  = message.From;
        	this.to			  = message.To;
        	this.eventMessage = (PubSubEvent)message.Items[0];
        }

        #endregion
    }
}
