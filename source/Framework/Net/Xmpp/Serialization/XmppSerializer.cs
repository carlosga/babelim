// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization
{
    /// <summary>
    /// Serializer class for XMPP stanzas
    /// </summary>
    public sealed class XmppSerializer
    {
        #region · Static Fields ·

        private static readonly string XmlSerializersResource = "BabelIm.Net.Xmpp.Serialization.Serializers.xml";

        private static List<XmppSerializer> Serializers = new List<XmppSerializer>();
        private static bool                 Initialized = false;
        private static object				SyncObject	= new object();

        #endregion

        #region · Static Serialization/Deserialization Methods ·

        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static byte[] Serialize(object value)
        {
            Initialize();

            return GetSerializer(value.GetType()).SerializeObject(value);
        }

        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        public static byte[] Serialize(object value, string prefix)
        {
            Initialize();

            return GetSerializer(value.GetType()).SerializeObject(value);
        }

        /// <summary>
        /// Deserializes the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        public static object Deserialize(string nodeName, string xml)
        {
            Initialize();

            XmppSerializer serializer = GetSerializer(nodeName);

            if (serializer != null)
            {
                return serializer.Deserialize(xml);
            }

            return null;
        }

        #endregion

        #region · Static Methods ·

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        static void Initialize()
        {
            lock (SyncObject)
            {
                if (!Initialized)
                {
                    using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(XmlSerializersResource))
                    {
                        using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8))
                        {
                            XmlDocument xml = new XmlDocument();
                            xml.LoadXml(reader.ReadToEnd());
    
                            XmlNodeList list = xml.SelectNodes("/serializers/serializer");
    
                            foreach (XmlNode serializer in list)
                            {
                                XmlNode node = serializer.SelectSingleNode("namespace");
    
                                string 	ename	= serializer.Attributes["elementname"].Value;
                                string 	schema 	= serializer.SelectSingleNode("schema").InnerText;
                                string 	prefix 	= node.SelectSingleNode("prefix").InnerText;
                                string 	nsName 	= node.SelectSingleNode("namespace").InnerText;
                                Type 	type 	= Type.GetType(serializer.SelectSingleNode("serializertype").InnerText);
    
                                Serializers.Add(new XmppSerializer(ename, schema, prefix, nsName, type));
                            }
    
                            Initialized = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns></returns>
        static XmppSerializer GetSerializer(string elementName)
        {
            if (!Initialized)
            {
                throw new InvalidOperationException("Serializers Factory not initialized");
            }

            foreach (XmppSerializer serializer in Serializers)
            {
                if (serializer.ElementName == elementName)
                {
                    return serializer;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the serializer.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        static XmppSerializer GetSerializer(Type type)
        {
            if (!Initialized)
            {
                throw new InvalidOperationException("Serializers Factory not initialized");
            }

            return Serializers.Where(s => s.SerializerType == type).SingleOrDefault();
        }

        #endregion

        #region · Fields ·

        private string					elementName;
        private string					schema;
        private string					prefix;
        private string					defaultNamespace;
        private Type					serializerType;
        private XmlSerializerNamespaces namespaces;
        private XmlSerializer			serializer;
        private XmlNameTable			nameTable;
        private XmlNamespaceManager		nsMgr;
        private XmlParserContext		context;

        #endregion

        #region · Properties ·

        /// <summary>
        /// Gets the name of the element.
        /// </summary>
        /// <value>The name of the element.</value>
        public string ElementName
        {
            get { return this.elementName; }
        }

        /// <summary>
        /// Gets the schema.
        /// </summary>
        /// <value>The schema.</value>
        public string Schema
        {
            get { return this.schema; }
        }

        /// <summary>
        /// Gets the prefix.
        /// </summary>
        /// <value>The prefix.</value>
        public string Prefix
        {
            get { return this.prefix; }
        }

        /// <summary>
        /// Gets the default namespace.
        /// </summary>
        /// <value>The default namespace.</value>
        public string DefaultNamespace
        {
            get { return this.defaultNamespace; }
        }

        /// <summary>
        /// Gets the type of the serializer.
        /// </summary>
        /// <value>The type of the serializer.</value>
        public Type SerializerType
        {
            get { return this.serializerType; }
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="XmppSerializer"/> class.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="schema">The schema.</param>
        /// <param name="prefix">The prefix.</param>
        /// <param name="defaultNamespace">The default namespace.</param>
        /// <param name="serializerType">Type of the serializer.</param>
        private XmppSerializer(string elementName, string schema, string prefix, string defaultNamespace, Type serializerType)
        {
            this.elementName		= elementName;
            this.serializerType		= serializerType;
            this.schema				= schema;
            this.prefix				= prefix;
            this.defaultNamespace	= defaultNamespace;
            this.serializer         = new XmlSerializer(serializerType);
            this.nameTable			= new NameTable();
            this.nsMgr				= new XmlNamespaceManager(this.nameTable);
            this.context			= new XmlParserContext(this.nameTable, this.nsMgr, null, XmlSpace.None);
            this.namespaces			= new XmlSerializerNamespaces();
            this.namespaces.Add(prefix, defaultNamespace);

            foreach (XmlQualifiedName name in this.namespaces.ToArray())
            {
                this.nsMgr.AddNamespace(name.Name, name.Namespace);
            }
        }

        #endregion

        #region · Private Methods ·

        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private byte[] SerializeObject(object value)
        {
            return this.SerializeObject(value, "");
        }

        /// <summary>
        /// Serializes the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="prefix">The prefix.</param>
        /// <returns></returns>
        private byte[] SerializeObject(object value, string prefix)
        {
            byte[]		    result	= null;
            MemoryStream	ms		= null;
            XmppTextWriter	tw		= null;

            try
            {
                ms		= new MemoryStream();
                tw		= new XmppTextWriter(ms);
        
                tw.QuoteChar = '\'';

                serializer.Serialize(tw, value, this.namespaces);

                result = ms.ToArray();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (ms != null)
                {
                    ms.Close();
                    ms = null;
                }
                if (tw != null)
                {
                    tw.Close();
                    tw = null;
                }
            }

            return result;
        }

        /// <summary>
        /// Deserializes the specified XML.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <returns></returns>
        private object Deserialize(string xml)
        {
            using (XmlTextReader reader = new XmlTextReader(xml, XmlNodeType.Element, this.context))
            {
                return this.serializer.Deserialize(reader);
            }
        }

        #endregion
    }
}
