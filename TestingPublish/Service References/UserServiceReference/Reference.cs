﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestingPublish.UserServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="IPDMTBase", Namespace="http://schemas.datacontract.org/2004/07/VL.Common.ORM.Objects")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestingPublish.UserServiceReference.TUser))]
    public partial class IPDMTBase : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TUser", Namespace="http://schemas.datacontract.org/2004/07/VL.User.Objects.Entities")]
    [System.SerializableAttribute()]
    public partial class TUser : TestingPublish.UserServiceReference.IPDMTBase {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime CreateTimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdCardNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private short MobileField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid UserIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreateTime {
            get {
                return this.CreateTimeField;
            }
            set {
                if ((this.CreateTimeField.Equals(value) != true)) {
                    this.CreateTimeField = value;
                    this.RaisePropertyChanged("CreateTime");
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
        public string IdCardNumber {
            get {
                return this.IdCardNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.IdCardNumberField, value) != true)) {
                    this.IdCardNumberField = value;
                    this.RaisePropertyChanged("IdCardNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public short Mobile {
            get {
                return this.MobileField;
            }
            set {
                if ((this.MobileField.Equals(value) != true)) {
                    this.MobileField = value;
                    this.RaisePropertyChanged("Mobile");
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
        public System.Guid UserId {
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
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/VL.Common.Protocol.IResult")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(TestingPublish.UserServiceReference.ResultOfCreateUserResult9I7TJpd5))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestingPublish.UserServiceReference.EResultCode ResultCodeField;
        
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
        public string Content {
            get {
                return this.ContentField;
            }
            set {
                if ((object.ReferenceEquals(this.ContentField, value) != true)) {
                    this.ContentField = value;
                    this.RaisePropertyChanged("Content");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestingPublish.UserServiceReference.EResultCode ResultCode {
            get {
                return this.ResultCodeField;
            }
            set {
                if ((this.ResultCodeField.Equals(value) != true)) {
                    this.ResultCodeField = value;
                    this.RaisePropertyChanged("ResultCode");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ResultOfCreateUserResult9I7TJpd5", Namespace="http://schemas.datacontract.org/2004/07/VL.Common.Protocol.IResult")]
    [System.SerializableAttribute()]
    public partial class ResultOfCreateUserResult9I7TJpd5 : TestingPublish.UserServiceReference.Result {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private TestingPublish.UserServiceReference.CreateUserResult SubResultCodeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public TestingPublish.UserServiceReference.CreateUserResult SubResultCode {
            get {
                return this.SubResultCodeField;
            }
            set {
                if ((this.SubResultCodeField.Equals(value) != true)) {
                    this.SubResultCodeField = value;
                    this.RaisePropertyChanged("SubResultCode");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EResultCode", Namespace="http://schemas.datacontract.org/2004/07/VL.Common.Protocol.IResult")]
    public enum EResultCode : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Success = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Failure = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Error = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateUserResult", Namespace="http://schemas.datacontract.org/2004/07/VL.User.Objects.SubResults")]
    public enum CreateUserResult : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        None = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        UserNameExist = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        MobileExist = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        EmailExist = 3,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        InserFailed = 4,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Register", ReplyAction="http://tempuri.org/IUserService/RegisterResponse")]
        TestingPublish.UserServiceReference.ResultOfCreateUserResult9I7TJpd5 Register(TestingPublish.UserServiceReference.TUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Register", ReplyAction="http://tempuri.org/IUserService/RegisterResponse")]
        System.Threading.Tasks.Task<TestingPublish.UserServiceReference.ResultOfCreateUserResult9I7TJpd5> RegisterAsync(TestingPublish.UserServiceReference.TUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/SimulateRegister", ReplyAction="http://tempuri.org/IUserService/SimulateRegisterResponse")]
        TestingPublish.UserServiceReference.Result SimulateRegister(TestingPublish.UserServiceReference.TUser user, System.DateTime simulateTime);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/SimulateRegister", ReplyAction="http://tempuri.org/IUserService/SimulateRegisterResponse")]
        System.Threading.Tasks.Task<TestingPublish.UserServiceReference.Result> SimulateRegisterAsync(TestingPublish.UserServiceReference.TUser user, System.DateTime simulateTime);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : TestingPublish.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<TestingPublish.UserServiceReference.IUserService>, TestingPublish.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public TestingPublish.UserServiceReference.ResultOfCreateUserResult9I7TJpd5 Register(TestingPublish.UserServiceReference.TUser user) {
            return base.Channel.Register(user);
        }
        
        public System.Threading.Tasks.Task<TestingPublish.UserServiceReference.ResultOfCreateUserResult9I7TJpd5> RegisterAsync(TestingPublish.UserServiceReference.TUser user) {
            return base.Channel.RegisterAsync(user);
        }
        
        public TestingPublish.UserServiceReference.Result SimulateRegister(TestingPublish.UserServiceReference.TUser user, System.DateTime simulateTime) {
            return base.Channel.SimulateRegister(user, simulateTime);
        }
        
        public System.Threading.Tasks.Task<TestingPublish.UserServiceReference.Result> SimulateRegisterAsync(TestingPublish.UserServiceReference.TUser user, System.DateTime simulateTime) {
            return base.Channel.SimulateRegisterAsync(user, simulateTime);
        }
    }
}
