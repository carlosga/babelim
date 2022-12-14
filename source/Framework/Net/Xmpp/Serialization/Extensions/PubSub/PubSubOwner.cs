// Copyright (c) Carlos Guzm?n ?lvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

namespace BabelIm.Net.Xmpp.Serialization.Extensions.PubSub.Owner
{
    using System.Collections.Generic;
    using System.ComponentModel;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner", IsNullable = false)]
    public sealed class pubsub
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private object itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("affiliations", typeof(affiliations))]
        [System.Xml.Serialization.XmlElementAttribute("configure", typeof(configure))]
        [System.Xml.Serialization.XmlElementAttribute("default", typeof(@default))]
        [System.Xml.Serialization.XmlElementAttribute("delete", typeof(delete))]
        [System.Xml.Serialization.XmlElementAttribute("purge", typeof(purge))]
        [System.Xml.Serialization.XmlElementAttribute("subscriptions", typeof(subscriptions))]
        public object Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner", IsNullable = false)]
    public sealed class affiliations
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private List<affiliation> affiliationField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string nodeField;

        public affiliations()
        {
            if ((this.affiliationField == null))
            {
                this.affiliationField = new List<affiliation>();
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("affiliation")]
        public List<affiliation> affiliation
        {
            get
            {
                return this.affiliationField;
            }
            set
            {
                this.affiliationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner", IsNullable = false)]
    public sealed class affiliation
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private affiliationAffiliation affiliation1Field;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string jidField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private empty valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("affiliation")]
        public affiliationAffiliation affiliation1
        {
            get
            {
                return this.affiliation1Field;
            }
            set
            {
                this.affiliation1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string jid
        {
            get
            {
                return this.jidField;
            }
            set
            {
                this.jidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public empty Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    public enum affiliationAffiliation
    {

        /// <remarks/>
        member,

        /// <remarks/>
        none,

        /// <remarks/>
        outcast,

        /// <remarks/>
        owner,

        /// <remarks/>
        publisher,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner")]
    public enum empty
    {

        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("")]
        Item,
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner", IsNullable = false)]
    public sealed class configure
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private x itemField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string nodeField;

        public configure()
        {
            if ((this.itemField == null))
            {
                this.itemField = new x();
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("x", Namespace = "jabber:x:data")]
        public x Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner", IsNullable = false)]
    public sealed class @default
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private x itemField;

        public @default()
        {
            if ((this.itemField == null))
            {
                this.itemField = new x();
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("x", Namespace = "jabber:x:data")]
        public x Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner", IsNullable = false)]
    public sealed class delete
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string nodeField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private empty valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public empty Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner", IsNullable = false)]
    public sealed class purge
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string nodeField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private empty valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public empty Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner", IsNullable = false)]
    public sealed class subscriptions
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private List<subscription> subscriptionField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string nodeField;

        public subscriptions()
        {
            if ((this.subscriptionField == null))
            {
                this.subscriptionField = new List<subscription>();
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("subscription")]
        public List<subscription> subscription
        {
            get
            {
                return this.subscriptionField;
            }
            set
            {
                this.subscriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string node
        {
            get
            {
                return this.nodeField;
            }
            set
            {
                this.nodeField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://jabber.org/protocol/pubsub#owner", IsNullable = false)]
    public sealed class subscription
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        private subscriptionSubscription subscription1Field;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private string jidField;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private empty valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("subscription")]
        public subscriptionSubscription subscription1
        {
            get
            {
                return this.subscription1Field;
            }
            set
            {
                this.subscription1Field = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string jid
        {
            get
            {
                return this.jidField;
            }
            set
            {
                this.jidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public empty Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "2.0.50727.3074")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://jabber.org/protocol/pubsub#owner")]
    public enum subscriptionSubscription
    {

        /// <remarks/>
        none,

        /// <remarks/>
        pending,

        /// <remarks/>
        subscribed,

        /// <remarks/>
        unconfigured,
    }
}
