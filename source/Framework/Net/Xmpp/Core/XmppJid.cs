// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using Gnu.Inet.Encoding;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Represents a XMPP JID
    /// </summary>
    public sealed class XmppJid
    {
        #region · Static Members ·

        /// <summary>
        /// Regex used to parse jid strings
        /// </summary>
        private static readonly Regex JidRegex = new Regex
        (
            @"(?:(?<userid>[^\@]{1,1023})\@)?" +        // optional node
            @"(?<domain>[a-zA-Z0-9\.\-]{1,1023})" +     // domain
            @"(?:/(?<resource>.{1,1023}))?",            // resource
            RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.ExplicitCapture | RegexOptions.Compiled
        );

        #endregion

        #region · Fields ·

        private string userName;
        private string domainName;
        private string resourceName;
        private string bareJid;
        private string fullJid;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the Bare JID
        /// </summary>
        public string BareIdentifier
        {
            get { return this.bareJid; }
        }

        /// <summary>
        /// Gets the User Name
        /// </summary>
        public string UserName
        {
            get { return this.userName; }
        }

        /// <summary>
        /// Gets the Domain Name
        /// </summary>
        public string DomainName
        {
            get { return this.domainName; }
        }

        /// <summary>
        /// Gets the Resource Name
        /// </summary>
        public string ResourceName
        {
            get { return this.resourceName; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppJid"/> class with
        /// the given JID
        /// </summary>
        /// <param name="jid">The XMPP jid</param>
        public XmppJid(string jid)
        {
            this.Parse(jid);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppJid"/> class with
        /// the given user name, domain name and resource name.
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="domainName">The domain name</param>
        /// <param name="resourceName">The resource name</param>
        public XmppJid(string userName, string domainName, string resourceName)
        {
            this.userName     = Stringprep.NamePrep(userName);
            this.domainName   = Stringprep.NodePrep(domainName);
            this.resourceName = Stringprep.ResourcePrep(resourceName);

            this.BuildBareAndFullJid();
        }

        #endregion

        #region · Operator Overloading ·

        // Implicit conversion from string to XmppJid. 
        public static implicit operator XmppJid(string x)
        {
            return new XmppJid(x);
        }

        // Explicit conversion from XmppJid to string. 
        public static implicit operator string(XmppJid x)
        {
            if (x == null)
            {
                throw new InvalidOperationException();
            }

            return x.fullJid;
        }

        #endregion

        #region · Overriden Methods ·

        // Override the Object.Equals(object o) method:
        public override bool Equals(object o)
        {
            // If parameter is null return false.
            if (o == null)
            {
                return false;
            }
            if (!(o is XmppJid))
            {
                return false;
            }

            return (this.fullJid == ((XmppJid)o).fullJid);
        }

        // Override the Object.GetHashCode() method:
        public override int GetHashCode()
        {
            return this.fullJid.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return this.fullJid;
        }

        #endregion

        #region · Private Methods ·

        private void Parse(string jid)
        {
            Match match = JidRegex.Match(jid);

            if (match != null)
            {
                if (match.Groups["userid"] != null)
                {
                    this.userName = Stringprep.NamePrep(match.Groups["userid"].Value);
                }
                if (match.Groups["domain"] != null)
                {
                    this.domainName = Stringprep.NodePrep(match.Groups["domain"].Value);
                }
                if (match.Groups["resource"] != null)
                {
                    this.resourceName = Stringprep.ResourcePrep(match.Groups["resource"].Value);
                }
            }

            this.BuildBareAndFullJid();
        }

        private void BuildBareAndFullJid()
        {
            StringBuilder jidBuffer = new StringBuilder();

            if (!String.IsNullOrEmpty(this.UserName))
            {
                jidBuffer.Append(this.UserName);
            }
            if (!String.IsNullOrEmpty(this.DomainName))
            {
                if (jidBuffer.Length > 0)
                {
                    jidBuffer.Append("@");
                }

                jidBuffer.Append(this.DomainName);
            }

            this.bareJid = jidBuffer.ToString();

            if (!String.IsNullOrEmpty(this.ResourceName))
            {
                jidBuffer.AppendFormat("/{0}", this.ResourceName);
            }

            this.fullJid = jidBuffer.ToString();
        }

        #endregion
    }
}
