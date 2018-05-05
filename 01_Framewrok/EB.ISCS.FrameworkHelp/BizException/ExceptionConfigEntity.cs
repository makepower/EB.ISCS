using System.Xml.Serialization;

namespace EB.ISCS.FrameworkHelp.BizException
{

    [XmlRoot(ElementName = "ZhiDunException")]
    public partial class Sea2Exception
    {

        private Sea2ExceptionHandle[] handlesField;

        private BizExceptionCollection bizExceptionCollectionField;

        /// <remarks/>
        [XmlArrayItem("handle", IsNullable = false)]
        public Sea2ExceptionHandle[] Handles
        {
            get
            {
                return this.handlesField;
            }
            set
            {
                this.handlesField = value;
            }
        }

        /// <remarks/>
        [XmlElement(ElementName = "BizExceptionCollection")]
        public BizExceptionCollection BizExceptionCollection
        {
            get
            {
                return this.bizExceptionCollectionField;
            }
            set
            {
                this.bizExceptionCollectionField = value;
            }
        }
        [XmlElement(ElementName = "ExceptionSet")]
        public ExceptionEmailSet ExceptionEmail
        {
            get; set;
        }
    }
    public class  ExceptionEmailSet
    {
        [XmlElement(ElementName = "SendTo")]
        public string Sendto { get; set; }
        [XmlElement(ElementName = "Subject")]
        public string Subject { get; set; }
    }

    /// <remarks/> 
    public  class Sea2ExceptionHandle
    {

        private string nameField;

        private string typeField;

        private bool defaultField; 

        /// <remarks/>
        [XmlAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute(AttributeName = "default")]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool isDefault
        {
            get
            {
                return this.defaultField;
            }
            set
            {
                this.defaultField = value;
            }
        } 
    }

    /// <remarks/>
     
    public   class  BizExceptionCollection
    {

        private ExceptionEntity[] bizExceptionField;

        /// <remarks/>
        [XmlElement("BizException")]
        public ExceptionEntity[] BizException
        {
            get
            {
                return this.bizExceptionField;
            }
            set
            {
                this.bizExceptionField = value;
            }
        }
    }

 
    public  class   ExceptionEntity 
    {

        private string nameField;

        private string descriptionField;

        private bool needLogField;

        private string handleField;
        private string functinFieldl;
        [XmlAttribute(AttributeName = "ExceptionLevel")]
        public string ExceptionLevel 
        {
            get; set;
        }

        public ExceptionEntity()
        {
            this.needLogField = false;
            this.handleField = "SystemError";
        }

        /// <remarks/>
        [XmlAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool NeedLog
        {
            get
            {
                return this.needLogField;
            }
            set
            {
                this.needLogField = value;
            }
        }

        /// <remarks/>
        [XmlAttribute()]
        [System.ComponentModel.DefaultValueAttribute("SystemError")]
        public string handle
        {
            get
            {
                return this.handleField;
            }
            set
            {
                this.handleField = value;
            }
        }
        [XmlAttribute(AttributeName = "Function")]
        public string Function
        {
            get
            {
                return this.functinFieldl;
            }
            set
            {
                this.functinFieldl = value;
            }
        }
    }
}