// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.UserMood
{   
    /// <summary>
    /// XEP-0107: User Mood
    /// </summary>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/mood")]
    [XmlRootAttribute("mood", Namespace = "http://jabber.org/protocol/mood", IsNullable = false)]
    public sealed class Mood
    {
        #region · Fields ·

        private Empty itemField;
        private MoodType modType;
        private string textField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("afraid", typeof(Empty))]
        [XmlElementAttribute("amazed", typeof(Empty))]
        [XmlElementAttribute("amorous", typeof(Empty))]
        [XmlElementAttribute("angry", typeof(Empty))]
        [XmlElementAttribute("annoyed", typeof(Empty))]
        [XmlElementAttribute("anxious", typeof(Empty))]
        [XmlElementAttribute("aroused", typeof(Empty))]
        [XmlElementAttribute("ashamed", typeof(Empty))]
        [XmlElementAttribute("bored", typeof(Empty))]
        [XmlElementAttribute("brave", typeof(Empty))]
        [XmlElementAttribute("calm", typeof(Empty))]
        [XmlElementAttribute("cautious", typeof(Empty))]
        [XmlElementAttribute("cold", typeof(Empty))]
        [XmlElementAttribute("confident", typeof(Empty))]
        [XmlElementAttribute("confused", typeof(Empty))]
        [XmlElementAttribute("contemplative", typeof(Empty))]
        [XmlElementAttribute("contented", typeof(Empty))]
        [XmlElementAttribute("cranky", typeof(Empty))]
        [XmlElementAttribute("crazy", typeof(Empty))]
        [XmlElementAttribute("creative", typeof(Empty))]
        [XmlElementAttribute("curious", typeof(Empty))]
        [XmlElementAttribute("dejected", typeof(Empty))]
        [XmlElementAttribute("depressed", typeof(Empty))]
        [XmlElementAttribute("disappointed", typeof(Empty))]
        [XmlElementAttribute("disgusted", typeof(Empty))]
        [XmlElementAttribute("dismayed", typeof(Empty))]
        [XmlElementAttribute("distracted", typeof(Empty))]
        [XmlElementAttribute("embarrassed", typeof(Empty))]
        [XmlElementAttribute("envious", typeof(Empty))]
        [XmlElementAttribute("excited", typeof(Empty))]
        [XmlElementAttribute("flirtatious", typeof(Empty))]
        [XmlElementAttribute("frustrated", typeof(Empty))]
        [XmlElementAttribute("grumpy", typeof(Empty))]
        [XmlElementAttribute("guilty", typeof(Empty))]
        [XmlElementAttribute("happy", typeof(Empty))]
        [XmlElementAttribute("hopeful", typeof(Empty))]
        [XmlElementAttribute("hot", typeof(Empty))]
        [XmlElementAttribute("humbled", typeof(Empty))]
        [XmlElementAttribute("humiliated", typeof(Empty))]
        [XmlElementAttribute("hungry", typeof(Empty))]
        [XmlElementAttribute("hurt", typeof(Empty))]
        [XmlElementAttribute("impressed", typeof(Empty))]
        [XmlElementAttribute("in_awe", typeof(Empty))]
        [XmlElementAttribute("in_love", typeof(Empty))]
        [XmlElementAttribute("indignant", typeof(Empty))]
        [XmlElementAttribute("interested", typeof(Empty))]
        [XmlElementAttribute("intoxicated", typeof(Empty))]
        [XmlElementAttribute("invincible", typeof(Empty))]
        [XmlElementAttribute("jealous", typeof(Empty))]
        [XmlElementAttribute("lonely", typeof(Empty))]
        [XmlElementAttribute("lucky", typeof(Empty))]
        [XmlElementAttribute("mean", typeof(Empty))]
        [XmlElementAttribute("moody", typeof(Empty))]
        [XmlElementAttribute("nervous", typeof(Empty))]
        [XmlElementAttribute("neutral", typeof(Empty))]
        [XmlElementAttribute("offended", typeof(Empty))]
        [XmlElementAttribute("outraged", typeof(Empty))]
        [XmlElementAttribute("playful", typeof(Empty))]
        [XmlElementAttribute("proud", typeof(Empty))]
        [XmlElementAttribute("relaxed", typeof(Empty))]
        [XmlElementAttribute("relieved", typeof(Empty))]
        [XmlElementAttribute("remorseful", typeof(Empty))]
        [XmlElementAttribute("restless", typeof(Empty))]
        [XmlElementAttribute("sad", typeof(Empty))]
        [XmlElementAttribute("sarcastic", typeof(Empty))]
        [XmlElementAttribute("serious", typeof(Empty))]
        [XmlElementAttribute("shocked", typeof(Empty))]
        [XmlElementAttribute("shy", typeof(Empty))]
        [XmlElementAttribute("sick", typeof(Empty))]
        [XmlElementAttribute("sleepy", typeof(Empty))]
        [XmlElementAttribute("spontaneous", typeof(Empty))]
        [XmlElementAttribute("stressed", typeof(Empty))]
        [XmlElementAttribute("strong", typeof(Empty))]
        [XmlElementAttribute("surprised", typeof(Empty))]
        [XmlElementAttribute("thankful", typeof(Empty))]
        [XmlElementAttribute("thirsty", typeof(Empty))]
        [XmlElementAttribute("tired", typeof(Empty))]
        [XmlElementAttribute("undefined", typeof(Empty))]
        [XmlElementAttribute("weak", typeof(Empty))]
        [XmlElementAttribute("worried", typeof(Empty))]
        [XmlChoiceIdentifierAttribute("MoodType")]
        public Empty Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public MoodType MoodType
        {
            get { return this.modType; }
            set { this.modType = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("text")]
        public string Text
        {
            get { return this.textField; }
            set { this.textField = value; }
        }

        #endregion

        #region · Constructors ·

        public Mood()
        {
        }

        #endregion
    }
}
