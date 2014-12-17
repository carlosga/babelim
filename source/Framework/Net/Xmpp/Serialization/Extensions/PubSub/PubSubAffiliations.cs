// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("affiliations", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubAffiliations
    {
        #region · Fields ·

        private List<PubSubAffiliation> affiliationField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("affiliation")]
        public List<PubSubAffiliation> Affiliation
        {
            get { return this.affiliationField; }
            set { this.affiliationField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSubAffiliations()
        {
            if ((this.affiliationField == null))
            {
                this.affiliationField = new List<PubSubAffiliation>();
            }
        }

        #endregion
    }
}
