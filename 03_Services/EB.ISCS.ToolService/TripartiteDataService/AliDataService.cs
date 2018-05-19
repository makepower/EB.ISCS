using EB.ISCS.Common.Enum;
using Maticsoft.Model;
using System;
using System.Collections.Generic;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;

namespace EB.ISCS.ToolService.TripartiteDataService
{
    //    爬取生意参谋浏览量数据接口
    //https://sycm.taobao.com/bda/flow/summary/getGeneral.json?dateRange=2017-03-20%7C2017-03-20&dateType=day&device=0&token=ec79a344f&_=1490151815229

    public class AliDataService : ExternalServices, ISyncDataService
    {
        public ApiPlatform Platform => ApiPlatform.Ali_Tb;

        const string url = "http://gw.api.taobao.com/router/rest";

        /// <summary>
        /// 同步交易数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public List<Trade> InitTradeSold(ShipInfo info)
        {
            ITopClient client = new DefaultTopClient(url, info.AppKey, info.AppSecret);

            var pageIndex = 1L;
            TradesSoldGetResponse rsp = null;
            var list = new List<Trade>();
            do
            {
                try
                {
                    TradesSoldGetRequest req = new TradesSoldGetRequest
                    {
                        Fields = "tid,type,status,payment,orders,rx_audit_status",
                        StartCreated = DateTime.Now.AddMonths(-3),
                        EndCreated = DateTime.Now,
                        PageNo = pageIndex,
                        PageSize = 100L,
                        UseHasNext = true
                    };
                    rsp = client.Execute(req, info.SessionKey);
                    pageIndex++;

                    if (!rsp.IsError)
                    {
                        list.AddRange(rsp.Trades);
                    }
                }
                catch (Exception e)
                {
                    break;
                }
            } while (rsp.HasNext);
            return list;
        }

        /// <summary>
        /// 同步增量交易数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public List<Trade> QueryTradeSoldIncrement(ShipInfo info)
        {
            ITopClient client = new DefaultTopClient(url, info.AppKey, info.AppSecret);

            var pageIndex = 1L;
            TradesSoldGetResponse rsp = null;
            var list = new List<Trade>();
            do
            {
                try
                {
                    TradesSoldGetRequest req = new TradesSoldGetRequest
                    {
                        Fields = "tid,type,status,payment,orders,rx_audit_status",
                        StartCreated = DateTime.Now.AddMonths(-3),
                        EndCreated = DateTime.Now,
                        PageNo = pageIndex,
                        PageSize = 100L,
                        UseHasNext = true
                    };
                    rsp = client.Execute(req, info.SessionKey);
                    pageIndex++;

                    if (!rsp.IsError)
                    {
                        list.AddRange(rsp.Trades);
                    }
                }
                catch (Exception e)
                {
                    break;
                }
            } while (rsp.HasNext);
            return list;
        }

        /// <summary>
        /// 同步交易详情数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public List<Trade> QueryTradeFullinfo(ShipInfo info)
        {
            ITopClient client = new DefaultTopClient(url, info.AppKey, info.AppSecret);

            var pageIndex = 1L;
            TradesSoldGetResponse rsp = null;
            var list = new List<Trade>();
            do
            {
                try
                {
                    TradesSoldGetRequest req = new TradesSoldGetRequest
                    {
                        Fields = "tid,type,status,payment,orders,rx_audit_status",
                        StartCreated = DateTime.Now.AddMonths(-3),
                        EndCreated = DateTime.Now,
                        PageNo = pageIndex,
                        PageSize = 100L,
                        UseHasNext = true
                    };
                    rsp = client.Execute(req, info.SessionKey);
                    pageIndex++;

                    if (!rsp.IsError)
                    {
                        list.AddRange(rsp.Trades);
                    }
                }
                catch (Exception e)
                {
                    break;
                }
            } while (rsp.HasNext);
            return list;
        }

        
        /// <summary>
        /// 商品类目
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public List<Trade> QueryShopCatsInfo(ShipInfo info)
        {
            ITopClient client = new DefaultTopClient(url, info.AppKey, info.AppSecret);

            var pageIndex = 1L;
            TradesSoldGetResponse rsp = null;
            var list = new List<Trade>();
            do
            {
                try
                {
                    TradesSoldGetRequest req = new TradesSoldGetRequest
                    {
                        Fields = "tid,type,status,payment,orders,rx_audit_status",
                        StartCreated = DateTime.Now.AddMonths(-3),
                        EndCreated = DateTime.Now,
                        PageNo = pageIndex,
                        PageSize = 100L,
                        UseHasNext = true
                    };
                    rsp = client.Execute(req, info.SessionKey);
                    pageIndex++;

                    if (!rsp.IsError)
                    {
                        list.AddRange(rsp.Trades);
                    }
                }
                catch (Exception e)
                {
                    break;
                }
            } while (rsp.HasNext);
            return list;
        }




    }
}
