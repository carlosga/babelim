// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.DataForms 
{                  
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace="jabber:x:data")]
    [XmlRootAttribute("field", Namespace="jabber:x:data", IsNullable=false)]
    public class DataFormField 
    {
        #region · Fields ·

        private string				    description;
        private bool				    required;        
        private List<string>		    values;
        private List<DataFormOption>    options;
        private string				    label;
        private DataFormFieldType	    type;
        private string				    var;

        #endregion

        #region · Properties ·

        [XmlElementAttribute("desc")]
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
        
        [XmlElementAttribute("required")]
        public bool Required
        {
            get { return this.required; }
            set { this.required	= value; }
        }
                
        /// <remarks/>
        [XmlArrayItemAttribute("value")]
        public List<string> Values
        {
            get 
            {
                if (this.values == null)
                {
                    this.values = new List<string>();
                }

                return this.values; 
            }
        }
        
        /// <remarks/>
        [XmlArrayItemAttribute("option")]
        public List<DataFormOption> Options
        {
            get 
            {
                if (this.options == null)
                {
                    this.options = new List<DataFormOption>();
                }

                return this.options; 
            }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("label")]
        public string Label
        {
            get { return this.label; }
            set { this.label = value; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("type")]
        public DataFormFieldType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("var")]
        public string Var
        {
            get { return this.var; }
            set { this.var = value; }
        }

        #endregion

        #region · Constructors ·

        public DataFormField()
        {
            this.type = DataFormFieldType.TextSingle;
        }

        #endregion        
    }   
}
