// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#errors")]
    public enum PubSubErrorUnsupportedFeatureType
    {
        /// <remarks/>
        [XmlEnumAttribute("access-authorize")]
        AccessAuthorize,

        /// <remarks/>
        [XmlEnumAttribute("access-open")]
        AccessOpen,

        /// <remarks/>
        [XmlEnumAttribute("access-presence")]
        AccessPresence,

        /// <remarks/>
        [XmlEnumAttribute("access-roster")]
        AccessRoster,

        /// <remarks/>
        [XmlEnumAttribute("access-whitelist")]
        AccessWhitelist,

        /// <remarks/>
        [XmlEnumAttribute("auto-create")]
        AutoCreate,

        /// <remarks/>
        [XmlEnumAttribute("auto-subscribe")]
        AutoSubscribe,

        /// <remarks/>
        [XmlEnumAttribute("collections")]
        Collections,

        /// <remarks/>
        [XmlEnumAttribute("config-node")]
        ConfigNode,

        /// <remarks/>
        [XmlEnumAttribute("create-and-configure")]
        CreateAndConfigure,

        /// <remarks/>
        [XmlEnumAttribute("create-nodes")]
        CreateNodes,

        /// <remarks/>
        [XmlEnumAttribute("delete-any")]
        DeleteAny,

        /// <remarks/>
        [XmlEnumAttribute("delete-nodes")]
        DeleteNodes,

        /// <remarks/>
        [XmlEnumAttribute("filtered-notifications")]
        FilteredNotifications,

        /// <remarks/>
        [XmlEnumAttribute("get-pending")]
        GetPending,

        /// <remarks/>
        [XmlEnumAttribute("instant-nodes")]
        InstantNodes,

        /// <remarks/>
        [XmlEnumAttribute("item-ids")]
        ItemIds,

        /// <remarks/>
        [XmlEnumAttribute("last-published")]
        LastPublished,

        /// <remarks/>
        [XmlEnumAttribute("leased-subscription")]
        LeasedSubscription,

        /// <remarks/>
        [XmlEnumAttribute("manage-subscriptions")]
        ManageSubscriptions,

        /// <remarks/>
        [XmlEnumAttribute("member-affiliation")]
        MemberAffiliation,

        /// <remarks/>
        [XmlEnumAttribute("meta-data")]
        MetaData,

        /// <remarks/>
        [XmlEnumAttribute("modify-affiliations")]
        ModifyAffiliations,

        /// <remarks/>
        [XmlEnumAttribute("multi-collection")]
        MultiCollection,

        /// <remarks/>
        [XmlEnumAttribute("multi-subscribe")]
        MultiSubscribe,

        /// <remarks/>
        [XmlEnumAttribute("outcast-affiliation")]
        OutcastAffiliation,

        /// <remarks/>
        [XmlEnumAttribute("persistent-items")]
        PersistentItems,

        /// <remarks/>
        [XmlEnumAttribute("presence-notifications")]
        PresenceNotifications,

        /// <remarks/>
        [XmlEnumAttribute("presence-subscribe")]
        PresenceSubscribe,

        /// <remarks/>
        [XmlEnumAttribute("publish")]
        Publish,

        /// <remarks/>
        [XmlEnumAttribute("publish-options")]
        PublishOptions,

        /// <remarks/>
        [XmlEnumAttribute("publisher-affiliation")]
        PublisherAffiliation,

        /// <remarks/>
        [XmlEnumAttribute("purge-nodes")]
        PurgeNodes,

        /// <remarks/>
        [XmlEnumAttribute("retract-items")]
        RetractItems,

        /// <remarks/>
        [XmlEnumAttribute("retrieve-affiliations")]
        RetrieveAffiliations,

        /// <remarks/>
        [XmlEnumAttribute("retrieve-default")]
        RetrieveDefault,

        /// <remarks/>
        [XmlEnumAttribute("retrieve-items")]
        RetrieveItems,

        /// <remarks/>
        [XmlEnumAttribute("retrieve-subscriptions")]
        RetrieveSubscriptions,

        /// <remarks/>
        [XmlEnumAttribute("subscribe")]
        Subscribe,

        /// <remarks/>
        [XmlEnumAttribute("subscription-options")]
        SubscriptionOptions,

        /// <remarks/>
        [XmlEnumAttribute("subscription-notifications")]
        SubscriptionNotifications,
    }
}
