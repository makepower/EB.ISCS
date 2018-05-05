using EB.ISCS.Common.Enum;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EB.ISCS.ToolService.TripartiteDataService
{
    //    爬取生意参谋浏览量数据接口
    //https://sycm.taobao.com/bda/flow/summary/getGeneral.json?dateRange=2017-03-20%7C2017-03-20&dateType=day&device=0&token=ec79a344f&_=1490151815229

    public class AliDataService : ExternalServices, IDataService
    {
        public ApiPlatform Platform => ApiPlatform.Ali;

        public string ServiceName => throw new NotImplementedException();

        public string ServiceDescription => throw new NotImplementedException();

        public void SyncData()
        {
            throw new NotImplementedException();
        }

        public override string Signature(IDictionary<string, string> parameters, string secret, string signMethod)
        {
            // 第一步：把字典按Key的字母顺序排序
            IDictionary<string, string> sortedParams = new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
            IEnumerator<KeyValuePair<string, string>> dem = sortedParams.GetEnumerator();
            // 第二步：把所有参数名和参数值串在一起
            StringBuilder query = new StringBuilder();
            if ("MD5".Equals(signMethod))
            {
                query.Append(secret);
            }
            while (dem.MoveNext())
            {
                string key = dem.Current.Key;
                string value = dem.Current.Value;
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    query.Append(key).Append(value);
                }
            }
            // 第三步：使用MD5/HMAC加密
            byte[] bytes;
            if ("HMAC_MD5".Equals(signMethod))
            {
                HMACMD5 hmac = new HMACMD5(Encoding.UTF8.GetBytes(secret));
                bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            }
            else
            {
                query.Append(secret);
                MD5 md5 = MD5.Create();
                bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(query.ToString()));
            }
            // 第四步：把二进制转化为大写的十六进制
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                result.Append(bytes[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}
