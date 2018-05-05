using System;
using System.Net;
using System.Runtime.Serialization;

namespace EB.ISCS.FrameworkHelp.BizException
{
    [Serializable]
    public class BizException : ApplicationException
    {
        private HttpStatusCode code;
        private string subCode;
        public string ExceptionName { get; set; }
        public string ExceptionDescription { get; set; }
        private bool m_needLog = false;
        public bool NeedLog
        {
            get
            {
                return m_needLog;
            }
            set
            {
                m_needLog = value;
            }
        }
        public string handle { get; set; }
        public ExceptionLevel Level
        {
            get;
            set;
        }
        /// <summary>
        /// Get the error code.
        /// </summary>
        public HttpStatusCode Code { get { return code; } }
        /// <summary>
        /// Get or set the error subcode.
        /// </summary>
        public string SubCode
        {
            get { return subCode; }
            set { subCode = value; }
        }
        public string Function { get; set; }

        private string m_ErrorCode;

        public string ErrorCode
        {
            get { return m_ErrorCode; }
            set { m_ErrorCode = value; }
        }

        private string m_ErrorDescription;

        public string ErrorDescription
        {
            get { return m_ErrorDescription; }
            set { m_ErrorDescription = value; }
        }
        public BizException()
            : base()
        {
            this.Level = ExceptionLevel.SystemError;
        }

        public BizException(BizExceptionType bizExceptionType, params object[] objects) : base(bizExceptionType.ToString())
        {
            ExceptionEntity exceptionEntity = new ExceptionEntity();
            ExceptionName = exceptionEntity.name;
            ExceptionDescription = string.Format(exceptionEntity.Description, objects);

            NeedLog = exceptionEntity.NeedLog;
            handle = exceptionEntity.handle;
            Function = exceptionEntity.Function;
            try
            {
                Level = (ExceptionLevel)Enum.Parse(typeof(ExceptionLevel), exceptionEntity.ExceptionLevel);
            }
            catch (System.Exception)
            {

                this.Level = ExceptionLevel.SystemError;
            }

        }
        public BizException(string exceptionName, string description, bool needLog, string handleName, string functionName, ExceptionLevel exceptionType)
            : base(description)
        {
            ExceptionName = exceptionName;
            ExceptionDescription = description;
            NeedLog = needLog;
            this.handle = handleName;
            this.Function = functionName;
        }

        //public void ExceptionHandle(SysExceptionLog exceptionLogEntry)
        //{
        //    IExceptionHandle handle = HandleFactory.GetExceptionHandle(this.handle);
        //    handle.HandleException(this, exceptionLogEntry);
        //}

        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("code", this.code, typeof(HttpStatusCode));
            info.AddValue("subCode", this.subCode, typeof(string));
            info.AddValue("NeedLog", NeedLog);
            info.AddValue("ErrorCode", ErrorCode);
            info.AddValue("ErrorDescription", ErrorDescription);
            base.GetObjectData(info, context);
        }

        public BizException(string message)
            : this("0", message, false)
        {

        }

        public BizException(string errorCode, string message)
            : this(errorCode, message, false)
        {
        }

        public BizException(string errorCode, string message, bool needLog)
            : base(message)
        {
            m_ErrorCode = errorCode;
            m_ErrorDescription = message;
            m_needLog = needLog;
        }

        public BizException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.NeedLog = info.GetBoolean("NeedLog");
            this.ErrorCode = info.GetString("ErrorCode");
            this.ErrorDescription = info.GetString("ErrorDescription");

        }

        public BizException(string message, Exception innerException)
            : this("0", message, innerException, false)
        {
        }

        public BizException(string errorCode, string message, Exception innerException)
            : this(errorCode, message, innerException, false)
        {
        }

        public BizException(string message, Exception innerException, bool needLog)
            : this("0", message, innerException, needLog)
        {
        }

        public BizException(string errorCode, string message, Exception innerException, bool needLog)
            : base(message, innerException)
        {
            m_ErrorCode = message;
            m_ErrorDescription = message;
            m_needLog = needLog;
        }


        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        /// <param name="messageFormat">The exception message format.</param>
        /// <param name="args">The exception message arguments.</param>
        public BizException(string messageFormat, params object[] args)
            : base(string.Format(messageFormat, args))
        {
        }


    }
    public enum BizExceptionType
    {
        /// <summary>
        /// if User not found , throw this exception
        /// </summary>
        Usernotfound
    }
    public enum ExceptionLevel
    {
        SystemError,
        BizError,
        Message
    }
}
