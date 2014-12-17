// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.UserTune
{
    /// <summary>
    /// XEP-0118: User Tune
    /// </summary>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/tune")]
    [XmlRootAttribute("tune", Namespace = "http://jabber.org/protocol/tune", IsNullable = false)]
    public class Tune
    {
        #region · Fields ·

        private string  artistField;
        private ushort  lengthField;
        private bool    lengthFieldSpecified;
        private string  ratingField;
        private string  sourceField;
        private string  titleField;
        private string  trackField;
        private string  uriField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("artist")]
        public string Artist
        {
            get { return this.artistField; }
            set { this.artistField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("length", DataType = "unsignedShort")]
        public ushort Length
        {
            get { return this.lengthField; }
            set
            {
                this.lengthField = value;
                this.lengthFieldSpecified = true;
            }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool LengthSpecified
        {
            get { return this.lengthFieldSpecified; }
        }

        /// <remarks/>
        [XmlElementAttribute("rating", DataType = "positiveInteger")]
        public string Rating
        {
            get { return this.ratingField; }
            set { this.ratingField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("source")]
        public string Source
        {
            get { return this.sourceField; }
            set { this.sourceField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("title")]
        public string Title
        {
            get { return this.titleField; }
            set { this.titleField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("track")]
        public string Track
        {
            get { return this.trackField; }
            set { this.trackField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("uri", DataType = "anyURI")]
        public string Uri
        {
            get { return this.uriField; }
            set { this.uriField = value; }
        }

        #endregion

        #region · Constructors ·

        public Tune()
        {
        }

        #endregion
    }
}
