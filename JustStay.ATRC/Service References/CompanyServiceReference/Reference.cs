﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JustStay.ATRC.CompanyServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompanyDto", Namespace="http://schemas.datacontract.org/2004/07/JustStay.Services.DTO")]
    [System.SerializableAttribute()]
    public partial class CompanyDto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CINField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CompanyIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CompanyNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContactField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GSTINField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> InsertedOnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LandLineField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MobileField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PANField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> PinCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SubheadingField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> UpdatedOnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string WebsiteField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CIN {
            get {
                return this.CINField;
            }
            set {
                if ((object.ReferenceEquals(this.CINField, value) != true)) {
                    this.CINField = value;
                    this.RaisePropertyChanged("CIN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CompanyId {
            get {
                return this.CompanyIdField;
            }
            set {
                if ((this.CompanyIdField.Equals(value) != true)) {
                    this.CompanyIdField = value;
                    this.RaisePropertyChanged("CompanyId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CompanyName {
            get {
                return this.CompanyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.CompanyNameField, value) != true)) {
                    this.CompanyNameField = value;
                    this.RaisePropertyChanged("CompanyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contact {
            get {
                return this.ContactField;
            }
            set {
                if ((object.ReferenceEquals(this.ContactField, value) != true)) {
                    this.ContactField = value;
                    this.RaisePropertyChanged("Contact");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GSTIN {
            get {
                return this.GSTINField;
            }
            set {
                if ((object.ReferenceEquals(this.GSTINField, value) != true)) {
                    this.GSTINField = value;
                    this.RaisePropertyChanged("GSTIN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> InsertedOn {
            get {
                return this.InsertedOnField;
            }
            set {
                if ((this.InsertedOnField.Equals(value) != true)) {
                    this.InsertedOnField = value;
                    this.RaisePropertyChanged("InsertedOn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LandLine {
            get {
                return this.LandLineField;
            }
            set {
                if ((object.ReferenceEquals(this.LandLineField, value) != true)) {
                    this.LandLineField = value;
                    this.RaisePropertyChanged("LandLine");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mobile {
            get {
                return this.MobileField;
            }
            set {
                if ((object.ReferenceEquals(this.MobileField, value) != true)) {
                    this.MobileField = value;
                    this.RaisePropertyChanged("Mobile");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PAN {
            get {
                return this.PANField;
            }
            set {
                if ((object.ReferenceEquals(this.PANField, value) != true)) {
                    this.PANField = value;
                    this.RaisePropertyChanged("PAN");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<int> PinCode {
            get {
                return this.PinCodeField;
            }
            set {
                if ((this.PinCodeField.Equals(value) != true)) {
                    this.PinCodeField = value;
                    this.RaisePropertyChanged("PinCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Subheading {
            get {
                return this.SubheadingField;
            }
            set {
                if ((object.ReferenceEquals(this.SubheadingField, value) != true)) {
                    this.SubheadingField = value;
                    this.RaisePropertyChanged("Subheading");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> UpdatedOn {
            get {
                return this.UpdatedOnField;
            }
            set {
                if ((this.UpdatedOnField.Equals(value) != true)) {
                    this.UpdatedOnField = value;
                    this.RaisePropertyChanged("UpdatedOn");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Website {
            get {
                return this.WebsiteField;
            }
            set {
                if ((object.ReferenceEquals(this.WebsiteField, value) != true)) {
                    this.WebsiteField = value;
                    this.RaisePropertyChanged("Website");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CompanyServiceReference.ICompanyService")]
    public interface ICompanyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/GetCompany", ReplyAction="http://tempuri.org/ICompanyService/GetCompanyResponse")]
        JustStay.ATRC.CompanyServiceReference.CompanyDto GetCompany();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/GetCompany", ReplyAction="http://tempuri.org/ICompanyService/GetCompanyResponse")]
        System.Threading.Tasks.Task<JustStay.ATRC.CompanyServiceReference.CompanyDto> GetCompanyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/UpdateCompany", ReplyAction="http://tempuri.org/ICompanyService/UpdateCompanyResponse")]
        int UpdateCompany(JustStay.ATRC.CompanyServiceReference.CompanyDto Compdto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICompanyService/UpdateCompany", ReplyAction="http://tempuri.org/ICompanyService/UpdateCompanyResponse")]
        System.Threading.Tasks.Task<int> UpdateCompanyAsync(JustStay.ATRC.CompanyServiceReference.CompanyDto Compdto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICompanyServiceChannel : JustStay.ATRC.CompanyServiceReference.ICompanyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CompanyServiceClient : System.ServiceModel.ClientBase<JustStay.ATRC.CompanyServiceReference.ICompanyService>, JustStay.ATRC.CompanyServiceReference.ICompanyService {
        
        public CompanyServiceClient() {
        }
        
        public CompanyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CompanyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompanyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CompanyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public JustStay.ATRC.CompanyServiceReference.CompanyDto GetCompany() {
            return base.Channel.GetCompany();
        }
        
        public System.Threading.Tasks.Task<JustStay.ATRC.CompanyServiceReference.CompanyDto> GetCompanyAsync() {
            return base.Channel.GetCompanyAsync();
        }
        
        public int UpdateCompany(JustStay.ATRC.CompanyServiceReference.CompanyDto Compdto) {
            return base.Channel.UpdateCompany(Compdto);
        }
        
        public System.Threading.Tasks.Task<int> UpdateCompanyAsync(JustStay.ATRC.CompanyServiceReference.CompanyDto Compdto) {
            return base.Channel.UpdateCompanyAsync(Compdto);
        }
    }
}
