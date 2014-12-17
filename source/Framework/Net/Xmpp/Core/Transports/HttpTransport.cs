// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization;
using BabelIm.Net.Xmpp.Serialization.Extensions.Bosh;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BabelIm.Net.Xmpp.Core.Transports
{
    /// <summary>
    /// XMPP over Bosh (HTTP) Transport implementation
    /// </summary>
    /// <remarks>
    /// XEP-0124 - Bidirectional-streams Over Synchronous HTTP (BOSH) - http://xmpp.org/extensions/xep-0124.pdf
    /// XEP-0206 - XMPP over BOSH - http://xmpp.org/extensions/xep-0206.pdf
    /// </remarks>
    internal sealed class HttpTransport
        : BaseTransport, ITransport
    {
        #region · Consts ·

        const string ContentType     = "text/xml; charset=utf-8";
        const string BoshVersion     = "1.10";
        const string RouteFormat     = "xmpp:{0}:9999";
        const string DefaultLanguage = "en";

        #endregion

        #region · Static Methods ·

        private static bool ValidateRemoteCertificate(object          sender
                                                    , X509Certificate certificate
                                                    , X509Chain       chain
                                                    , SslPolicyErrors policyErrors)
        {
            // allow any old dodgy certificate...
            return true;
        }

        #endregion

        #region · Fields ·

        private HttpBindBody streamResponse;
        private long         rid;

        #endregion

        #region · Constructors ·

        public HttpTransport()
            : base()
        {
        }

        #endregion

        #region · Methods ·
        
        public override void Open(XmppConnectionString connectionString)
        {
            // Connection string
            this.ConnectionString = connectionString;
            this.UserId           = this.ConnectionString.UserId;

            // Generate initial RID
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[32 / 8];

                rng.GetBytes(bytes);

                this.rid = BitConverter.ToInt32(bytes, 0);
                this.rid = (this.rid < 0) ? -this.rid : this.rid;
            }

            // HTTP Configuration
            ServicePointManager.Expect100Continue                   = false;
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateRemoteCertificate);
        }

        public override void InitializeXmppStream()
        {
            var message = new HttpBindBody
            {
                Rid  = (this.rid++).ToString()
              , To   = this.ConnectionString.HostName
              , Lang = DefaultLanguage
            };
            
            if (this.streamResponse == null)
            {
                message.Content       = HttpTransport.ContentType;
                message.From          = this.UserId.BareIdentifier;
                message.Hold          = 1;
                message.HoldSpecified = true;
                message.Route         = String.Format(RouteFormat, this.ConnectionString.HostName);
                message.Ver           = HttpTransport.BoshVersion;
                message.Wait          = 60;
                message.WaitSpecified = true;
                message.Ack           = "1";
            }
            else
            {
                message.Sid     = this.streamResponse.Sid;
                message.Restart = true;
            }

            var response = this.SendSync(XmppSerializer.Serialize(message));

#warning TODO: If no <stream:features/> element is included in the connection manager's session creation response, then the client SHOULD send empty request elements until it receives a response containing a <stream:features/> element.

            if (response != null)
            {
                this.streamResponse = response;

                this.ProcessResponse(response);

#warning TODO: Check if the response has an stream-features element
                this.OnXmppStreamInitializedSubject.OnNext(String.Empty);
            }
            else
            {
#warning TODO: Review how to handle this case
                throw new Exception("");
            }
        }

        /// <summary>
        /// Sends a new message.
        /// </summary>
        /// <param elementname="message">The message to be sent</param>
        public override void Send(object message)
        {
            var body = new HttpBindBody
            {
                Rid = (this.rid++).ToString()
              , Sid = this.streamResponse.Sid
            };

            body.Items.Add(message);

            this.Send(XmppSerializer.Serialize(body));
        }

        /// <summary>
        /// Sends an XMPP message string to the XMPP Server
        /// </summary>
        /// <param name="value"></param>
        public override void Send(string value)
        {
            this.Send(Encoding.UTF8.GetBytes(value));
        }

        /// <summary>
        /// Sends an XMPP message buffer to the XMPP Server
        /// </summary>
        public override void Send(byte[] buffer)
        {
            this.ProcessResponse(this.SendSync(buffer));
        }

        /// <summary>
        /// Sends an XMPP message buffer to the XMPP Server
        /// </summary>
        public HttpBindBody SendSync(byte[] buffer)
        {
            Debug.WriteLine(Encoding.UTF8.GetString(buffer));

            lock (this.SyncWrites)
            {
                HttpWebRequest webRequest = this.CreateWebRequest();

                using (System.IO.Stream stream = webRequest.GetRequestStream())
                {
                    stream.Write(buffer, 0, buffer.Length);

                    using (var webResponse = (HttpWebResponse)webRequest.GetResponse())
                    {
                        if (webResponse.StatusCode == HttpStatusCode.OK)
                        {
                            using (var responseStream = webResponse.GetResponseStream())
                            {
                                using (var  responseReader = new StreamReader(responseStream, true))
                                {
                                    string response = responseReader.ReadToEnd();

                                    Debug.WriteLine(response);

                                    return XmppSerializer.Deserialize("body", response) as HttpBindBody;
                                }
                            }
                        }
                    }
                }

                return null;
            }
        }

        public override void Close()
        {
            base.Close();

            ServicePointManager.ServerCertificateValidationCallback -= new RemoteCertificateValidationCallback(ValidateRemoteCertificate);

            this.streamResponse = null;
            this.rid            = 0;
        }

        #endregion

        #region · Private Methods ·

        private void ProcessResponse(HttpBindBody response)
        {
            foreach (object item in response.Items)
            {
                this.OnMessageReceivedSubject.OnNext(item);
            }
        }

        private HttpWebRequest CreateWebRequest()
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create
            (
                String.Format("https://{0}/http-bind", this.ConnectionString.HostName)
            );

            webRequest.ContentType            = HttpTransport.ContentType;
            webRequest.Method                 = "POST";
            webRequest.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            return webRequest;
        }

        /// <summary>
        /// Sends a new message.
        /// </summary>
        /// <param elementname="message">The message to be sent</param>
        private void Send(HttpBindBody message)
        {
            this.Send(XmppSerializer.Serialize(message));
        }

        #endregion
    }
}
