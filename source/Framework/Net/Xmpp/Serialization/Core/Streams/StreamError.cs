// Copyright (c) Carlos Guzmán Álvarez. All rights reserved.
// Licensed under the New BSD License (BSD). See LICENSE file in the project root for full license information.

using System;
using System.Xml.Serialization;

namespace BabelIm.Net.Xmpp.Serialization.Core.Streams
{
    /// <remarks/>
    [Serializable]
    [XmlTypeAttribute(TypeName = "error", Namespace = "http://etherx.jabber.org/streams")]
    [XmlRootAttribute("error", Namespace = "http://etherx.jabber.org/streams", IsNullable = false)]
    public class StreamError
    {
        #region · Fields ·

        private string badformatField;
        private string badnamespaceprefixField;
        private string conflictField;
        private string connectiontimeoutField;
        private string hostgoneField;
        private string hostunknownField;
        private string improperaddressingField;
        private string internalservererrorField;
        private string invalidfromField;
        private string invalididField;
        private string invalidnamespaceField;
        private string invalidxmlField;
        private string notauthorizedField;
        private string policyviolationField;
        private string remoteconnectionfailedField;
        private string resourceconstraintField;
        private string restrictedxmlField;
        private string seeotherhostField;
        private string systemshutdownField;
        private string undefinedconditionField;
        private string unsupportedencodingField;
        private string unsupportedstanzatypeField;
        private string unsupportedversionField;
        private string xmlnotwellformedField;
        private StreamErrorText textField;

        #endregion

        #region · Properties ·

        /// <remarks/>
        [XmlElementAttribute("bad-format", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string BadFormat
        {
            get { return this.badformatField; }
            set { this.badformatField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("bad-namespace-prefix", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string BadNamespacePrefix
        {
            get { return this.badnamespaceprefixField; }
            set { this.badnamespaceprefixField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("conflict", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string Conflict
        {
            get { return this.conflictField; }
            set { this.conflictField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("connection-timeout", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string ConnectionTimeout
        {
            get { return this.connectiontimeoutField; }
            set { this.connectiontimeoutField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("host-gone", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string HostGone
        {
            get { return this.hostgoneField; }
            set { this.hostgoneField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("host-unknown", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string HostUnknown
        {
            get { return this.hostunknownField; }
            set { this.hostunknownField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("improper-addressing", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string ImproperAddressing
        {
            get { return this.improperaddressingField; }
            set { this.improperaddressingField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("internal-server-error", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string InternalServerError
        {
            get { return this.internalservererrorField; }
            set { this.internalservererrorField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("invalid-from", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string InvalidFrom
        {
            get { return this.invalidfromField; }
            set { this.invalidfromField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("invalid-id", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string InvalidID
        {
            get { return this.invalididField; }
            set { this.invalididField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("invalid-namespace", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string InvalidNamespace
        {
            get { return this.invalidnamespaceField; }
            set { this.invalidnamespaceField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("invalid-xml", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable = true)]
        public string InvalidXml
        {
            get { return this.invalidxmlField; }
            set { this.invalidxmlField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("not-authorized", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string NotAuthorized
        {
            get { return this.notauthorizedField; }
            set { this.notauthorizedField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("policy-violation", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string PolicyViolation
        {
            get { return this.policyviolationField; }
            set { this.policyviolationField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("remote-connection-failed", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string RemoteConnectionFailed
        {
            get { return this.remoteconnectionfailedField; }
            set { this.remoteconnectionfailedField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("resource-constraint", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string ResourceConstraint
        {
            get { return this.resourceconstraintField; }
            set { this.resourceconstraintField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("restricted-xml", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string RestrictedXml
        {
            get { return this.restrictedxmlField; }
            set { this.restrictedxmlField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("see-other-host", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string SeeOtherHost
        {
            get { return this.seeotherhostField; }
            set { this.seeotherhostField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("system-shutdown", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string SystemShutdown
        {
            get { return this.systemshutdownField; }
            set { this.systemshutdownField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("undefined-condition", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string UndefinedCondition
        {
            get { return this.undefinedconditionField; }
            set { this.undefinedconditionField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("unsupported-encoding", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string UnsupportedEncoding
        {
            get { return this.unsupportedencodingField; }
            set { this.unsupportedencodingField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("unsupported-stanza-type", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string UnsupportedStanzaType
        {
            get { return this.unsupportedstanzatypeField; }
            set { this.unsupportedstanzatypeField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("unsupported-version", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string UnsupportedVersion
        {
            get { return this.unsupportedversionField; }
            set { this.unsupportedversionField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("xml-not-well-formed", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public string XmlNotWellFormed
        {
            get { return this.xmlnotwellformedField; }
            set	{ this.xmlnotwellformedField = value; }
        }

        /// <remarks/>
        [XmlElementAttribute("text", Namespace = "urn:ietf:params:xml:ns:xmpp-streams", IsNullable=true)]
        public StreamErrorText Text
        {
            get { return this.textField; }
            set { this.textField = value; }
        }

        #endregion

        #region · Constructors ·

        public StreamError()
        {
        }

        #endregion
    }
}
