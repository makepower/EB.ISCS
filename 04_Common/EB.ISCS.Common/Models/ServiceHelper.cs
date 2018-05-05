using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EB.ISCS.Common.Models
{
    public class ServiceHelper
    {
        public static BaseResult CallService(string url, dynamic parms, string token = null)
        {
            //Web/Content/GetHelpList
            BaseResult result = null;
            try
            {
                string serviceHost = ConfigurationManager.AppSettings["api_url"];
                string serviceAuth = ConfigurationManager.AppSettings["api_auth"];
                var signature = new ApiRequestSignature { AppId = serviceAuth };
                var parameters = new[]
                {
                  new NameValuePair(null, serviceAuth),
                  new NameValuePair(null, signature.TimestampString)
                };
                var timestamp = DateTime.UtcNow;
                serviceHost += url;
                var wc = new WebClient { Encoding = Encoding.UTF8 };
                wc.Headers.Add(HttpRequestHeader.Accept, "json");
                wc.Headers.Add("authorization:basic " + serviceAuth + ';' + token);
                byte[] data = new byte[0];
                if (parms is NameValueCollection)
                {
                    data = wc.UploadValues(serviceHost, "POST", parms);
                }
                else if (parms is string)
                {
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=UTF-8");
                    data = wc.UploadData(serviceHost, "POST", Encoding.UTF8.GetBytes(parms));

                }
                else
                {
                    string pramStr = JsonConvert.SerializeObject(parms);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=UTF-8");
                    data = wc.UploadData(serviceHost, "POST", Encoding.UTF8.GetBytes(pramStr));
                }
                string res = Encoding.UTF8.GetString(data);
                result = JsonConvert.DeserializeObject<BaseResult>(res);

                if (result.Code == 10000)
                {
                    // 成功
                    return result;
                }
            }
            catch (Exception ex)
            {
                BaseResult br = new BaseResult()
                {
                    Code = 100000,
                    Data = null,
                    Message = ex.Message
                };
                return br;
            }
            return result;
        }

        public static object CallService<T>(object getList, object p, string token)
        {
            throw new NotImplementedException();
        }

        public static object CallService<T>(string v, object p, object token)
        {
            throw new NotImplementedException();
        }

        public static BaseResult<T> CallService<T>(string url, dynamic parms, string token = null) where T : new()
        {
            BaseResult<T> result = new BaseResult<T>();
            try
            {
                string serviceHost = ConfigurationManager.AppSettings["api_url"];
                string serviceAuth = ConfigurationManager.AppSettings["api_auth"];
                string secretKey = ConfigurationManager.AppSettings["SecretKey"];
                serviceHost += url;
                WebClient wc = new WebClient();
                wc.Encoding = System.Text.Encoding.UTF8;
                wc.Headers.Add(HttpRequestHeader.Accept, "json");
                wc.Headers.Add("authorization:basic " + serviceAuth + ';' + token);
                byte[] data = new byte[0];
                if (parms is NameValueCollection)
                {
                    data = wc.UploadValues(serviceHost, "POST", parms);
                }
                else if (parms is string)
                {
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=UTF-8");
                    data = wc.UploadData(serviceHost, "POST", Encoding.UTF8.GetBytes(parms));
                }
                else
                {
                    string pramStr = JsonConvert.SerializeObject(parms);
                    wc.Headers.Add(HttpRequestHeader.ContentType, "application/json; charset=UTF-8");
                    data = wc.UploadData(serviceHost, "POST", Encoding.UTF8.GetBytes(pramStr));
                }
                string res = Encoding.UTF8.GetString(data);

                result = JsonConvert.DeserializeObject<BaseResult<T>>(res);
                // 格式化结果值
                FormatResult<T>(result);

                if (result.Code == 10000)
                {
                    // 成功
                    return result;
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return result;
            }
            return result;
        }


        private static void FormatResult<T>(BaseResult<T> result)
        {
            if (result == null) return;
            if (result.Message == null)
                result.Message = string.Empty;
            if (result.Data == null)
            {
                if (typeof(T).IsValueType)
                    result.Data = default(T);
                else
                    result.Data = Activator.CreateInstance<T>();
            }
        }

    }

    public class CustomDelegatingHandler : DelegatingHandler
    {

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            HttpResponseMessage response = null;

            string requestContentBase64String = string.Empty;

            string requestUri = System.Web.HttpUtility.UrlEncode(request.RequestUri.AbsoluteUri.ToLower());

            string requestHttpMethod = request.Method.Method;

            string serviceAuth = ConfigurationManager.AppSettings["api_auth"];

            string secretKey = ConfigurationManager.AppSettings["SecretKey"];
            //Calculate UNIX time
            DateTime epochStart = new DateTime(1970, 01, 01, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan timeSpan = DateTime.UtcNow - epochStart;
            string requestTimeStamp = Convert.ToUInt64(timeSpan.TotalSeconds).ToString();

            //create random nonce for each request
            string nonce = Guid.NewGuid().ToString("N");

            //Checking if the request contains body, usually will be null wiht HTTP GET and DELETE
            if (request.Content != null)
            {
                byte[] content = await request.Content.ReadAsByteArrayAsync();
                MD5 md5 = MD5.Create();
                //Hashing the request body, any change in request body will result in different hash, we'll incure message integrity
                byte[] requestContentHash = md5.ComputeHash(content);
                requestContentBase64String = Convert.ToBase64String(requestContentHash);
            }

            //Creating the raw signature string
            string signatureRawData = String.Format("{0}{1}{2}{3}{4}{5}", serviceAuth, requestHttpMethod, requestUri, requestTimeStamp, nonce, requestContentBase64String);

            var secretKeyByteArray = Convert.FromBase64String(secretKey);

            byte[] signature = Encoding.UTF8.GetBytes(signatureRawData);

            using (HMACSHA256 hmac = new HMACSHA256(secretKeyByteArray))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);
                string requestSignatureBase64String = Convert.ToBase64String(signatureBytes);
                //Setting the values in the Authorization header using custom scheme (amx)
                request.Headers.Authorization = new AuthenticationHeaderValue("basic", string.Format("{0}:{1}:{2}:{3}", serviceAuth, requestSignatureBase64String, nonce, requestTimeStamp));
            }

            response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}