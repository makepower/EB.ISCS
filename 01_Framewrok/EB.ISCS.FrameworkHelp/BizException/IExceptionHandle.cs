using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.FrameworkHelp.BizException
{
    public interface IExceptionHandle
    {
       // void HandleException(System.Exception exception, ExceptionLogEntry exceptionLogEntry);
    }
    public class HandleFactory
    {
        public static IExceptionHandle GetExceptionHandle(string handleName)
        {
            Sea2ExceptionHandle exceptionHandle = new Sea2ExceptionHandle();
            string[] str = exceptionHandle.type.Split(',');
            IExceptionHandle handle = Assembly.Load(str[1]).CreateInstance(str[0]) as IExceptionHandle;
            return handle;
        }
    }
}
