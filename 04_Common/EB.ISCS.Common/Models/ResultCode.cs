using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EB.ISCS.FrameworkHelp;
using EB.ISCS.FrameworkHelp.Utilities;

namespace EB.ISCS.Common.Models
{
    /// <summary>
    /// api 响应状态吗
    /// </summary>
    public enum ResultCode
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        [Description("操作成功")]
        Success = 10000,
        /// <summary>
        /// 操作失败，请联系管理员
        /// </summary>
        [Description("操作失败，请联系管理员")]
        Faild = 10001,
        /// <summary>
        /// 身份凭据失效或无效
        /// </summary>
        [Description("身份凭据错误")]
        UserTokenError = 10002,
        /// <summary>
        /// 用户不存在
        /// </summary>
        [Description("用户已冻结")]
        UserIsFreeze = 10003,
        /// <summary>
        /// 用户已被删除
        /// </summary>
        [Description("用户已被删除")]
        UserDeleted = 10004,
        /// <summary>
        /// 用户不存在或密码错误
        /// </summary>
        [Description("用户不存在或密码错误")]
        UserWrongPassword = 10005,
        /// <summary>
        /// 用户名不能为空
        /// </summary>
        [Description("用户名不能为空")]
        UsernameIsNull = 10006,
        /// <summary>
        /// 密码不能为空
        /// </summary>
        [Description("密码不能为空")]
        PasswordIsNull = 10007,

        /// <summary>
        /// 无功能操作权限
        /// </summary>
        [Description("无功能操作权限")]
        MenuCodeIsNull = 10009,

        /// <summary>
        /// 登录凭证无效
        /// </summary>
        [Description("登录凭证无效")]
        InvalidLoginCredential = 10010,

        /// <summary>
        /// 验证码校验失败
        /// </summary>
        [Description("验证码校验失败")]
        InvalidVCode = 10011,

        /// <summary>
        /// 验证码已过期
        /// </summary>
        [Description("验证码已过期")]
        InvalidVCodeExpire = 10012,

        /// <summary>
        /// 暂未获取到数据
        /// </summary>
        [Description("暂未获取到数据")]
        MissingData = 10013,


        /// <summary>
        /// 参数传递有误，请检查调用参数
        /// </summary>
        [Description("参数传递有误，请检查调用参数")]
        InvalidParams = 12000,

    }


    /// <summary>
    /// api 响应实体
    /// </summary>
    public class ResponseResult
    {

        //public string Status { get; set; }
        /// <summary>
        /// 响应状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public dynamic Data { get; set; }

        /// <summary>
        /// 返回响应码状态描述
        /// </summary>
        /// <param name="code">返回响应码状态枚举</param>
        /// <returns></returns>
        public static ResponseResult GenFaildResponse(ResultCode code = ResultCode.Faild)
        {
            return new ResponseResult { Code = (int)code, Message = code.GetDescription() };
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseResult GenFaildResponse(dynamic data)
        {
            return new ResponseResult
            {
                Code = (int)ResultCode.Faild,
                Message = ResultCode.Faild.GetDescription(),
                Data = data
            };
        }
        /// <summary>
        /// 返回字符串类型
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResponseResult GenFaildResponse(string msg)
        {
            return new ResponseResult
            {
                Code = (int)ResultCode.Faild,
                Message = msg
            };
        }
        /// <summary>
        /// 返回动态默认NUll类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseResult GenSuccessResponse(dynamic data = null)
        {
            return new ResponseResult
            {
                Code = (int)ResultCode.Success,
                Message = ResultCode.Success.GetDescription(),
                Data = data
            };
        }
    }

    /// <summary>
    /// api泛型相应实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseResult<T>
    {

        //public string Status { get; set; }
        /// <summary>
        /// 响应状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 响应消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// 返回响应码状态描述
        /// </summary>
        /// <param name="code">返回响应码状态枚举</param>
        /// <returns></returns>
        public static ResponseResult<T> GenFaildResponse(ResultCode code = ResultCode.Faild)
        {
            return new ResponseResult<T> { Code = (int)code, Message = code.GetDescription() };
        }
        /// <summary>
        /// 返回数据
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseResult<T> GenFaildResponse(dynamic data)
        {
            return new ResponseResult<T>
            {
                Code = (int)ResultCode.Faild,
                Message = ResultCode.Faild.GetDescription(),
                Data = data
            };
        }
        /// <summary>
        /// 返回字符串类型
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ResponseResult<T> GenFaildResponse(string msg)
        {
            return new ResponseResult<T>
            {
                Code = (int)ResultCode.Faild,
                Message = msg
            };
        }
        /// <summary>
        /// 返回动态默认NUll类型
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ResponseResult<T> GenSuccessResponse(dynamic data = null)
        {
            return new ResponseResult<T>
            {
                Code = (int)ResultCode.Success,
                Message = ResultCode.Success.GetDescription(),
                Data = data
            };
        }

        /// <summary>
        /// 返回 Json 字符串
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static HttpResponseMessage JsonResponse(ResponseResult<T> response)
        {
            var str = JsonConvert.SerializeObject(response);
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }

        /// <summary>
        /// 返回 Json 字符串
        /// </summary>
        /// <param name="response">json字符串</param>
        /// <returns></returns>
        public static HttpResponseMessage JsonResponse(string response)
        {
            HttpResponseMessage result = new HttpResponseMessage { Content = new StringContent(response, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result;
        }
    }
}
