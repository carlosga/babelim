// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.DataForms 
{      
    /// <remarks/>
    [XmlTypeAttribute(Namespace="jabber:x:data")]
    public enum DataFormType 
    {        
        /// <remarks/>
        [XmlEnumAttribute("cancel")]
        Cancel,
        
        /// <remarks/>
        [XmlEnumAttribute("form")]
        Form,
        
        /// <remarks/>
        [XmlEnumAttribute("result")]
        Result,
        
        /// <remarks/>
        [XmlEnumAttribute("submit")]
        Submit,
    }
}
