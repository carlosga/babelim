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
    [XmlRootAttribute("x", Namespace="jabber:x:data", IsNullable=false)]
    public class DataForm 
    {        
        #region · Fields ·

        private List<string>		instructions;
        private string				title;
        private List<DataFormField> fields;
        private DataFormReported	reported;
        private List<DataFormItem>	items;
        private DataFormType		type;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("instructions")]
        public List<string> Instructions
        {
            get
            {
                if (this.instructions == null) 
                {
                    this.instructions = new List<string>();
                }

                return this.instructions;
            }
        }
        
        /// <remarks/>
        [XmlElementAttribute("title")]
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }
        
        /// <remarks/>
        [XmlElementAttribute("field")]
        public List<DataFormField> Fields
        {
            get
            {
                if (this.fields == null) 
                {
                    this.fields = new List<DataFormField>();
                }

                return this.fields;
            }
        }
        
        /// <remarks/>
        [XmlElementAttribute("reported", IsNullable=false)]
        public DataFormReported Reported
        {
            get { return this.reported; }
            set { this.reported = value; }
        }
        
        /// <remarks/>
        [XmlArrayItemAttribute("item", IsNullable=false)]
        public List<DataFormItem> Items
        {
            get
            {
                if (this.items == null) 
                {
                    this.items = new List<DataFormItem>();
                }

                return this.items;
            }
        }
        
        /// <remarks/>
        [XmlAttributeAttribute("type")]
        public DataFormType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        #endregion

        #region · Constructors ·

        public DataForm()
        {
        }

        #endregion
    }
}
