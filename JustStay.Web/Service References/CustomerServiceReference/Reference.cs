﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JustStay.Web.CustomerServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CustomerDetail", Namespace="http://schemas.datacontract.org/2004/07/JustStay.Repo")]
    [System.SerializableAttribute()]
    public partial class CustomerDetail : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CustomerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DOBField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> InsertedOnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IsActiveField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool IsGuestField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MobileField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> UpdatedOnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
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
        public int CustomerId {
            get {
                return this.CustomerIdField;
            }
            set {
                if ((this.CustomerIdField.Equals(value) != true)) {
                    this.CustomerIdField = value;
                    this.RaisePropertyChanged("CustomerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DOB {
            get {
                return this.DOBField;
            }
            set {
                if ((this.DOBField.Equals(value) != true)) {
                    this.DOBField = value;
                    this.RaisePropertyChanged("DOB");
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
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
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
        public string IsActive {
            get {
                return this.IsActiveField;
            }
            set {
                if ((object.ReferenceEquals(this.IsActiveField, value) != true)) {
                    this.IsActiveField = value;
                    this.RaisePropertyChanged("IsActive");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsGuest {
            get {
                return this.IsGuestField;
            }
            set {
                if ((this.IsGuestField.Equals(value) != true)) {
                    this.IsGuestField = value;
                    this.RaisePropertyChanged("IsGuest");
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
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
        public System.Nullable<int> UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="GetAllCustomersDetails", Namespace="http://schemas.datacontract.org/2004/07/JustStay.Repo")]
    [System.SerializableAttribute()]
    public partial class GetAllCustomersDetails : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<int> BookingCountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CustTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CustomerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<System.DateTime> DOBField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MobileField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UserIdField;
        
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
        public System.Nullable<int> BookingCount {
            get {
                return this.BookingCountField;
            }
            set {
                if ((this.BookingCountField.Equals(value) != true)) {
                    this.BookingCountField = value;
                    this.RaisePropertyChanged("BookingCount");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CustType {
            get {
                return this.CustTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.CustTypeField, value) != true)) {
                    this.CustTypeField = value;
                    this.RaisePropertyChanged("CustType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CustomerId {
            get {
                return this.CustomerIdField;
            }
            set {
                if ((this.CustomerIdField.Equals(value) != true)) {
                    this.CustomerIdField = value;
                    this.RaisePropertyChanged("CustomerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<System.DateTime> DOB {
            get {
                return this.DOBField;
            }
            set {
                if ((this.DOBField.Equals(value) != true)) {
                    this.DOBField = value;
                    this.RaisePropertyChanged("DOB");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((this.UserIdField.Equals(value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CustomerRequestDetail", Namespace="http://schemas.datacontract.org/2004/07/JustStay.Repo")]
    [System.SerializableAttribute()]
    public partial class CustomerRequestDetail : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CustomerIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CustomerRequestIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DetailsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime InsertedOnField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MobileField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
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
        public int CustomerId {
            get {
                return this.CustomerIdField;
            }
            set {
                if ((this.CustomerIdField.Equals(value) != true)) {
                    this.CustomerIdField = value;
                    this.RaisePropertyChanged("CustomerId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CustomerRequestId {
            get {
                return this.CustomerRequestIdField;
            }
            set {
                if ((this.CustomerRequestIdField.Equals(value) != true)) {
                    this.CustomerRequestIdField = value;
                    this.RaisePropertyChanged("CustomerRequestId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Details {
            get {
                return this.DetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.DetailsField, value) != true)) {
                    this.DetailsField = value;
                    this.RaisePropertyChanged("Details");
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
        public System.DateTime InsertedOn {
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
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CustomerServiceReference.ICustomerService")]
    public interface ICustomerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCustomerDetail", ReplyAction="http://tempuri.org/ICustomerService/GetCustomerDetailResponse")]
        JustStay.Web.CustomerServiceReference.CustomerDetail GetCustomerDetail(int custId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCustomerDetail", ReplyAction="http://tempuri.org/ICustomerService/GetCustomerDetailResponse")]
        System.Threading.Tasks.Task<JustStay.Web.CustomerServiceReference.CustomerDetail> GetCustomerDetailAsync(int custId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllCustomersDetails", ReplyAction="http://tempuri.org/ICustomerService/GetAllCustomersDetailsResponse")]
        JustStay.Web.CustomerServiceReference.GetAllCustomersDetails[] GetAllCustomersDetails(string serach);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllCustomersDetails", ReplyAction="http://tempuri.org/ICustomerService/GetAllCustomersDetailsResponse")]
        System.Threading.Tasks.Task<JustStay.Web.CustomerServiceReference.GetAllCustomersDetails[]> GetAllCustomersDetailsAsync(string serach);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCustomerIdByUserId", ReplyAction="http://tempuri.org/ICustomerService/GetCustomerIdByUserIdResponse")]
        int GetCustomerIdByUserId(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetCustomerIdByUserId", ReplyAction="http://tempuri.org/ICustomerService/GetCustomerIdByUserIdResponse")]
        System.Threading.Tasks.Task<int> GetCustomerIdByUserIdAsync(int userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/InsertCustomer", ReplyAction="http://tempuri.org/ICustomerService/InsertCustomerResponse")]
        int InsertCustomer(JustStay.Services.DTO.CustomerDto customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/InsertCustomer", ReplyAction="http://tempuri.org/ICustomerService/InsertCustomerResponse")]
        System.Threading.Tasks.Task<int> InsertCustomerAsync(JustStay.Services.DTO.CustomerDto customer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/UpdateCustomerProfile", ReplyAction="http://tempuri.org/ICustomerService/UpdateCustomerProfileResponse")]
        void UpdateCustomerProfile(JustStay.Web.CustomerServiceReference.CustomerDetail cust);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/UpdateCustomerProfile", ReplyAction="http://tempuri.org/ICustomerService/UpdateCustomerProfileResponse")]
        System.Threading.Tasks.Task UpdateCustomerProfileAsync(JustStay.Web.CustomerServiceReference.CustomerDetail cust);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/InsertCustomerRequest", ReplyAction="http://tempuri.org/ICustomerService/InsertCustomerRequestResponse")]
        void InsertCustomerRequest(JustStay.Services.DTO.CustomerRequestDTO reqDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/InsertCustomerRequest", ReplyAction="http://tempuri.org/ICustomerService/InsertCustomerRequestResponse")]
        System.Threading.Tasks.Task InsertCustomerRequestAsync(JustStay.Services.DTO.CustomerRequestDTO reqDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllCustomerRequets", ReplyAction="http://tempuri.org/ICustomerService/GetAllCustomerRequetsResponse")]
        JustStay.Web.CustomerServiceReference.CustomerRequestDetail[] GetAllCustomerRequets();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/GetAllCustomerRequets", ReplyAction="http://tempuri.org/ICustomerService/GetAllCustomerRequetsResponse")]
        System.Threading.Tasks.Task<JustStay.Web.CustomerServiceReference.CustomerRequestDetail[]> GetAllCustomerRequetsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/DeleteCustomer", ReplyAction="http://tempuri.org/ICustomerService/DeleteCustomerResponse")]
        int DeleteCustomer(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICustomerService/DeleteCustomer", ReplyAction="http://tempuri.org/ICustomerService/DeleteCustomerResponse")]
        System.Threading.Tasks.Task<int> DeleteCustomerAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICustomerServiceChannel : JustStay.Web.CustomerServiceReference.ICustomerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CustomerServiceClient : System.ServiceModel.ClientBase<JustStay.Web.CustomerServiceReference.ICustomerService>, JustStay.Web.CustomerServiceReference.ICustomerService {
        
        public CustomerServiceClient() {
        }
        
        public CustomerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CustomerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public JustStay.Web.CustomerServiceReference.CustomerDetail GetCustomerDetail(int custId) {
            return base.Channel.GetCustomerDetail(custId);
        }
        
        public System.Threading.Tasks.Task<JustStay.Web.CustomerServiceReference.CustomerDetail> GetCustomerDetailAsync(int custId) {
            return base.Channel.GetCustomerDetailAsync(custId);
        }
        
        public JustStay.Web.CustomerServiceReference.GetAllCustomersDetails[] GetAllCustomersDetails(string serach) {
            return base.Channel.GetAllCustomersDetails(serach);
        }
        
        public System.Threading.Tasks.Task<JustStay.Web.CustomerServiceReference.GetAllCustomersDetails[]> GetAllCustomersDetailsAsync(string serach) {
            return base.Channel.GetAllCustomersDetailsAsync(serach);
        }
        
        public int GetCustomerIdByUserId(int userId) {
            return base.Channel.GetCustomerIdByUserId(userId);
        }
        
        public System.Threading.Tasks.Task<int> GetCustomerIdByUserIdAsync(int userId) {
            return base.Channel.GetCustomerIdByUserIdAsync(userId);
        }
        
        public int InsertCustomer(JustStay.Services.DTO.CustomerDto customer) {
            return base.Channel.InsertCustomer(customer);
        }
        
        public System.Threading.Tasks.Task<int> InsertCustomerAsync(JustStay.Services.DTO.CustomerDto customer) {
            return base.Channel.InsertCustomerAsync(customer);
        }
        
        public void UpdateCustomerProfile(JustStay.Web.CustomerServiceReference.CustomerDetail cust) {
            base.Channel.UpdateCustomerProfile(cust);
        }
        
        public System.Threading.Tasks.Task UpdateCustomerProfileAsync(JustStay.Web.CustomerServiceReference.CustomerDetail cust) {
            return base.Channel.UpdateCustomerProfileAsync(cust);
        }
        
        public void InsertCustomerRequest(JustStay.Services.DTO.CustomerRequestDTO reqDto) {
            base.Channel.InsertCustomerRequest(reqDto);
        }
        
        public System.Threading.Tasks.Task InsertCustomerRequestAsync(JustStay.Services.DTO.CustomerRequestDTO reqDto) {
            return base.Channel.InsertCustomerRequestAsync(reqDto);
        }
        
        public JustStay.Web.CustomerServiceReference.CustomerRequestDetail[] GetAllCustomerRequets() {
            return base.Channel.GetAllCustomerRequets();
        }
        
        public System.Threading.Tasks.Task<JustStay.Web.CustomerServiceReference.CustomerRequestDetail[]> GetAllCustomerRequetsAsync() {
            return base.Channel.GetAllCustomerRequetsAsync();
        }
        
        public int DeleteCustomer(int id) {
            return base.Channel.DeleteCustomer(id);
        }
        
        public System.Threading.Tasks.Task<int> DeleteCustomerAsync(int id) {
            return base.Channel.DeleteCustomerAsync(id);
        }
    }
}
