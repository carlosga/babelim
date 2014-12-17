// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.IO;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Internal class used as State for socket reads
    /// </summary>
    internal sealed class StateObject
    {
        #region · Fields ·

        private Stream workStream;
        private byte[] buffer;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the worker stream
        /// </summary>
        public Stream WorkStream
        {
            get { return this.workStream; }
        }

        /// <summary>
        /// Gets the current buffer contents
        /// </summary>
        public byte[] Buffer
        {
            get { return this.buffer; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="StateObject"/> class.
        /// </summary>
        public StateObject()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateObject"/> class
        /// with the gven worker stream
        /// </summary>
        /// <param name="workStream">The worker stream</param>
        public StateObject(Stream workStream)
            : this(workStream, 4096)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StateObject"/> class
        /// with the gven worker stream and buffer size
        /// </summary>
        /// <param name="workStream">The worker stream</param>
        /// <param name="bufferSize">The buffer size</param>
        public StateObject(Stream workStream, int bufferSize)
        {
            this.buffer     = new byte[bufferSize];
            this.workStream = workStream;
        }

        #endregion
    }
}
