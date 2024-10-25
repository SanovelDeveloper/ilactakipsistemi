﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Kaynak kodu Microsoft.VSDesigner tarafından otomatik üretilmiş , Sürüm 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace DeclarationServices.SalesService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="DispatchNotificationPortBinding", Namespace="http://its.iegm.gov.tr/p2/notification/dispatch")]
    public partial class DispatchNotification : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback sendDispatchNotificationOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public DispatchNotification() {
            this.Url = global::DeclarationServices.Properties.Settings.Default.DeclarationServices_SalesService_UreticiSatisReceiverService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event sendDispatchNotificationCompletedEventHandler sendDispatchNotificationCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://its.iegm.gov.tr/p2/notification/dispatch/ItsRequest", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Bare)]
        [return: System.Xml.Serialization.XmlElementAttribute("DispatchResponse", Namespace="http://its.iegm.gov.tr/p2/notification/dispatch", IsNullable=true)]
        public ItsResponse sendDispatchNotification([System.Xml.Serialization.XmlElementAttribute(Namespace="http://its.iegm.gov.tr/p2/notification/dispatch", IsNullable=true)] ItsRequest DispatchRequest) {
            object[] results = this.Invoke("sendDispatchNotification", new object[] {
                        DispatchRequest});
            return ((ItsResponse)(results[0]));
        }
        
        /// <remarks/>
        public void sendDispatchNotificationAsync(ItsRequest DispatchRequest) {
            this.sendDispatchNotificationAsync(DispatchRequest, null);
        }
        
        /// <remarks/>
        public void sendDispatchNotificationAsync(ItsRequest DispatchRequest, object userState) {
            if ((this.sendDispatchNotificationOperationCompleted == null)) {
                this.sendDispatchNotificationOperationCompleted = new System.Threading.SendOrPostCallback(this.OnsendDispatchNotificationOperationCompleted);
            }
            this.InvokeAsync("sendDispatchNotification", new object[] {
                        DispatchRequest}, this.sendDispatchNotificationOperationCompleted, userState);
        }
        
        private void OnsendDispatchNotificationOperationCompleted(object arg) {
            if ((this.sendDispatchNotificationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.sendDispatchNotificationCompleted(this, new sendDispatchNotificationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://its.iegm.gov.tr/p2/notification/dispatch")]
    public partial class ItsRequest {
        
        private string tOGLNField;
        
        private ItsRequestPRODUCT[] pRODUCTSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TOGLN {
            get {
                return this.tOGLNField;
            }
            set {
                this.tOGLNField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PRODUCT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ItsRequestPRODUCT[] PRODUCTS {
            get {
                return this.pRODUCTSField;
            }
            set {
                this.pRODUCTSField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://its.iegm.gov.tr/p2/notification/dispatch")]
    public partial class ItsRequestPRODUCT {
        
        private string gTINField;

        private string snField;

        private string bnField;
        
        private string xdField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string gtin {
            get {
                return this.gTINField;
            }
            set {
                this.gTINField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string sn
        {
            get
            {
                return this.snField;
            }
            set
            {
                this.snField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string bn {
            get {
                return this.bnField;
            }
            set {
                this.bnField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="date")]
        public string xd {
            get {
                return this.xdField;
            }
            set {
                this.xdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://its.iegm.gov.tr/p2/notification/dispatch")]
    public partial class ItsResponse {
        
        private string nOTIFICATIONIDField;
        
        private ItsResponsePRODUCT[] pRODUCTSField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NOTIFICATIONID {
            get {
                return this.nOTIFICATIONIDField;
            }
            set {
                this.nOTIFICATIONIDField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("PRODUCT", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public ItsResponsePRODUCT[] PRODUCTS {
            get {
                return this.pRODUCTSField;
            }
            set {
                this.pRODUCTSField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://its.iegm.gov.tr/p2/notification/dispatch")]
    public partial class ItsResponsePRODUCT {
        
        private string gTINField;
        
        private string snField;
        
        private string ucField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string GTIN {
            get {
                return this.gTINField;
            }
            set {
                this.gTINField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SN {
            get {
                return this.snField;
            }
            set {
                this.snField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string UC {
            get {
                return this.ucField;
            }
            set {
                this.ucField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void sendDispatchNotificationCompletedEventHandler(object sender, sendDispatchNotificationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class sendDispatchNotificationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal sendDispatchNotificationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ItsResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ItsResponse)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591