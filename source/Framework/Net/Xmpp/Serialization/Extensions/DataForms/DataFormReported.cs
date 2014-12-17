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
    [XmlRootAttribute("reported", Namespace="jabber:x:data", IsNullable=false)]
    public class DataFormReported 
    {
        #region · Fields ·

        private List<DataFormField> fields;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlArrayItemAttribute("field")]
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

        #endregion

        #region · Constructors ·

        public DataFormReported()
        {
        }

        #endregion
    }
}
