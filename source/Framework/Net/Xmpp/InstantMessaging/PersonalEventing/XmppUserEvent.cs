// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

namespace BabelIm.Net.Xmpp.InstantMessaging.PersonalEventing
{
    /// <summary>
    /// XMPP User event activity ( tunes, moods, ... )
    /// </summary>
    public abstract class XmppUserEvent 
        : XmppEvent
    {
        #region · Fields ·
        
        private XmppContact user;
        
        #endregion
        
        #region · Properties ·
        
        /// <summary>
        /// Gets the user data
        /// </summary>
        public XmppContact User
        {
            get { return this.user; }
        }
        
        #endregion
        
        #region · Constructors ·
        
        /// <summary>
        /// Initializes a new instance of the <see cref="XmppUserEvent"/> class.
        /// </summary>
        /// <param name="user"></param>
        protected XmppUserEvent(XmppContact user)
        {
            this.user = user;
        }
        
        #endregion
    }
}
