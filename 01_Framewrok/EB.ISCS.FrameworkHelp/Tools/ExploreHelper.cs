using System.Net;
using System.Web;

namespace EB.ISCS.FrameworkHelp.Tools
{
    public class ExploreHelper
    {
        /// <summary>
        /// 
        /// </summary>
        public HttpRequestBase httpRequest = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        public ExploreHelper(HttpRequestBase request)
        {
            httpRequest = request;
        }
        public string ExploreType
        {
            get
            {
                if (httpRequest != null)
                {
                    return httpRequest.Browser.Browser;
                }
                return string.Empty;
            }
        }
        public string ExploreVersion
        {
            get
            {
                if (httpRequest != null)
                {
                    return httpRequest.Browser.Version;
                }
                return string.Empty;
            }
        }
        public string ClientIP6
        {
            get
            {
                if (httpRequest != null)
                {
                    string ip = httpRequest.ServerVariables["http_x_forwarded_for"];
                    if (string.IsNullOrEmpty(ip))
                        ip = httpRequest.ServerVariables["REMOTE_ADDR"];
                    return ip;
                }
                return string.Empty;
            }
        }
        public string ClientIP
        {
            get
            {
                if (httpRequest != null)
                {
                    return GetClientIPv4Address(httpRequest);
                }
                return string.Empty;
            }
        }

        public string ServerIp6
        {
            get
            {
                if (httpRequest != null)
                {
                    return httpRequest.ServerVariables["LOCAL_ADDR"];
                }
                return string.Empty;
            }
        }
        public string ServerIp
        {
            get
            {
                IPHostEntry here = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress localaddress4 = null;
                foreach (IPAddress _ip in here.AddressList)
                {
                    if (_ip.AddressFamily.ToString().ToUpper() == "INTERNETWORK")
                    {
                        localaddress4 = _ip;
                    }

                }
                return localaddress4.ToString();
            }
        }

        public string ClientMachineName
        {
            get
            {
                if (httpRequest != null)
                {
                    return httpRequest.ServerVariables["remote_host"];
                }
                return string.Empty;
            }
        }


        public static string GetClientIPv4Address(HttpRequestBase request)
        {
            string ipv4 = string.Empty;

            foreach (IPAddress ip in Dns.GetHostAddresses(GetClientIP(request)))
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    ipv4 = ip.ToString();
                    break;
                }
            }

            if (ipv4 != string.Empty)
            {
                return ipv4;
            }
            // 利用 Dns.GetHostEntry 方法，由获取的 IPv6 位址反查 DNS 纪录，
            // 再逐一判断何者为 IPv4 协议，即可转为 IPv4 位址。
            //foreach (IPAddress ip in Dns.GetHostAddresses(Dns.GetHostName()))
            foreach (IPAddress ip in Dns.GetHostEntry(GetClientIP(request)).AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    ipv4 = ip.ToString();
                    break;
                }
            }

            return ipv4;
        }
        public static string GetClientIP(HttpRequestBase request)
        {
            if (null == request.ServerVariables["HTTP_VIA"])
            {
                return request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                return request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
        }

    }

}