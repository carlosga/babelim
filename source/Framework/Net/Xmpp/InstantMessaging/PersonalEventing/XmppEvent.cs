// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.PubSub;
using BabelIm.Net.Xmpp.Serialization.Extensions.UserMood;
using BabelIm.Net.Xmpp.Serialization.Extensions.UserTune;

namespace BabelIm.Net.Xmpp.InstantMessaging.PersonalEventing
{
    /// <summary>
    /// Represents an XMPP event
    /// </summary>
    public abstract class XmppEvent
    {
        #region · Static Methods ·
        
        /// <summary>
        /// Return a value that iundicates wheter a pubsub event is an activity event
        /// </summary>
        /// <param name="xmppevent"></param>
        /// <returns></returns>
        public static bool IsActivityEvent(PubSubEvent xmppevent)
        {
            if (xmppevent.Item is PubSubEventItems)
            {
                PubSubEventItems items = (PubSubEventItems)xmppevent.Item;

                if (items.Items.Count == 1)
                {
                    PubSubItem item = (PubSubItem)items.Items[0];

                    return (item.Item is Tune || item.Item is Mood);
                }
            }

            return false;
        }

        /// <summary>
        /// Creates an xmpp event with the give user and pubsub event
        /// </summary>
        /// <param name="user"></param>
        /// <param name="xmppevent"></param>
        /// <returns></returns>
        public static XmppEvent Create(XmppContact user, PubSubEvent xmppevent)
        {
            if (xmppevent.Item is PubSubEventItems)
            {
                PubSubEventItems items = (PubSubEventItems)xmppevent.Item;

                if (items.Items.Count == 1)
                {
                    PubSubItem item = (PubSubItem)items.Items[0];

                    if (item.Item is Tune)
                    {
                        return new XmppUserTuneEvent(user, (Tune)item.Item);
                    }
                    else if (item.Item is Mood)
                    {
                        return new XmppUserMoodEvent(user, (Mood)item.Item);
                    }
                }
            }

            return null;
        }
        
        #endregion
    }
}
