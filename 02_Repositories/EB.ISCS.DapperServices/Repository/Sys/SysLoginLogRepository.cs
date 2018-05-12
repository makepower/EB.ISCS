using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EB.ISCS.DapperServices.Repository.Sys
{

    public class SysLoginLogRepository : BaseRepository<SysLoginLog>
    {
        public SysLoginLogRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }


        public int LoginOutByToken(string token, System.Data.IDbTransaction dbTransaction = null)
        {
            var sql = $@"update  [dbo].[SysLoginLog]  set [LogOutDate] = getdate()  where Token='{token}'";
            return TraceExecFunc(() =>
            {
                return Conn.Execute(sql, transaction: dbTransaction);
            }, sql);
        }

        public PagedListData<List<SysLoginLog>> GetListByQuery(QueryLoginLogModel query)
        {
            var model = new PageListModel()
            {
                WithColumn = @"[Id]
                              ,[AccessChannelId]
                              ,[UserId]
                              ,[UserName]
                              ,[LogDate]
                              ,[Token]
                              ,[LogOutDate]
                              ,[ClientIpAddress]
                              ,[ClientName]
                              ,[OnlineDate]
                              ,[IsSucceed]
                              ,[LogReason]
                              ,[SessionId]
                              ,[InUserType]
                              ,[IPNum]
                              ,[Enabled]
                              ,[DelUser]
                              ,[DelState]
                              ,[DelDate]",
                WithWhere = " 1=1",
                LeftColumn = string.Empty,
                LeftJoin = string.Empty,
            };


            var pageSearch = new PageSearch()
            {
                OrderBy = " LogDate desc",
                PageIndex = query.PageIndex,
                PageSize = query.PageSize,
                Where = query.Where
            };
            return this.PagedListQuery(model, pageSearch);
        }
    }
}
