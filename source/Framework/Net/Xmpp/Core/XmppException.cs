// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using BabelIm.Net.Xmpp.Serialization.Core.Streams;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;

namespace BabelIm.Net.Xmpp.Core
{
    /// <summary>
    /// Exception for XMPP related errors.
    /// </summary>
    [Serializable]
    public sealed class XmppException 
        : SystemException
    {
        #region · Static Methods ·

        private static string GetStreamErrorMessage(StreamError message)
        {
            StringBuilder exceptionMessage = new StringBuilder();

            if (message.BadFormat != null)
            {
                exceptionMessage.Append("bad-format");
            }
            else if (message.BadNamespacePrefix != null)
            {
                exceptionMessage.Append("bad-namespace-prefix");
            }
            else if (message.Conflict != null)
            {
                exceptionMessage.Append("conflict");
            }
            else if (message.ConnectionTimeout != null)
            {
                exceptionMessage.Append("connection-timeout");
            }
            else if (message.HostGone != null)
            {
                exceptionMessage.Append("host-gone");
            }
            else if (message.HostUnknown != null)
            {
                exceptionMessage.Append("host-unknown");
            }
            else if (message.ImproperAddressing != null)
            {
                exceptionMessage.Append("improper-addressing");
            }
            else if (message.InternalServerError != null)
            {
                exceptionMessage.Append("internal-server-error");
            }
            else if (message.InvalidFrom != null)
            {
                exceptionMessage.Append("invalid-from");
            }
            else if (message.InvalidID != null)
            {
                exceptionMessage.Append("invalid-id");
            }
            else if (message.InvalidNamespace != null)
            {
                exceptionMessage.Append("invalid-namespace");
            }
            else if (message.InvalidXml != null)
            {
                exceptionMessage.Append("invalid-xml");
            }
            else if (message.NotAuthorized != null)
            {
                exceptionMessage.Append("not-authorized");
            }
            else if (message.PolicyViolation != null)
            {
                exceptionMessage.Append("policy-violation");
            }
            else if (message.RemoteConnectionFailed != null)
            {
                exceptionMessage.Append("remote-connection-failed");
            }
            else if (message.ResourceConstraint != null)
            {
                exceptionMessage.Append("resource-constraint");
            }
            else if (message.RestrictedXml != null)
            {
                exceptionMessage.Append("restricted-xml");
            }
            else if (message.SeeOtherHost != null)
            {
                exceptionMessage.Append("see-other-host");
            }
            else if (message.SystemShutdown != null)
            {
                exceptionMessage.Append("system-shutdown");
            }
            else if (message.UndefinedCondition != null)
            {
                exceptionMessage.Append("undefined-condition");
            }
            else if (message.UnsupportedEncoding != null)
            {
                exceptionMessage.Append("unsupported-encoding");
            }
            else if (message.UnsupportedStanzaType != null)
            {
                exceptionMessage.Append("unsupported-stanza-type");
            }
            else if (message.UnsupportedVersion != null)
            {
                exceptionMessage.Append("unsupported-version");
            }
            else if (message.XmlNotWellFormed != null)
            {
                exceptionMessage.Append("xml-not-well-formed");
            }

            if (message.Text != null && message.Text.Value != null)
            {
                exceptionMessage.AppendFormat("{0}{1}", Environment.NewLine, message.Text.Value);
            }

            return exceptionMessage.ToString();
        }

        #endregion

        #region · Constructors ·

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppException"/> class.
        /// </summary>
        public XmppException() 
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppException"/> class with the given class
        /// </summary>
        /// <param name="message">The XMPP Stream error.</param>
        public XmppException(StreamError error)
            : base(GetStreamErrorMessage(error))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppException"/> class with the given class
        /// </summary>
        /// <param name="message">The message.</param>
        public XmppException(string message) 
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppException"/> class with the
        /// given message and inner exception.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public XmppException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XmppException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        private XmppException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region · Methods ·

        /// <summary>
        /// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with information about the exception.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.ArgumentNullException">The info parameter is a null reference (Nothing in Visual Basic). </exception>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/></PermissionSet>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter=true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        #endregion
    }
}
