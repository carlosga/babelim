// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Internal constants
    /// </summary>
    internal static class XmppCodes
    {
        #region · Constants ·

        /// <summary>
        /// Namespace URI of the XMPP stream
        /// </summary>
        public const string XmppNamespaceURI = "http://etherx.jabber.org/streams";

        /// <summary>
        /// Code for the SASL Digest authentication mechanism
        /// </summary>
        public const string SaslDigestMD5Mechanism = "DIGEST-MD5";

        /// <summary>
        /// Code for the SASL PLAIN authentication mechanism
        /// </summary>
        public const string SaslPlainMechanism = "PLAIN";

        /// <summary>
        /// Code for the SASL X-GOOGLE-Token authentication mechanism
        /// </summary>
        public const string SaslXGoogleTokenMechanism = "X-GOOGLE-TOKEN";

        /// <summary>
        /// XMPP Stream XML root node name
        /// </summary>
        internal static readonly string XmppStreamName = "stream:stream";

        /// <summary>
        /// XMPP Stream XML open node tag
        /// </summary>
        internal static readonly string XmppStreamOpen = String.Format("<{0} ", XmppStreamName);

        /// <summary>
        /// XMPP Stream XML close node tag
        /// </summary>
        internal static readonly string XmppStreamClose = String.Format("</{0}>", XmppStreamName);

        /// <summary>
        /// XMPP DNS SRV Record prefix
        /// </summary>
        internal static string XmppSrvRecordPrefix = "_xmpp-client._tcp";

        #endregion
    }
}
