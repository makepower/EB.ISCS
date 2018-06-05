using EB.ISCS.Common.Enum;
using EB.ISCS.FrameworkEntity;
using Jd.Api;
using Jd.Api.Domain;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace EB.ISCS.ToolService.TripartiteDataService
{
    public class JdDataService : ExternalServices, ISyncDataService
    {

        public JdDataService()
        { }


        public ApiPlatform Platform => ApiPlatform.Jd;

        public string TradesSoldGetUrl => throw new NotImplementedException();

        public string TradesSoldIncrementGetUrl => throw new NotImplementedException();

        public string TradeFullinfoGetUrl => throw new NotImplementedException();

        public string LogisticsOrdersGetUrl => throw new NotImplementedException();


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

        const string url = "http://gw.api.taobao.com/router/rest";

        /// <summary>
        /// 同步交易数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        //public List<Trade> InitTradeSold(ShipInfo info)
        //{
        //    IJdClient client = new DefaultJdClient(url, info.AppKey, info.AppSecret);

        //    var pageIndex = 1L;
        //    TradesSoldGetResponse rsp = null;
        //    var list = new List<Trade>();
        //    do
        //    {
        //        try
        //        {
        //            TradesSoldGetRequest req = new TradesSoldGetRequest
        //            {
        //                Fields = "tid,type,status,payment,orders,rx_audit_status",
        //                StartCreated = DateTime.Now.AddMonths(-3),
        //                EndCreated = DateTime.Now,
        //                PageNo = pageIndex,
        //                PageSize = 100L,
        //                UseHasNext = true
        //            };
        //            rsp = client.Execute(req, info.SessionKey);
        //            pageIndex++;

        //            if (!rsp.IsError)
        //            {
        //                list.AddRange(rsp.Trades);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            break;
        //        }
        //    } while (rsp.HasNext);
        //    return list;
        //}

        /// <summary>
        /// 同步增量交易数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        //public List<Trade> QueryTradeSoldIncrement(ShipInfo info, DataSyncRecord syncRecord)
        //{
        //    IJdClient client = new DefaultJdClient(url, info.AppKey, info.AppSecret);

        //    var pageIndex = 1L;
        //    TradesSoldIncrementGetResponse rsp = null;
        //    var list = new List<Trade>();
        //    do
        //    {
        //        try
        //        {
        //            TradesSoldIncrementGetRequest req = new TradesSoldIncrementGetRequest
        //            {
        //                Fields = "tid,type,status,payment,orders,rx_audit_status",
        //                StartModified = syncRecord.LastSynDate,
        //                EndModified = DateTime.Now,
        //                Status = "TRADE_NO_CREATE_PAY",
        //                Type = "fixed",
        //                BuyerNick = "zhangsan",
        //                ExtType = "service",
        //                Tag = "time_card",
        //                PageNo = 1L,
        //                RateStatus = "RATE_UNBUYER",
        //                PageSize = 40L,
        //                UseHasNext = true
        //            };
        //            rsp = client.Execute(req, info.SessionKey);
        //            pageIndex++;

        //            if (!rsp.IsError)
        //            {
        //                list.AddRange(rsp.Trades);
        //            }
        //            syncRecord.LastSynDate = req.EndModified.Value;
        //        }
        //        catch (Exception e)
        //        {
        //            break;
        //        }
        //    } while (rsp.HasNext);
        //    return list;
        //}

        /// <summary>
        /// 同步交易详情数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public OrderInfo QueryTradeFullinfo(ShipInfo info, long? id)
        {
            IJdClient client = new DefaultJdClient(url, info.AppKey, info.AppSecret);
            var pageIndex = 1L;
            //TradeFullinfoGetResponse rsp = null;
            //var trade = new Trade();
            try
            {
                //TradeFullinfoGetRequest req = new TradeFullinfoGetRequest
                //{
                //    Fields = "tid,type,status,payment,orders",
                //    Tid = id
                //};
                //rsp = client.Execute(req, info.SessionKey);
                //pageIndex++;

                //if (!rsp.IsError)
                //{
                //    trade = rsp.Trade;
                //}
            }
            catch (Exception e)
            {

            }
            return null;
        }


        /// <summary>
        /// 商品类目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public List<Product> QueryShopCatsInfo(ShipInfo info)
        {
            IJdClient client = new DefaultJdClient(url, info.AppKey, info.AppSecret);

            var pageIndex = 1L;
            Jd.Api.Response.EptJstoreProduceOrderQueryResponse rsp = null;
            var list = new List<Product>();

            try
            {
                //ProductsGetRequest req = new ProductsGetRequest
                //{
                //    Fields = "product_id,tsc,cat_name,name",

                //};
                //rsp = client.Execute(req, info.SessionKey);
                //pageIndex++;

                //if (!rsp.IsError)
                //{
                //    list.AddRange(rsp.Products);
                //}
            }
            catch (Exception e)
            {
            }

            return list;
        }

    }
}
