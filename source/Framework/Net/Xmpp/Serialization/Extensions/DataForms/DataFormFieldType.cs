// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Extensions.DataForms 
{   
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(Namespace="jabber:x:data")]
    public enum DataFormFieldType 
    {        
        /// <remarks/>
        [XmlEnumAttribute("boolean")]
        Boolean,
        
        /// <remarks/>
        [XmlEnumAttribute("fixed")]
        Fixed,
        
        /// <remarks/>
        [XmlEnumAttribute("hidden")]
        Hidden,
        
        /// <remarks/>
        [XmlEnumAttribute("jid-multi")]
        JidMulti,
        
        /// <remarks/>
        [XmlEnumAttribute("jid-single")]
        JidSingle,
        
        /// <remarks/>
        [XmlEnumAttribute("list-multi")]
        ListMulti,
        
        /// <remarks/>
        [XmlEnumAttribute("list-single")]
        ListSingle,
        
        /// <remarks/>
        [XmlEnumAttribute("text-multi")]
        TextMulti,
        
        /// <remarks/>
        [XmlEnumAttribute("text-private")]
        TextPrivate,
        
        /// <remarks/>
        [XmlEnumAttribute("text-single")]
        TextSingle,
    }
}
