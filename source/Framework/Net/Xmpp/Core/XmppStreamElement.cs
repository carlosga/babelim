// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// An element of an XMPP XML message
    /// </summary>
    internal sealed class XmppStreamElement
    {
        #region · Fields ·

        private string  name;
        private string  xmlNamespace;
        private string  node;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets the XML namespace.
        /// </summary>
        /// <value>The XML namespace.</value>
        public string XmlNamespace
        {
            get { return this.xmlNamespace; }
        }

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <value>The node.</value>
        public string Node
        {
            get { return this.node; } 
        }

        /// <summary>
        /// Gets a value indicating whether [opens XMPP stream].
        /// </summary>
        /// <value><c>true</c> if [opens XMPP stream]; otherwise, <c>false</c>.</value>
        public bool OpensXmppStream
        {
            get 
            {
                return (this.name == XmppCodes.XmppStreamName &&
                        this.node.StartsWith(XmppCodes.XmppStreamOpen)); 
            }
        }

        /// <summary>
        /// Gets a value indicating whether [closes XMPP stream].
        /// </summary>
        /// <value><c>true</c> if [closes XMPP stream]; otherwise, <c>false</c>.</value>
        public bool ClosesXmppStream
        {
            get { return this.node.StartsWith(XmppCodes.XmppStreamClose); }
        }


        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppStreamElement"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="xmlNamespace">The XML namespace.</param>
        /// <param name="node">The node.</param>
        public XmppStreamElement(string name, string xmlNamespace, string node)
        {
            this.name			= name;
            this.xmlNamespace	= xmlNamespace;
            this.node			= node;
        }

        #endregion

        #region · Overriden Methods ·

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return this.node;
        }

        #endregion
    }
}
