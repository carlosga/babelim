// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.MultiUserChat;

namespace BabelIm.Net.Xmpp.InstantMessaging.MultiUserChat
{
    public sealed class XmppChatRoomUser
        : ObservableObject
    {
        #region · Fields ·

        private MucUserItem userItem;

        #endregion
    	
    	#region · Properties ·
    	
        public MucUserActor Actor
        {
        	get { return this.userItem.Actor; }
        }
        
        public MucUserItemAffiliation Affiliation
        {
        	get { return this.userItem.Affiliation; }
        }
                
        public string Identifier
        {
        	get { return this.userItem.Jid; }
        }
        
        public string Nick
        {
        	get { return this.userItem.Nick; }
        }
        
        public MucUserItemRole Role
        {
        	get { return this.userItem.Role; }
        }
            	
    	#endregion
    	
        #region · Constructors ·

        internal XmppChatRoomUser(MucUserItem userItem)
        {
            this.userItem = userItem;
        }

        #endregion
    }
}
