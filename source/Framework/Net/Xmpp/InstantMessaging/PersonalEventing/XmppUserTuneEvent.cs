// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.UserTune;
using System;

namespace BabelIm.Net.Xmpp.InstantMessaging.PersonalEventing
{
    /// <summary>
    /// Activity for the user tune event
    /// </summary>
    public sealed class XmppUserTuneEvent 
        : XmppUserEvent
    {
        #region · Fields ·

        private string 	artist;
        private ushort  length;
        private string 	rating;
        private string 	source;
        private string 	title;
        private string 	track;
        private string 	uri;

        #endregion

        #region · Properties ·

        /// <remarks/>
        public string Artist
        {
            get { return this.artist; }
        }

        /// <remarks/>
        public ushort Length
        {
            get { return this.length; }
        }

        /// <remarks/>
        public string Rating
        {
            get { return this.rating; }
        }

        /// <remarks/>
        public string Source
        {
            get { return this.source; }
        }

        /// <remarks/>
        public string Title
        {
            get { return this.title; }
        }

        /// <remarks/>
        public string Track
        {
            get { return this.track; }
        }

        /// <remarks/>
        public string Uri
        {
            get { return this.uri; }
        }

        public bool IsEmpty
        {
            get 
            {
                return (String.IsNullOrEmpty(this.Artist) &&
                        String.IsNullOrEmpty(this.Title) &&
                        String.IsNullOrEmpty(this.Rating) &&
                        String.IsNullOrEmpty(this.Source) &&
                        String.IsNullOrEmpty(this.Track) &&
                        this.Length == 0);
            }
        }

        #endregion
        
        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppUserTuneEvent">XmppUserTuneEvent</see> class.
        /// </summary>
        /// <param name="user">User contact</param>
        /// <param name="tune">User tune</param>
        public XmppUserTuneEvent(
            string  artist,
            ushort  length,
            string  rating,
            string  source,
            string  title,
            string  track,
            string  uri) : base(null)
        {
            this.artist = artist;
            this.length = length;
            this.rating = rating;
            this.source = source;
            this.title  = title;
            this.track  = track;
            this.uri    = uri;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="XmppUserTuneEvent">XmppUserTuneEvent</see> class.
        /// </summary>
        /// <param name="user">User contact</param>
        /// <param name="tune">User tune</param>
        public XmppUserTuneEvent(XmppContact user, Tune tune)
            : base(user)
        {
            this.artist	= tune.Artist;
            this.length	= tune.Length;
            this.rating = tune.Rating;
            this.source	= tune.Source;
            this.title	= tune.Title;
            this.track	= tune.Track;
            this.uri	= tune.Uri;
        }
        
        #endregion
    }
}
