// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;

namespace BabelIm.Net.Xmpp.Core.Transports
{
    /// <summary>
    /// Interface for transport implementations
    /// </summary>
    internal interface ITransport
        : IDisposable
    {
        #region · Properties ·
        
        /// <summary>
        /// XMPP server Host name
        /// </summary>
        /// <remarks>
        /// It may return the connection string host name or the one resolved by DNS SRV records lookups
        /// </remarks>
        string HostName
        {
            get;
        }
    
        #endregion

        #region · Observable Properties ·

        /// <summary>
        /// Occurs when a new message is received
        /// </summary>
        IObservable<object> OnMessageReceived
        {
            get;
        }

        /// <summary>
        /// Occurs when a stream open message is received
        /// </summary>
        IObservable<string> OnXmppStreamInitialized
        {
            get;
        }

        /// <summary>
        /// Occurs when a close stream message is received
        /// </summary>
        IObservable<string> OnXmppStreamClosed
        {
            get;
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Opens the transport connection
        /// </summary>
        /// <param name="connectionString"></param>
        void Open(XmppConnectionString connectionString);

        /// <summary>
        /// Initializes the XMPP stream
        /// </summary>
        void InitializeXmppStream();

        /// <summary>
        /// Sends a new message
        /// </summary>
        /// <param name="message">The message as an XML string</param>
        void Send(string message);

        /// <summary>
        /// Send a new message
        /// </summary>
        /// <param name="message">The message</param>
        void Send(object message);

        /// <summary>
        /// Sends a new message as a raw byte array
        /// </summary>
        /// <param name="message">The message buffer</param>
        void Send(byte[] message);

        /// <summary>
        /// Closes the transport connection
        /// </summary>
        void Close();

        #endregion
    }
}
