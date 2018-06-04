using AutoMapper;
using Maticsoft.Model;
using Maticsoft.Model.ISSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Top.Api.Domain;

namespace EB.ISCS.ToolService.Adapter
{
    public class AutoMapperFactory
    {
        private AutoMapperFactory() { }

        /// <summary>
        /// 注册映射
        /// </summary>
        public static void Register()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Trades, Trade>();
                x.CreateMap<OrderInfo, Trade>();
                x.CreateMap<GoodInfo, Product>();
            });
        }
    }
}
