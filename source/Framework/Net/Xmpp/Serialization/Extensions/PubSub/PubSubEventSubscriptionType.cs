// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#event")]
    public enum PubSubEventSubscriptionType
    {
        /// <remarks/>
        [XmlEnumAttribute("none")]
        None,

        /// <remarks/>
        [XmlEnumAttribute("pending")]
        Pending,

        /// <remarks/>
        [XmlEnumAttribute("subscribed")]
        Subscribed,

        /// <remarks/>
        [XmlEnumAttribute("unconfigured")]
        Unconfigured,
    }
}
