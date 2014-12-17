// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Speficies feature flags supported bythe XMPP server.
    /// </summary>
    [Flags]
    internal enum XmppStreamFeatures
    {
        /// <summary>
        /// TLS Connections.
        /// </summary>
        SecureConnection	= 0,
        /// <summary>
        /// SASL Digest Authentication Mechanism.
        /// </summary>
        SaslDigestMD5		= 2,
        /// <summary>
        /// SASL Plaint Authentication Mechanism.
        /// </summary>
        SaslPlain			= 4,
        /// <summary>
        /// Resource binding.
        /// </summary>
        ResourceBinding		= 8,
        /// <summary>
        /// Session Binding
        /// </summary>
        Sessions			= 16,
        /// <summary>
        /// In-Band registration of users.
        /// </summary>
        InBandRegistration	= 32,
        /// <summary>
        /// X-Google-Token Authentication Machanism
        /// </summary>
        XGoogleToken        = 64
    }
}
