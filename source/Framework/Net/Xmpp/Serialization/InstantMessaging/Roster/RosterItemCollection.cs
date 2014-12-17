// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

namespace BabelIm.Net.Xmpp.Serialization.InstantMessaging.Roster
{
    public class RosterItemCollection : System.Collections.CollectionBase
    {
        #region · Indexers ·

        public RosterItem this[int index]
        {
            get
            {
                return ((RosterItem)List[index]);
            }
            set
            {
                List[index] = value;
            }
        }

        #endregion

        #region · Methods ·

        public int Add(RosterItem value)
        {
            return (List.Add(value));
        }

        public int IndexOf(RosterItem value)
        {
            return (List.IndexOf(value));
        }

        public void Remove(RosterItem value)
        {
            List.Remove(value);
        }

        public bool Contains(RosterItem value)
        {
            return (List.Contains(value));
        }

        #endregion
    }
}
