// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Core.Sasl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// <see cref="XmppAuthenticator" /> implementation for the SASL Digest Authentication mechanism.
    /// </summary>
    /// <remarks>
    /// References:
    ///     http://www.ietf.org/html.charters/sasl-charter.html
    ///     http://www.ietf.org/internet-drafts/draft-ietf-sasl-rfc2831bis-09.txt
    /// </remarks>
    internal sealed class XmppSaslDigestAuthenticator 
        : XmppAuthenticator
    {
        #region · Static Methods ·

        private static Dictionary<string, string> DecodeDigestChallenge(Challenge challenge)
        {
            var table    = new Dictionary<string, string>();
            var decoded  = Encoding.UTF8.GetString(Convert.FromBase64String(challenge.Value));
            var keyPairs = Regex.Matches(decoded, @"([\w\s\d]*)\s*=\s*([^,]*)");

            foreach (Match match in keyPairs)
            {
                if (match.Success && match.Groups.Count == 3)
                {
                    string key      = match.Groups[1].Value.Trim();
                    string value    = match.Groups[2].Value.Trim();

                    // Strip quotes from the value
                    if (value.StartsWith("\"", StringComparison.OrdinalIgnoreCase) 
                     || value.StartsWith("'", StringComparison.OrdinalIgnoreCase))
                    {
                        value = value.Remove(0, 1);
                    }
                    if (value.EndsWith("\"", StringComparison.OrdinalIgnoreCase) 
                     || value.EndsWith("'", StringComparison.OrdinalIgnoreCase))
                    {
                        value = value.Remove(value.Length - 1, 1);
                    }

                    if (key == "nonce" && table.ContainsKey(key))
                    {
                        return null;
                    }

                    table.Add(key, value);
                }
            }

            return table;
        }

        #endregion

        #region · Fields ·

        private Dictionary<string, string> digestChallenge;
        private AutoResetEvent	           successEvent;
        private string			           cnonce;

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppSaslDigestAuthenticator"/> class.
        /// </summary>
        public XmppSaslDigestAuthenticator(XmppConnection connection) 
            : base(connection)
        {
            this.cnonce       = Convert.ToBase64String(Encoding.UTF8.GetBytes(XmppIdentifierGenerator.Generate()));
            this.successEvent = new AutoResetEvent(false);
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// Performs the authentication using the SASL digest authentication mechanism.
        /// </summary>
        public override void Authenticate()
        {
            // Send authentication mechanism
            Auth auth = new Auth();
            auth.Mechanism = XmppCodes.SaslDigestMD5Mechanism;

            this.Connection.Send(auth);

            this.successEvent.WaitOne();

            // Verify received Digest-Challenge
            
            // Check that the nonce setting is pressent
            if (!this.digestChallenge.ContainsKey("nonce"))
            {
                throw new XmppException("SASL Authrization failed. Incorrect challenge received from server");
            }

            // Check that the charset is correct
            if (this.digestChallenge.ContainsKey("charset") 
             && this.digestChallenge["charset"] != "utf-8")
            {
                throw new XmppException("SASL Authrization failed. Incorrect challenge received from server");
            }

            // Check that the mechanims is correct
            if (!this.digestChallenge.ContainsKey("algorithm") 
             || this.digestChallenge["algorithm"] != "md5-sess")
            {
                throw new XmppException("SASL Authrization failed. Incorrect challenge received from server");
            }

            // Send the Digest-Reponse
            Response digestResponse = new Response();

            digestResponse.Value = this.BuildDigestRespose();

            this.Connection.Send(digestResponse);

            this.successEvent.WaitOne();

            if (this.digestChallenge.ContainsKey("rspauth"))
            {
                digestResponse = new Response();
                this.Connection.Send(digestResponse);

                this.successEvent.WaitOne();
            }

            if (!this.AuthenticationFailed)
            {
                // Re-Initialize XMPP Stream
                this.Connection.InitializeXmppStream();

                // Wait until we receive the Stream features
                this.Connection.WaitForStreamFeatures();
            }
        }
    
        #endregion

        #region · Protected Methods ·

        protected override void OnUnhandledMessage(object sender, XmppUnhandledMessageEventArgs e)
        {
            if (e.StanzaInstance is Challenge)
            {
                // Response to teh Authentication Information Request
                this.digestChallenge = DecodeDigestChallenge((Challenge)e.StanzaInstance);
                this.successEvent.Set();
            }
            else if (e.StanzaInstance is Success)
            {
                this.successEvent.Set();
            }
        }

        protected override void OnAuthenticationError(object sender, XmppAuthenticationFailiureEventArgs e)
        {
            base.OnAuthenticationError(sender, e);

            this.successEvent.Set();
        }

        #endregion

        #region · Private Methods ·

        private string BuildDigestRespose()
        {
            var response  = new StringBuilder();
            var digestUri = String.Empty;

            response.AppendFormat("username=\"{0}\",", this.Connection.UserId.UserName);

            if (this.digestChallenge.ContainsKey("realm"))
            {
                response.AppendFormat("realm=\"{0}\",", this.digestChallenge["realm"]);
                
                digestUri = String.Format("xmpp/{0}", this.digestChallenge["realm"]);
            }
            else
            {
                digestUri = String.Format("xmpp/{0}", this.Connection.HostName);
            }

            response.AppendFormat("nonce=\"{0}\","      , this.digestChallenge["nonce"]);
            response.AppendFormat("cnonce=\"{0}\","     , this.cnonce);
            response.AppendFormat("nc={0},"             , "00000001");
            response.AppendFormat("qop={0},"            , this.SelectProtectionQuality());
            response.AppendFormat("digest-uri=\"{0}\"," , digestUri);
            response.AppendFormat("response={0},"       , this.GenerateResponseValue());
            response.AppendFormat("charset={0}"         , this.digestChallenge["charset"]);

            return Encoding.UTF8.GetBytes(response.ToString()).ToBase64String();
        }

        private string GenerateResponseValue()
        {
            string realm	 = ((this.digestChallenge.ContainsKey("realm")) ? this.digestChallenge["realm"] : this.Connection.HostName);
            string nonce	 = this.digestChallenge["nonce"].ToString();
            string userId	 = this.Connection.UserId.UserName;
            string password	 = this.Connection.UserPassword;
            string digestURI = String.Format("xmpp/{0}", realm);
            string quop		 = this.SelectProtectionQuality();

            /*
            If authzid is specified, then A1 is
                A1 = { H( { username-value, ":", realm-value, ":", passwd } ),
                    ":", nonce-value, ":", cnonce-value, ":", authzid-value }

            If authzid is not specified, then A1 is
                A1 = { H( { username-value, ":", realm-value, ":", passwd } ),
                    ":", nonce-value, ":", cnonce-value }
            */
            using (MemoryStream a1 = new MemoryStream())
            {
                byte[] a1hash = (new string[] { userId, ":", realm, ":", password }).ComputeMD5Hash();
                byte[] temp   = Encoding.UTF8.GetBytes(String.Format(":{0}:{1}", nonce, this.cnonce));

                // There are no authzid-value
                a1.Write(a1hash, 0, a1hash.Length);
                a1.Write(temp, 0, temp.Length);

                /*
                HEX(H(A2))

                If the "qop" directive's value is "auth", then A2 is:
                    A2       = { "AUTHENTICATE:", digest-uri-value }

                If the "qop" value is "auth-int" or "auth-conf" then A2 is:
                    A2       = { "AUTHENTICATE:", digest-uri-value,
                            ":00000000000000000000000000000000" }
                */

                string a2 = "AUTHENTICATE:" + digestURI + ((quop == "auth") ? null : ":00000000000000000000000000000000");

                /*
                KD(k, s) = H({k, ":", s}), 

                HEX( KD ( HEX(H(A1)),
                     { nonce-value, ":" nc-value, ":",
                       cnonce-value, ":", qop-value, ":", HEX(H(A2)) }))
                */
                /*
                return XmppSaslDigestAuthenticator.ConvertToHex(
                        XmppSaslDigestAuthenticator.ComputeHash(
                            XmppSaslDigestAuthenticator.ConvertToHex(XmppSaslDigestAuthenticator.ComputeHash(a1.ToArray())), ":",
                            nonce, ":", "00000001", ":", cnonce, ":", quop, ":",
                            XmppSaslDigestAuthenticator.ConvertToHex(XmppSaslDigestAuthenticator.ComputeHash(a2)))
                            );
                 */

                string hexA1 = a1.ToArray().ComputeMD5Hash().ToHexString();
                string hexA2 = (new string[] { a2 }).ComputeMD5Hash().ToHexString();

                return (new string[] { hexA1, ":", nonce, ":", "00000001", ":", cnonce, ":", quop, ":", hexA2 }).ComputeMD5Hash().ToHexString();
            }
        }

        private string SelectProtectionQuality()
        {
            if (this.digestChallenge.ContainsKey("qop-options"))
            {
                string[] quopOptions = this.digestChallenge["qop-options"].Split(',');

                foreach (string quo in quopOptions)
                {
                    switch (quo)
                    {
                        case "auth-int":
                        case "auth-conf":
                            break;

                        case "auth":
                        default:
                            return quo;
                    }
                }
            }

            return "auth";
        }

        #endregion
    }
}
