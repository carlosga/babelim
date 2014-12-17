// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// <see cref="XmppContact"/> presence subscription type.
    /// </summary>
    [Serializable]
    public enum XmppContactSubscriptionType
    {
        /// <summary>
        /// Both the user and the contact have subscriptions to each other's presence information.
        /// </summary>
        Both,
        /// <summary>
        /// The contact has a subscription to the user's presence information, 
        /// but the user does not have a subscription to the contact's presence information.
        /// </summary>
        From,
        /// <summary>
        /// The user does not have a subscription to the contact's presence information, 
        /// and the contact does not have a subscription to the user's presence information.
        /// </summary>
        None,
        /// <summary>
        /// Used to remove a <see cref="XmppContact"/> from the <see cref="XmppRoster"/>.
        /// </summary>
        Remove,
        /// <summary>
        /// the user has a subscription to the contact's presence information, 
        /// but the contact does not have a subscription to the user's presence information.
        /// </summary>
        To,
    }
}
