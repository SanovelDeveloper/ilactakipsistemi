using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.AgeSoapClass
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false)]
    public partial class Envelope
    {

        private EnvelopeBody bodyField;

        /// <remarks/>
        public EnvelopeBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public partial class EnvelopeBody
    {

        private PostWorkOrderResponse postWorkOrderResponseField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://tempuri.org/")]
        public PostWorkOrderResponse PostWorkOrderResponse
        {
            get
            {
                return this.postWorkOrderResponseField;
            }
            set
            {
                this.postWorkOrderResponseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/", IsNullable = false)]
    public partial class PostWorkOrderResponse
    {

        private PostWorkOrderResponsePostWorkOrderResult postWorkOrderResultField;

        /// <remarks/>
        public PostWorkOrderResponsePostWorkOrderResult PostWorkOrderResult
        {
            get
            {
                return this.postWorkOrderResultField;
            }
            set
            {
                this.postWorkOrderResultField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/")]
    public partial class PostWorkOrderResponsePostWorkOrderResult
    {

        private string workOrderIDField;

        private string errorMessageField;

        private bool isSucceedField;

        /// <remarks/>
        public string WorkOrderID
        {
            get
            {
                return this.workOrderIDField;
            }
            set
            {
                this.workOrderIDField = value;
            }
        }
        /// <remarks/>
        public string ErrorMessage
        {
            get
            {
                return this.errorMessageField;
            }
            set
            {
                this.errorMessageField = value;
            }
        }
        /// <remarks/>
        public bool IsSucceed
        {
            get
            {
                return this.isSucceedField;
            }
            set
            {
                this.isSucceedField = value;
            }
        }
    }
}
