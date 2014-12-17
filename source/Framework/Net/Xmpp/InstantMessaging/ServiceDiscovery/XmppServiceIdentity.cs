// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.InstantMessaging.ServiceDiscovery
{
    /// <summary>
    /// XMPP Service Identity
    /// </summary>
    [XmlTypeAttribute(Namespace = "")]
    [XmlRootAttribute("identity", Namespace = "", IsNullable = false)]
    public sealed class XmppServiceIdentity
    {
        #region · Private Static Methods ·

        private static XmppServiceCategory InferCategory(string category)
        {
            switch (category)
            {
                case "account":
                    return XmppServiceCategory.Account;

                case "auth":
                    return XmppServiceCategory.Auth;

                case "automation":
                    return XmppServiceCategory.Automation;

                case "client":
                    return XmppServiceCategory.Client;

                case "collaboration":
                    return XmppServiceCategory.Collaboration;

                case "component":
                    return XmppServiceCategory.Component;

                case "conference":
                    return XmppServiceCategory.Conference;

                case "directory":
                    return XmppServiceCategory.Directory;

                case "gateway":
                    return XmppServiceCategory.Gateway;

                case "headline":
                    return XmppServiceCategory.Headline;

                case "hierarchy":
                    return XmppServiceCategory.Hierarchy;

                case "proxy":
                    return XmppServiceCategory.Proxy;

                case "pubsub":
                    return XmppServiceCategory.Pubsub;

                case "server":
                    return XmppServiceCategory.Server;

                case "store":
                    return XmppServiceCategory.Store;

                default:
                    return XmppServiceCategory.Unknown;
            }
        }

        #endregion
 
        #region · Fields ·

        private string              name;
        private XmppServiceCategory category;
        private string              type;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the identity name
        /// </summary>
        [XmlAttributeAttribute("name")]
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets the identity category
        /// </summary>
        [XmlAttributeAttribute("category")]
        public XmppServiceCategory Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        /// <summary>
        /// Gets the identity type
        /// </summary>
        [XmlAttributeAttribute("type")]
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        #endregion

        #region · Constructors ·
        
        /// <summary>
        /// Initializes a new instance of the <see cref="XmppServiceIdentity"/> class.
        /// </summary>
        public  XmppServiceIdentity()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppServiceIdentity"/> class.
        /// </summary>
        /// <param name="name">Identity name</param>
        /// <param name="category">Identity category</param>
        /// <param name="type">Identity type</param>
        public XmppServiceIdentity(string name, string category, string type)
            : this(name, InferCategory(category), type)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppServiceIdentity"/> class.
        /// </summary>
        /// <param name="name">Identity name</param>
        /// <param name="category">Identity category</param>
        /// <param name="type">Identity type</param>
        public XmppServiceIdentity(string name, XmppServiceCategory category, string type)
        {
            this.name       = name;
            this.category   = category;
            this.type       = type;
        }

        #endregion
    }
}