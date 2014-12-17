// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client;
using BabelIm.Net.Xmpp.Serialization.InstantMessaging.Client.Presence;
using System;
using System.Collections;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Streams
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace = "http://etherx.jabber.org/streams")]
    [XmlRootAttribute("stream", Namespace = "http://etherx.jabber.org/streams", IsNullable = false)]
    public class Stream
    {
        #region · Fields ·

        private StreamFeatures  featuresField;
        private ArrayList       itemsField;
        private StreamError     errorField;
        private string          fromField;
        private string          idField;
        private string          toField;
        private string          versionField;
        private string          langField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("features")]
        public StreamFeatures Features
        {
            get { return this.featuresField; }
            set { this.featuresField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("presence", typeof(Presence), Namespace = "jabber:client")]
        [XmlElementAttribute("iq", typeof(IQ), Namespace = "jabber:client")]
        [XmlElementAttribute("message", typeof(Message), Namespace = "jabber:client")]
        public ArrayList Items
        {
            get { return this.itemsField; }
        }

        /// <remarks/>
        [XmlElementAttribute("error")]
        public StreamError Error
        {
            get { return this.errorField; }
            set { this.errorField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("from")]
        public string From
        {
            get { return this.fromField; }
            set { this.fromField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("id", DataType = "NMTOKEN")]
        public string ID
        {
            get { return this.idField; }
            set { this.idField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("to")]
        public string To
        {
            get { return this.toField; }
            set { this.toField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("version")]
        public string Version
        {
            get { return this.versionField; }
            set { this.versionField = value; }
        }

        /// <remarks/>
        [XmlAttributeAttribute("lang", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/XML/1998/namespace")]
        public string Lang
        {
            get { return this.langField; }
            set { this.langField = value; }
        }

        #endregion

        #region · Constructors ·

        public Stream()
        {
            this.itemsField = new ArrayList();
        }

        #endregion
    }
}