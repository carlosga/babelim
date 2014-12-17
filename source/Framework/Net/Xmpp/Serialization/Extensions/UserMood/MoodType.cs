// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.UserMood
{
    /// <summary>
    /// XEP-0107: User Mood
    /// </summary>
    [XmlTypeAttribute(Namespace = "http://jabber.org/protocol/mood", IncludeInSchema = false)]
    public enum MoodType
    {
        /// <remarks/>
        [XmlEnumAttribute("afraid")]
        Afraid,

        /// <remarks/>
        [XmlEnumAttribute("amazed")]
        Amazed,

        /// <remarks/>
        [XmlEnumAttribute("amorous")]
        Amorous,

        /// <remarks/>
        [XmlEnumAttribute("angry")]
        Angry,

        /// <remarks/>
        [XmlEnumAttribute("annoyed")]
        Annoyed,

        /// <remarks/>
        [XmlEnumAttribute("anxious")]
        Anxious,

        /// <remarks/>
        [XmlEnumAttribute("aroused")]
        Aroused,

        /// <remarks/>
        [XmlEnumAttribute("ashamed")]
        Ashamed,

        /// <remarks/>
        [XmlEnumAttribute("bored")]
        Bored,

        /// <remarks/>
        [XmlEnumAttribute("brave")]
        Brave,

        /// <remarks/>
        [XmlEnumAttribute("calm")]
        Calm,

        /// <remarks/>
        [XmlEnumAttribute("cautious")]
        Cautious,

        /// <remarks/>
        [XmlEnumAttribute("cold")]
        Cold,

        /// <remarks/>
        [XmlEnumAttribute("confident")]
        Confident,

        /// <remarks/>
        [XmlEnumAttribute("confused")]
        Confused,

        /// <remarks/>
        [XmlEnumAttribute("contemplative")]
        Contemplative,

        /// <remarks/>
        [XmlEnumAttribute("contented")]
        Contented,

        /// <remarks/>
        [XmlEnumAttribute("cranky")]
        Cranky,

        /// <remarks/>
        [XmlEnumAttribute("crazy")]
        Crazy,

        /// <remarks/>
        [XmlEnumAttribute("creative")]
        Creative,

        /// <remarks/>
        [XmlEnumAttribute("curious")]
        Curious,

        /// <remarks/>
        [XmlEnumAttribute("dejected")]
        Dejected,

        /// <remarks/>
        [XmlEnumAttribute("depressed")]
        Depressed,

        /// <remarks/>
        [XmlEnumAttribute("disappointed")]
        Disappointed,

        /// <remarks/>
        [XmlEnumAttribute("disgusted")]
        Disgusted,

        /// <remarks/>
        [XmlEnumAttribute("dismayed")]
        Dismayed,

        /// <remarks/>
        [XmlEnumAttribute("distracted")]
        Distracted,

        /// <remarks/>
        [XmlEnumAttribute("embarrassed")]
        Embarrassed,

        /// <remarks/>
        [XmlEnumAttribute("envious")]
        Envious,

        /// <remarks/>
        [XmlEnumAttribute("excited")]
        Excited,

        /// <remarks/>
        [XmlEnumAttribute("flirtatious")]
        Flirtatious,

        /// <remarks/>
        [XmlEnumAttribute("frustrated")]
        Frustrated,

        /// <remarks/>
        [XmlEnumAttribute("grumpy")]
        Grumpy,

        /// <remarks/>
        [XmlEnumAttribute("guilty")]
        Guilty,

        /// <remarks/>
        [XmlEnumAttribute("happy")]
        Happy,

        /// <remarks/>
        [XmlEnumAttribute("hopeful")]
        Hopeful,

        /// <remarks/>
        [XmlEnumAttribute("hot")]
        Hot,

        /// <remarks/>
        [XmlEnumAttribute("humbled")]
        Humbled,

        /// <remarks/>
        [XmlEnumAttribute("humiliated")]
        Humiliated,

        /// <remarks/>
        [XmlEnumAttribute("hungry")]
        Hungry,

        /// <remarks/>
        [XmlEnumAttribute("hurt")]
        Hurt,

        /// <remarks/>
        [XmlEnumAttribute("impressed")]
        Impressed,

        /// <remarks/>
        [XmlEnumAttribute("in_awe")]
        InAwe,

        /// <remarks/>
        [XmlEnumAttribute("in_love")]
        Inlove,

        /// <remarks/>
        [XmlEnumAttribute("indignant")]
        Indignant,

        /// <remarks/>
        [XmlEnumAttribute("interested")]
        Interested,

        /// <remarks/>
        [XmlEnumAttribute("intoxicated")]
        Intoxicated,

        /// <remarks/>
        [XmlEnumAttribute("invincible")]
        Invincible,

        /// <remarks/>
        [XmlEnumAttribute("jealous")]
        Jealous,

        /// <remarks/>
        [XmlEnumAttribute("lonely")]
        Lonely,

        /// <remarks/>
        [XmlEnumAttribute("lucky")]
        Lucky,

        /// <remarks/>
        [XmlEnumAttribute("mean")]
        Mean,

        /// <remarks/>
        [XmlEnumAttribute("moody")]
        Moody,

        /// <remarks/>
        [XmlEnumAttribute("nervous")]
        Nervous,

        /// <remarks/>
        [XmlEnumAttribute("neutral")]
        Neutral,

        /// <remarks/>
        [XmlEnumAttribute("offended")]
        Offended,

        /// <remarks/>
        [XmlEnumAttribute("outraged")]
        Outraged,

        /// <remarks/>
        [XmlEnumAttribute("playful")]
        Playful,

        /// <remarks/>
        [XmlEnumAttribute("proud")]
        Proud,

        /// <remarks/>
        [XmlEnumAttribute("relaxed")]
        Relaxed,

        /// <remarks/>
        [XmlEnumAttribute("relieved")]
        Relieved,

        /// <remarks/>
        [XmlEnumAttribute("remorseful")]
        Remorseful,

        /// <remarks/>
        [XmlEnumAttribute("restless")]
        Restless,

        /// <remarks/>
        [XmlEnumAttribute("sad")]
        Sad,

        /// <remarks/>
        [XmlEnumAttribute("sarcastic")]
        Sarcastic,

        /// <remarks/>
        [XmlEnumAttribute("serious")]
        Serious,

        /// <remarks/>
        [XmlEnumAttribute("shocked")]
        Shocked,

        /// <remarks/>
        [XmlEnumAttribute("shy")]
        Shy,

        /// <remarks/>
        [XmlEnumAttribute("sick")]
        Sick,

        /// <remarks/>
        [XmlEnumAttribute("sleepy")]
        Sleepy,

        /// <remarks/>
        [XmlEnumAttribute("spontaneous")]
        Spontaneous,

        /// <remarks/>
        [XmlEnumAttribute("stressed")]
        Stressed,

        /// <remarks/>
        [XmlEnumAttribute("strong")]
        Strong,

        /// <remarks/>
        [XmlEnumAttribute("surprised")]
        Surprised,

        /// <remarks/>
        [XmlEnumAttribute("thankful")]
        Thankful,

        /// <remarks/>
        [XmlEnumAttribute("thirsty")]
        Thirsty,

        /// <remarks/>
        [XmlEnumAttribute("tired")]
        Tired,

        /// <remarks/>
        [XmlEnumAttribute("undefined")]
        Undefined,

        /// <remarks/>
        [XmlEnumAttribute("weak")]
        Weak,

        /// <remarks/>
        [XmlEnumAttribute("worried")]
        Worried,
    }
}
