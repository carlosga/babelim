// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization
{
    /// <remarks/>
    [Serializable]
    public enum Empty
    {
        /// <remarks/>
        [XmlEnumAttribute("")]
        Item,
    }
}
