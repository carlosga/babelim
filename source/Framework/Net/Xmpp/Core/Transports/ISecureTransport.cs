// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

namespace BabelIm.Net.Xmpp.Core.Transports
{
    /// <summary>
    /// Interface for secure transport implementations
    /// </summary>
    internal interface ISecureTransport
        : ITransport
    {
        #region · Methods ·

        /// <summary>
        /// Opens a secure transport connection
        /// </summary>
        void OpenSecureConnection();

        #endregion
    }
}
