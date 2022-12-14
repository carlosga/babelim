/*
    Copyright (c) 2007 - 2010, Carlos Guzm?n ?lvarez

    All rights reserved.

    Redistribution and use in source and binary forms, with or without modification, 
    are permitted provided that the following conditions are met:

        * Redistributions of source code must retain the above copyright notice, 
          this list of conditions and the following disclaimer.
        * Redistributions in binary form must reproduce the above copyright notice, 
          this list of conditions and the following disclaimer in the documentation and/or 
          other materials provided with the distribution.
        * Neither the name of the author nor the names of its contributors may be used to endorse or 
          promote products derived from this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
    "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
    LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
    A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
    CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
    EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
    PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
    PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
    LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
    NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BabelIm.Configuration
{
    [XmlType(TypeName = "notifications"), Serializable]
    public sealed class Notifications
    {
    	#region ? Fields ?
    	
    	private NotificationCollection notificationCollection;
    	
    	#endregion

        #region ? Indexers ?

        [XmlIgnore]
        public Notification this[int index]
        {
            get { return (Notification)NotificationCollection[index]; }
        }
        
        #endregion
    	
        #region ? Properties ?

        [XmlIgnore]
        public int Count
        {
            get { return NotificationCollection.Count; }
        }
        
        [XmlElement(Type = typeof(Notification), ElementName = "Notification", IsNullable = false, Form = XmlSchemaForm.Qualified)]
        public NotificationCollection NotificationCollection
        {
            get
            {
                if (this.notificationCollection == null) 
                {
                	this.notificationCollection = new NotificationCollection();
                }
                
                return this.notificationCollection;
            }
            set { this.notificationCollection = value; }
        }
        
        #endregion
    	
        #region ? Constructors ?
        
        public Notifications()
        {
        }
        
        #endregion
        
    	#region ? Methods ?
    	
        [System.Runtime.InteropServices.DispIdAttribute(-4)]
        public IEnumerator GetEnumerator()
        {
            return NotificationCollection.GetEnumerator();
        }

        public Notification Add(Notification obj)
        {
            return NotificationCollection.Add(obj);
        }

        public void Clear()
        {
            NotificationCollection.Clear();
        }

        public Notification Remove(int index)
        {
            Notification obj = NotificationCollection[index];
            NotificationCollection.Remove(obj);
            return obj;
        }

        public void Remove(object obj)
        {
            NotificationCollection.Remove(obj);
        }
        
        #endregion        
    }
}
