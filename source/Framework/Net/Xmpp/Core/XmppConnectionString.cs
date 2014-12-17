// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Represents a Connection String
    /// </summary>
    public sealed class XmppConnectionString
    {
        #region · Static Fields ·

        /// <summary>
        /// Synonyms list
        /// </summary>
        static Dictionary<string, string> Synonyms = GetSynonyms();

        #endregion

        #region · Static Methods ·

        /// <summary>
        /// Gets a value indicating whether the given key value is a synonym
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsSynonym(string key)
        {
            return Synonyms.ContainsKey(key);
        }

        /// <summary>
        /// Gets the synonym for the give key value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSynonym(string key)
        {
            return Synonyms[key];
        }

        /// <summary>
        /// Gets the synonyms.
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetSynonyms()
        {
            Dictionary<string, string> synonyms = new Dictionary<string, string>();

            synonyms.Add("server"            , "server");
            synonyms.Add("port number"       , "port number");
            synonyms.Add("user id"           , "user id");
            synonyms.Add("uid"               , "user id");
            synonyms.Add("user password"     , "user password");
            synonyms.Add("resource"          , "resource");
            synonyms.Add("connection timeout", "connection timeout");
            synonyms.Add("use proxy"         , "use proxy");
            synonyms.Add("proxy type"        , "proxy type");
            synonyms.Add("proxy server"      , "proxy server");
            synonyms.Add("proxy port number" , "proxy port number");
            synonyms.Add("proxy user name"   , "proxy user name");
            synonyms.Add("proxy password"    , "proxy password");
            synonyms.Add("http binding"      , "http binding");
            synonyms.Add("resolve host name" , "resolve host name");

            return synonyms;
        }

        #endregion

        #region · Fields ·

        private Dictionary<string, object> options;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the login server.
        /// </summary>
        /// <value>The server.</value>
        public string HostName
        {
            get { return this.GetString("server"); }
        }

        /// <summary>
        /// Gets a value indicating whether to resolve host names.
        /// </summary>
        /// <value>
        ///   <c>true</c> if host name should be resolved; otherwise, <c>false</c>.
        /// </value>
        public bool ResolveHostName
        {
            get { return this.GetBoolean("resolve host name"); }
        }

        /// <summary>
        /// Gets the port number.
        /// </summary>
        /// <value>The port.</value>
        public int PortNumber
        {
            get { return this.GetInt32("port number"); }
        }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        /// <value>The user id.</value>
        public string UserId
        {
            get { return this.GetString("user id"); }
        }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>The password.</value>
        public string UserPassword
        {
            get { return this.GetString("user password"); }
        }

        /// <summary>
        /// Gets the connection timeout.
        /// </summary>
        /// <value>The connection timeout.</value>
        public int ConnectionTimeout
        {
            get { return this.GetInt32("connection timeout"); }
        }

        /// <summary>
        /// Gets a value that indicating whether the connection should be done throught a proxy
        /// </summary>
        public bool UseProxy
        {
            get { return this.GetBoolean("use proxy"); }
        }

        /// <summary>
        /// Gets the proxy type
        /// </summary>
        public string ProxyType
        {
            get { return this.GetString("proxy type"); }
        }

        /// <summary>
        /// Gets the proxy server
        /// </summary>
        public string ProxyServer
        {
            get { return this.GetString("proxy server"); }
        }

        /// <summary>
        /// Gets the proxy port number
        /// </summary>
        public int ProxyPortNumber
        {
            get { return this.GetInt32("proxy port number"); }
        }

        /// <summary>
        /// Gets the proxy user name
        /// </summary>
        public string ProxyUserName
        {
            get { return this.GetString("proxy user name"); }
        }

        /// <summary>
        /// Gets the proxy password
        /// </summary>
        public string ProxyPassword
        {
            get { return this.GetString("proxy password"); }
        }

        /// <summary>
        /// Gets a value that indicates if http binding should be used
        /// </summary>
        public bool UseHttpBinding
        {
            get { return this.GetBoolean("http binding"); }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppConnectionString"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public XmppConnectionString(string connectionString)
        {
            this.options = new Dictionary<string, object>();
            this.Load(connectionString);
        }

        #endregion

        #region · Overriden methods ·

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            var cs = new StringBuilder();
            var e  = this.options.GetEnumerator();

            while (e.MoveNext())
            {
                if (e.Current.Value != null)
                {
                    if (cs.Length > 0)
                    {
                        cs.Append(";");
                    }

                    string key = CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(e.Current.Key.ToString());
                    cs.AppendFormat(CultureInfo.CurrentUICulture, "{0}={1}", key, e.Current.Value);
                }
            }

            return cs.ToString();
        }

        #endregion

        #region · Private Methods ·

        private void SetDefaultOptions()
        {
            this.options.Clear();

            this.options.Add("login server"      , null);
            this.options.Add("port number"       , 5222);
            this.options.Add("user id"           , null);
            this.options.Add("user password"     , null);
            this.options.Add("resource"          , null);
            this.options.Add("sasl"              , false);
            this.options.Add("connection timeout", -1);
        }

        private void Load(string connectionString)
        {
            string[] keyPairs = connectionString.Split(';');

            this.SetDefaultOptions();

            foreach (string keyPair in keyPairs)
            {
                string[] values = keyPair.Split('=');

                if (values.Length == 2 
                 && !String.IsNullOrEmpty(values[0])
                 && !String.IsNullOrEmpty(values[1]))
                {
                    values[0] = values[0].ToLower(CultureInfo.CurrentUICulture);

                    if (Synonyms.ContainsKey(values[0]))
                    {
                        this.options[(string)Synonyms[values[0]]] = values[1].Trim();
                    }
                }
            }

            this.Validate();
        }

        private void Validate()
        {
            if (String.IsNullOrEmpty(this.HostName) 
             || String.IsNullOrEmpty(this.UserId) 
             || String.IsNullOrEmpty(this.UserPassword))
            {
                throw new XmppException("Invalid connection string options.");
            }
        }

        private string GetString(string key)
        {
            if (this.options.ContainsKey(key))
            {
                return (string)this.options[key];
            }
            
            return null;
        }

        private int GetInt32(string key)
        {
            if (this.options.ContainsKey(key))
            {
                return Convert.ToInt32(this.options[key], CultureInfo.CurrentUICulture);
            }
        
            return 0;
        }

        private bool GetBoolean(string key)
        {
            if (this.options.ContainsKey(key))
            {
                return Convert.ToBoolean(this.options[key], CultureInfo.CurrentUICulture);
            }

            return false;
        }

        #endregion
    }
}
