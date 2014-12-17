// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.DataForms 
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace="jabber:x:data")]
    [XmlRootAttribute("option", Namespace="jabber:x:data", IsNullable=false)]
    public class DataFormOption 
    {   
        #region · Fields ·

        private string value;
        private string label;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlTextAttribute()]
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("label")]
        public string Label
        {
            get { return this.label; }
            set { this.label = value; }
        }

        #endregion

        #region · Constructors ·

        public DataFormOption()
        {
        }

        #endregion
    }
}
