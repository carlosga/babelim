// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.DataForms;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub")]
    [XmlRootAttribute("configure", Namespace = "http://jabber.org/protocol/pubsub", IsNullable = false)]
    public class PubSubConfigure
    {
        #region · Fields ·

        private DataForm itemField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("x", Namespace = "jabber:x:data")]
        public DataForm Item
        {
            get { return this.itemField; }
            set { this.itemField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSubConfigure()
        {
            if ((this.itemField == null))
            {
                this.itemField = new DataForm();
            }
        }

        #endregion
    }
}
