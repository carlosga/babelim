// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Extensions.DataForms;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub
{
    /// <remarks/>
    [XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#event")]
    [XmlRootAttribute("configuration", Namespace = "http://jabber.org/protocol/pubsub#event", IsNullable = false)]
    public class PubSubEventConfiguration
    {
        #region · Fields ·

        private DataForm dataForm;
        private string nodeField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute(Namespace = "jabber:x:data")]
        public DataForm DataForm
        {
            get { return this.dataForm; }
            set { this.dataForm = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("node")]
        public string Node
        {
            get { return this.nodeField; }
            set { this.nodeField = value; }
        }

        #endregion

        #region · Constructors ·

        public PubSubEventConfiguration()
        {
            if ((this.dataForm == null))
            {
                this.dataForm = new DataForm();
            }
        }

        #endregion
    }

}
