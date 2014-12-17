// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.IO;
using System.Text;
using System.Xml;

namespace BabelIm.Net.Xmpp.Serialization
{
    /// <summary>
    /// Custom <see cref="XmlTextWriter"/> implementation for writing XMPP stanzas
    /// </summary>
    public sealed class XmppTextWriter
        : XmlTextWriter
    {
        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppTextWriter"/> class.
        /// </summary>
        /// <param name="w">The TextWriter to write to. It is assumed that the TextWriter is already set to the correct encoding.</param>
        public XmppTextWriter(TextWriter w) 
            : base(w)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppTextWriter"/> class.
        /// </summary>
        /// <param name="w">The w.</param>
        public XmppTextWriter(Stream w) 
            : this(w, Encoding.UTF8)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppTextWriter"/> class.
        /// </summary>
        /// <param name="w">The w.</param>
        /// <param name="encoding">The encoding.</param>
        public XmppTextWriter(Stream w, Encoding encoding) 
            : base(w, encoding)
        {
        }

        #endregion

        #region · Overriden Methods ·

        /// <summary>
        /// Writes the XML declaration with the version "1.0".
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">This is not the first write method called after the constructor. </exception>
        public override void WriteStartDocument()
        {
        }

        /// <summary>
        /// Writes the XML declaration with the version "1.0" and the standalone attribute.
        /// </summary>
        /// <param name="standalone">If true, it writes "standalone=yes"; if false, it writes "standalone=no".</param>
        /// <exception cref="T:System.InvalidOperationException">This is not the first write method called after the constructor. </exception>
        public override void WriteStartDocument(bool standalone)
        {
        }

        #endregion
    }
}
