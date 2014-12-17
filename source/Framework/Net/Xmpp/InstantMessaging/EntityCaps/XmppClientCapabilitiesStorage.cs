// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.InstantMessaging
{
    /// <summary>
    /// Entity capabilities store
    /// </summary>
    [Serializable]
    [XmlTypeAttribute(Namespace = "")]
    [XmlRootAttribute("capabilities", Namespace = "", IsNullable = false)]
    public sealed class XmppClientCapabilitiesStorage
    {
        #region · Static Members ·
        
         private static XmlSerializer Serializer = new XmlSerializer(typeof(XmppClientCapabilitiesStorage));
        
        #endregion
        
        #region · Consts ·
        
        const string ClientCapabilitiesFile = "ClientCapabilities.xml";
        
        #endregion
        
        #region · Fields ·
        
        private List<XmppClientCapabilities> clientCapabilities;
        
        #endregion
        
        #region · Properties ·

        [XmlArray("caps")]
        [XmlArrayItem("client", typeof(XmppClientCapabilities))]
        public List<XmppClientCapabilities> ClientCapabilities
        {
            get
            {
                if (this.clientCapabilities == null)
                {
                    this.clientCapabilities = new List<XmppClientCapabilities>();
                }
                
                return this.clientCapabilities;
            }
        }
        
        #endregion
        
        #region · Constructors ·

        public XmppClientCapabilitiesStorage()
        {
        }
        
        #endregion
        
        #region · Methods ·
        
        public bool Exists(string node, string verificationString)
        {
            return (this.Get(node, verificationString) != null);
        }
        
        public XmppClientCapabilities Get(string node, string verificationString)
        {
            return (this.ClientCapabilities.Where(c => c.Node == node && c.VerificationString == verificationString).SingleOrDefault());
        }

        public void Load()
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                if (storage.FileExists(ClientCapabilitiesFile))
                {
                    using (IsolatedStorageFileStream stream =
                                new IsolatedStorageFileStream(ClientCapabilitiesFile, FileMode.OpenOrCreate, storage))
                    {
                        if (stream.Length > 0)
                        {
                            XmppClientCapabilitiesStorage capsstorage = (XmppClientCapabilitiesStorage)Serializer.Deserialize(stream);

                            this.ClientCapabilities.AddRange(capsstorage.ClientCapabilities);
                        }
                    }
                }
            }
        }

        public void Save()
        {
            using (IsolatedStorageFile storage = IsolatedStorageFile.GetUserStoreForAssembly())
            {
                using (IsolatedStorageFileStream stream = 
                            new IsolatedStorageFileStream(ClientCapabilitiesFile, FileMode.OpenOrCreate, storage))
                {
                    // Save Caps as XML
                    using (XmlTextWriter xmlWriter  = new XmlTextWriter(stream, Encoding.UTF8))
                    {
                        // Writer settings
                        xmlWriter.QuoteChar     = '\'';
                        xmlWriter.Formatting    = Formatting.Indented;
        
                        Serializer.Serialize(xmlWriter, this);
                    }
                }
            }
        }
        
        #endregion
    }
}