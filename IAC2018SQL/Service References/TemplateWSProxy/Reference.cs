﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IAC2021SQL.TemplateWSProxy {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TemplateDetail", Namespace="http://SBTAPIService/DataContract/")]
    [System.SerializableAttribute()]
    public partial class TemplateDetail : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int TemplateIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TitleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrgCodeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public int TemplateID {
            get {
                return this.TemplateIDField;
            }
            set {
                if ((this.TemplateIDField.Equals(value) != true)) {
                    this.TemplateIDField = value;
                    this.RaisePropertyChanged("TemplateID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Subject {
            get {
                return this.SubjectField;
            }
            set {
                if ((object.ReferenceEquals(this.SubjectField, value) != true)) {
                    this.SubjectField = value;
                    this.RaisePropertyChanged("Subject");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string OrgCode {
            get {
                return this.OrgCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.OrgCodeField, value) != true)) {
                    this.OrgCodeField = value;
                    this.RaisePropertyChanged("OrgCode");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WSTemplateResponse", Namespace="http://SBTAPIService/DataContract/")]
    [System.SerializableAttribute()]
    public partial class WSTemplateResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IAC2021SQL.TemplateWSProxy.TemplateDetail ResponseField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public bool Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public int ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((this.ErrorCodeField.Equals(value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public IAC2021SQL.TemplateWSProxy.TemplateDetail Response {
            get {
                return this.ResponseField;
            }
            set {
                if ((object.ReferenceEquals(this.ResponseField, value) != true)) {
                    this.ResponseField = value;
                    this.RaisePropertyChanged("Response");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="WSTemplateListResponse", Namespace="http://SBTAPIService/DataContract/")]
    [System.SerializableAttribute()]
    public partial class WSTemplateListResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ErrorCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private IAC2021SQL.TemplateWSProxy.TemplateDetail[] ResponseField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public bool Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public int ErrorCode {
            get {
                return this.ErrorCodeField;
            }
            set {
                if ((this.ErrorCodeField.Equals(value) != true)) {
                    this.ErrorCodeField = value;
                    this.RaisePropertyChanged("ErrorCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public IAC2021SQL.TemplateWSProxy.TemplateDetail[] Response {
            get {
                return this.ResponseField;
            }
            set {
                if ((object.ReferenceEquals(this.ResponseField, value) != true)) {
                    this.ResponseField = value;
                    this.RaisePropertyChanged("Response");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://SBTService/ServiceContracts/", ConfigurationName="TemplateWSProxy.ITemplate")]
    public interface ITemplate {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/CreateTemplate", ReplyAction="http://SBTService/ServiceContracts/ITemplate/CreateTemplateResponse")]
        IAC2021SQL.TemplateWSProxy.WSTemplateResponse CreateTemplate(string securityToken, IAC2021SQL.TemplateWSProxy.TemplateDetail template);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/CreateTemplate", ReplyAction="http://SBTService/ServiceContracts/ITemplate/CreateTemplateResponse")]
        System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateResponse> CreateTemplateAsync(string securityToken, IAC2021SQL.TemplateWSProxy.TemplateDetail template);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/UpdateTemplate", ReplyAction="http://SBTService/ServiceContracts/ITemplate/UpdateTemplateResponse")]
        IAC2021SQL.TemplateWSProxy.WSTemplateResponse UpdateTemplate(string securityToken, IAC2021SQL.TemplateWSProxy.TemplateDetail template);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/UpdateTemplate", ReplyAction="http://SBTService/ServiceContracts/ITemplate/UpdateTemplateResponse")]
        System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateResponse> UpdateTemplateAsync(string securityToken, IAC2021SQL.TemplateWSProxy.TemplateDetail template);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/GetTemplates", ReplyAction="http://SBTService/ServiceContracts/ITemplate/GetTemplatesResponse")]
        IAC2021SQL.TemplateWSProxy.WSTemplateListResponse GetTemplates(string securityToken, string orgCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/GetTemplates", ReplyAction="http://SBTService/ServiceContracts/ITemplate/GetTemplatesResponse")]
        System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateListResponse> GetTemplatesAsync(string securityToken, string orgCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/ReadTemplate", ReplyAction="http://SBTService/ServiceContracts/ITemplate/ReadTemplateResponse")]
        IAC2021SQL.TemplateWSProxy.WSTemplateResponse ReadTemplate(string securityToken, string orgCode, int templateID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/ReadTemplate", ReplyAction="http://SBTService/ServiceContracts/ITemplate/ReadTemplateResponse")]
        System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateResponse> ReadTemplateAsync(string securityToken, string orgCode, int templateID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/DeleteTemplate", ReplyAction="http://SBTService/ServiceContracts/ITemplate/DeleteTemplateResponse")]
        IAC2021SQL.TemplateWSProxy.WSTemplateResponse DeleteTemplate(string securityToken, string orgCode, int templateID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://SBTService/ServiceContracts/ITemplate/DeleteTemplate", ReplyAction="http://SBTService/ServiceContracts/ITemplate/DeleteTemplateResponse")]
        System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateResponse> DeleteTemplateAsync(string securityToken, string orgCode, int templateID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITemplateChannel : IAC2021SQL.TemplateWSProxy.ITemplate, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TemplateClient : System.ServiceModel.ClientBase<IAC2021SQL.TemplateWSProxy.ITemplate>, IAC2021SQL.TemplateWSProxy.ITemplate {
        
        public TemplateClient() {
        }
        
        public TemplateClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TemplateClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TemplateClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TemplateClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public IAC2021SQL.TemplateWSProxy.WSTemplateResponse CreateTemplate(string securityToken, IAC2021SQL.TemplateWSProxy.TemplateDetail template) {
            return base.Channel.CreateTemplate(securityToken, template);
        }
        
        public System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateResponse> CreateTemplateAsync(string securityToken, IAC2021SQL.TemplateWSProxy.TemplateDetail template) {
            return base.Channel.CreateTemplateAsync(securityToken, template);
        }
        
        public IAC2021SQL.TemplateWSProxy.WSTemplateResponse UpdateTemplate(string securityToken, IAC2021SQL.TemplateWSProxy.TemplateDetail template) {
            return base.Channel.UpdateTemplate(securityToken, template);
        }
        
        public System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateResponse> UpdateTemplateAsync(string securityToken, IAC2021SQL.TemplateWSProxy.TemplateDetail template) {
            return base.Channel.UpdateTemplateAsync(securityToken, template);
        }
        
        public IAC2021SQL.TemplateWSProxy.WSTemplateListResponse GetTemplates(string securityToken, string orgCode) {
            return base.Channel.GetTemplates(securityToken, orgCode);
        }
        
        public System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateListResponse> GetTemplatesAsync(string securityToken, string orgCode) {
            return base.Channel.GetTemplatesAsync(securityToken, orgCode);
        }
        
        public IAC2021SQL.TemplateWSProxy.WSTemplateResponse ReadTemplate(string securityToken, string orgCode, int templateID) {
            return base.Channel.ReadTemplate(securityToken, orgCode, templateID);
        }
        
        public System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateResponse> ReadTemplateAsync(string securityToken, string orgCode, int templateID) {
            return base.Channel.ReadTemplateAsync(securityToken, orgCode, templateID);
        }
        
        public IAC2021SQL.TemplateWSProxy.WSTemplateResponse DeleteTemplate(string securityToken, string orgCode, int templateID) {
            return base.Channel.DeleteTemplate(securityToken, orgCode, templateID);
        }
        
        public System.Threading.Tasks.Task<IAC2021SQL.TemplateWSProxy.WSTemplateResponse> DeleteTemplateAsync(string securityToken, string orgCode, int templateID) {
            return base.Channel.DeleteTemplateAsync(securityToken, orgCode, templateID);
        }
    }
}
