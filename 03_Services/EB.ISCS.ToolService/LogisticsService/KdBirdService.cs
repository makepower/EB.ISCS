using EB.ISCS.FrameworkHelp.Tools;
using EB.ISCS.ToolService.Adapter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace EB.ISCS.ToolService
{
    /// <summary>
    /// 快递鸟物流跟踪服务
    /// 有效期1年 
    /// deaddate：2019-4-19
    /// </summary>
    public class KdBirdService
    {
        #region ==field==
        private string SandBoxURL = "http://sandboxapi.kdniao.cc:8080/kdniaosandbox/gateway/exterfaceInvoke.json";
        //请求url
        private string ReqURL = "http://api.kdniao.cc/Ebusiness/EbusinessOrderHandle.aspx";
        const string EBusinessID = "1336699";
        const string AppKey = "c7778173-f6bd-4076-86a6-c9fa963d87b7";
        #endregion

        #region ==private method==
        ///<summary>
        ///电商 Sign 签名
        ///</summary>
        ///<param name="content">内容</param>
        ///<param name="keyValue">APIkey</param>
        ///<param name="charset">URL 编码 </param>
        ///<returns>DataSign 签名</returns>
        private String Encrypt(String content, String keyValue, String charset)
        {
            if (keyValue != null)
            {
                return Base64(MD5(content + keyValue, charset), charset);
            }
            return Base64(MD5(content, charset), charset);
        }
        ///<summary>
        /// 字符串 MD5 加密
        ///</summary>
        ///<param name="Text">要加密的字符串</param>
        ///<returns>密文</returns>
        private string MD5(string Text, string charset)
        {
            byte[] buffer = System.Text.Encoding.GetEncoding(charset).GetBytes(Text);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider check;
                check = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] somme = check.ComputeHash(buffer);
                string ret = "";
                foreach (byte a in somme)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("X");
                    else
                        ret += a.ToString("X");
                }

                return ret.ToLower();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Base64
        /// </summary>
        /// <param name="str"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        private static string Base64(String str, String charset)
        {
            return Convert.ToBase64String(System.Text.Encoding.GetEncoding(charset).GetBytes(str));
        }

        /// <summary>
        /// Post方式提交数据，返回网页的源代码
        /// </summary>
        /// <param name="url">发送请求的 URL</param>
        /// <param name="param">请求的参数集合</param>
        /// <returns>远程资源的响应结果</returns>
        private string SendPost(string url, Dictionary<string, string> param)
        {
            string result = "";
            StringBuilder postData = new StringBuilder();
            if (param != null && param.Count > 0)
            {
                foreach (var p in param)
                {
                    if (postData.Length > 0)
                    {
                        postData.Append("&");
                    }
                    postData.Append(p.Key);
                    postData.Append("=");
                    postData.Append(p.Value);
                }
            }
            byte[] byteData = Encoding.GetEncoding("UTF-8").GetBytes(postData.ToString());
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/x-www-form-urlencoded";
                request.Referer = url;
                request.Accept = "*/*";
                request.Timeout = 30 * 1000;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
                request.Method = "POST";
                request.ContentLength = byteData.Length;
                Stream stream = request.GetRequestStream();
                stream.Write(byteData, 0, byteData.Length);
                stream.Flush();
                stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream backStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(backStream, Encoding.GetEncoding("UTF-8"));
                result = sr.ReadToEnd();
                sr.Close();
                backStream.Close();
                response.Close();
                request.Abort();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        private Dictionary<string, string> ParamsWrapper(string requestData, string requestType)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
            param.Add("EBusinessID", EBusinessID);
            param.Add("RequestType", requestType);
            string dataSign = Encrypt(requestData, AppKey, "UTF-8");
            param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
            param.Add("DataType", "2");
            return param;
        }

        #endregion



        /// <summary>
        ///  Json方式 查询订单物流轨迹
        /// </summary>
        /// <param name="orderCode"></param>
        /// <param name="shipperCode"></param>
        /// <param name="expNo"></param>
        /// <returns></returns>
        public LogisticsInfoResponse GetOrderTracesByJson(string orderCode, string shipperCode, string expNo)
        {
            string requestData = "{'OrderCode':'" + orderCode + "','ShipperCode':'" + shipperCode + "','LogisticCode':'" + expNo + "'}";
            Dictionary<string, string> param = ParamsWrapper(requestData, "1002");
            return JsonHelper.DeserializeObject<LogisticsInfoResponse>(SendPost(ReqURL, param));
        }

        /// <summary>
        ///  Json方式 查询订单物流轨迹
        /// </summary>
        /// <param name="orderCode"></param>
        /// <param name="expNo"></param>
        /// <returns></returns>
        public LogisticsInfoResponse GetOrderTracesByJson(string orderCode, string expNo)
        {
            var shipper = GetShipperCode(expNo);
            var shipperCode = string.Empty;
            if (shipper.Success)
            {
                shipperCode = shipper.Shippers[0].ShipperCode;
            }
            string requestData = "{'OrderCode':'" + orderCode + "','ShipperCode':'" + shipperCode + "','LogisticCode':'" + expNo + "'}";
            Dictionary<string, string> param = ParamsWrapper(requestData, "1002");
            return JsonHelper.DeserializeObject<LogisticsInfoResponse>(SendPost(ReqURL, param));
        }

        public ShipperInforResponse GetShipperCode(string logisticCode)
        {
            string requestData = "{'LogisticCode': '" + logisticCode + "'}";
            Dictionary<string, string> param = ParamsWrapper(requestData, "2002");
            string result = SendPost(ReqURL, param);

            return JsonHelper.DeserializeObject<ShipperInforResponse>(SendPost(ReqURL, param));
        }
    }
}
