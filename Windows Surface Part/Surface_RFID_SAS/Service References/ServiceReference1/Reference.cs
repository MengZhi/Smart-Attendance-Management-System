﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 12.0.21005.1
// 
namespace Surface_RFID_SAS.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetString", ReplyAction="http://tempuri.org/IService1/GetStringResponse")]
        System.Threading.Tasks.Task<string> GetStringAsync(string value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CheckLogin", ReplyAction="http://tempuri.org/IService1/CheckLoginResponse")]
        System.Threading.Tasks.Task<int> CheckLoginAsync(string username, string password, string usertype);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ForgetPassword", ReplyAction="http://tempuri.org/IService1/ForgetPasswordResponse")]
        System.Threading.Tasks.Task<int> ForgetPasswordAsync(string username, string usernumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/ChangePassword", ReplyAction="http://tempuri.org/IService1/ChangePasswordResponse")]
        System.Threading.Tasks.Task<int> ChangePasswordAsync(string oldpassword, string newpassword, string renewpassword, string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetBasicInformation", ReplyAction="http://tempuri.org/IService1/GetBasicInformationResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetBasicInformationAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetBasicInfoLec", ReplyAction="http://tempuri.org/IService1/GetBasicInfoLecResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetBasicInfoLecAsync(string LecEmail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetBasicInfoStu", ReplyAction="http://tempuri.org/IService1/GetBasicInfoStuResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetBasicInfoStuAsync(string StuEmail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStudentCourseList", ReplyAction="http://tempuri.org/IService1/GetStudentCourseListResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetStudentCourseListAsync(string StuEmail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStudentClassList", ReplyAction="http://tempuri.org/IService1/GetStudentClassListResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetStudentClassListAsync(string StuEmail, string Semester, string TeachingYear, string CourseCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetStudentMovement", ReplyAction="http://tempuri.org/IService1/GetStudentMovementResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetStudentMovementAsync(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSummary", ReplyAction="http://tempuri.org/IService1/GetSummaryResponse")]
        System.Threading.Tasks.Task<string> GetSummaryAsync(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLecCourseList", ReplyAction="http://tempuri.org/IService1/GetLecCourseListResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetLecCourseListAsync(string LecEmail);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLecturerClassList", ReplyAction="http://tempuri.org/IService1/GetLecturerClassListResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetLecturerClassListAsync(string Semester, string TeachingYear, string CourseCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetLecStudentAttendance", ReplyAction="http://tempuri.org/IService1/GetLecStudentAttendanceResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetLecStudentAttendanceAsync(string teachingYear, string semester, string courseCode, string classDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetClassStatisticInfo", ReplyAction="http://tempuri.org/IService1/GetClassStatisticInfoResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetClassStatisticInfoAsync(string Semester, string TeachingYear, string CourseCode, string ClassDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/LecGetStudentMovement", ReplyAction="http://tempuri.org/IService1/LecGetStudentMovementResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> LecGetStudentMovementAsync(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSummary2", ReplyAction="http://tempuri.org/IService1/GetSummary2Response")]
        System.Threading.Tasks.Task<string> GetSummary2Async(string MatricNumber, string Semester, string TeachingYear, string CourseCode, string ClassDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GreetingMessage", ReplyAction="http://tempuri.org/IService1/GreetingMessageResponse")]
        System.Threading.Tasks.Task<string> GreetingMessageAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Surface_RFID_SAS.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Surface_RFID_SAS.ServiceReference1.IService1>, Surface_RFID_SAS.ServiceReference1.IService1 {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public Service1Client() : 
                base(Service1Client.GetDefaultBinding(), Service1Client.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IService1.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), Service1Client.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(Service1Client.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public System.Threading.Tasks.Task<string> GetStringAsync(string value) {
            return base.Channel.GetStringAsync(value);
        }
        
        public System.Threading.Tasks.Task<int> CheckLoginAsync(string username, string password, string usertype) {
            return base.Channel.CheckLoginAsync(username, password, usertype);
        }
        
        public System.Threading.Tasks.Task<int> ForgetPasswordAsync(string username, string usernumber) {
            return base.Channel.ForgetPasswordAsync(username, usernumber);
        }
        
        public System.Threading.Tasks.Task<int> ChangePasswordAsync(string oldpassword, string newpassword, string renewpassword, string username) {
            return base.Channel.ChangePasswordAsync(oldpassword, newpassword, renewpassword, username);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetBasicInformationAsync() {
            return base.Channel.GetBasicInformationAsync();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetBasicInfoLecAsync(string LecEmail) {
            return base.Channel.GetBasicInfoLecAsync(LecEmail);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetBasicInfoStuAsync(string StuEmail) {
            return base.Channel.GetBasicInfoStuAsync(StuEmail);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetStudentCourseListAsync(string StuEmail) {
            return base.Channel.GetStudentCourseListAsync(StuEmail);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetStudentClassListAsync(string StuEmail, string Semester, string TeachingYear, string CourseCode) {
            return base.Channel.GetStudentClassListAsync(StuEmail, Semester, TeachingYear, CourseCode);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetStudentMovementAsync(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate) {
            return base.Channel.GetStudentMovementAsync(StuEmail, Semester, TeachingYear, CourseCode, ClassDate);
        }
        
        public System.Threading.Tasks.Task<string> GetSummaryAsync(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate) {
            return base.Channel.GetSummaryAsync(StuEmail, Semester, TeachingYear, CourseCode, ClassDate);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetLecCourseListAsync(string LecEmail) {
            return base.Channel.GetLecCourseListAsync(LecEmail);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetLecturerClassListAsync(string Semester, string TeachingYear, string CourseCode) {
            return base.Channel.GetLecturerClassListAsync(Semester, TeachingYear, CourseCode);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> GetLecStudentAttendanceAsync(string teachingYear, string semester, string courseCode, string classDate) {
            return base.Channel.GetLecStudentAttendanceAsync(teachingYear, semester, courseCode, classDate);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<string>> GetClassStatisticInfoAsync(string Semester, string TeachingYear, string CourseCode, string ClassDate) {
            return base.Channel.GetClassStatisticInfoAsync(Semester, TeachingYear, CourseCode, ClassDate);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<System.Collections.ObjectModel.ObservableCollection<string>>> LecGetStudentMovementAsync(string StuEmail, string Semester, string TeachingYear, string CourseCode, string ClassDate) {
            return base.Channel.LecGetStudentMovementAsync(StuEmail, Semester, TeachingYear, CourseCode, ClassDate);
        }
        
        public System.Threading.Tasks.Task<string> GetSummary2Async(string MatricNumber, string Semester, string TeachingYear, string CourseCode, string ClassDate) {
            return base.Channel.GetSummary2Async(MatricNumber, Semester, TeachingYear, CourseCode, ClassDate);
        }
        
        public System.Threading.Tasks.Task<string> GreetingMessageAsync(string name) {
            return base.Channel.GreetingMessageAsync(name);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IService1)) {
                return new System.ServiceModel.EndpointAddress("http://192.168.1.100:60397/Service1.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return Service1Client.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IService1);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return Service1Client.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IService1);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IService1,
        }
    }
}