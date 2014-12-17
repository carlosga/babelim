// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Core;

namespace BabelIm.Net.Xmpp.InstantMessaging.PersonalEventing
{
    /// <summary>
    /// Activity event for headline and normal messages
    /// </summary>
    public sealed class XmppMessageEvent
        : XmppEvent
    {
        #region · Fields ·
        
        private XmppMessage message;
        
        #endregion
        
        #region · Properties ·
        
        /// <summary>
        /// Gets the message information
        /// </summary>
        public XmppMessage Message
        {
            get { return this.message; }
        }
        
        #endregion
        
        #region · Constructors ·
        
        /// <summary>
        /// Initializes a new instance of the <see cref="">XmppMessageEvent</see> class.
        /// </summary>
        /// <param name="message">The message information</param>
        public XmppMessageEvent(XmppMessage message)
        {
            this.message = message;
        }
        
        #endregion
    }
}
