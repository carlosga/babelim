// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.UserMood;

namespace BabelIm.Net.Xmpp.InstantMessaging.PersonalEventing
{
    /// <summary>
    /// Activity event for user mood
    /// </summary>
    public sealed class XmppUserMoodEvent
        : XmppUserEvent
    {
        #region · Fields ·
        
        private string mood;
        private string text;
                
        #endregion
        
        #region · Properties ·
        
        /// <summary>
        /// Gets the user mood
        /// </summary>
        public string Mood
        {
            get { return this.mood; }
        }
        
        /// <summary>
        /// Gets the user mood text
        /// </summary>
        public string Text
        {
            get { return this.text; }
        }
        
        #endregion
        
        #region · Constructors ·
        
        /// <summary>
        /// Initializes a new instance of the <see cref="XmppUserMoodEvent">XmppUserMoodEvent</see> class.
        /// </summary>
        /// <param name="user">User contact</param>
        /// <param name="mood">User mood</param>
        public XmppUserMoodEvent(XmppContact user, Mood mood)
            : base(user)
        {
            this.mood = mood.MoodType.ToString();
            this.text = mood.Text;
        }
        
        #endregion
    }
}
