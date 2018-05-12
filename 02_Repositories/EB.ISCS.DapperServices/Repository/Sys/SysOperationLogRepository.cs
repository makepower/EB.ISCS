using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Repository.Sys
{

    public class SysOperationLogRepository : BaseRepository<SysOperationLog>
    {
        public SysOperationLogRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }


        /// <summary>
        /// 删除指定id日志
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string id)
        {
            var sql = @"DECLARE @Sql NVARCHAR(MAX);
                        SET @Sql = N' UPDATE dbo.SysOperationLog    
		                    SET DelState = 1,
                            DelUser=@DelUser,
                            DelDate=GETDATE()
		                    WHERE 
				                    Id IN (' + @Id + ')';
                      EXEC sp_executesql @Sql, N' @Id  NVARCHAR(MAX),@DelUser INT', @Id,@DelUser";
            return Execute(sql, new { Id = id }) > 0;
        }

        public PagedListData<List<SysOperationLog>> GetListByQuery(QueryOperationLogModel query)
        {
            var model = new PageListModel()
            {
                WithColumn = @"[Id]
                              ,[AccessChannelId]
                              ,[UserId]
                              ,[CustomerId]
                              ,[ClientIpAddress]
                              ,[MenuName]
                              ,[MenuId]
                              ,[MenuActionId]
                              ,[MenuActionName]
                              ,[ServiceName]
                              ,[FunctionController]
                              ,[MethodAction]
                              ,[Parameters]
                              ,[ExecutionTime]
                              ,[ExecutionDuration]
                              ,[ClientName]
                              ,[BrowserInfo]
                              ,[Exception]
                              ,[Description]
                              ,[SourceEquipment]
                              ,[CustomData]
                              ,[IPNum]
                              ,[Token]
                              ,[Navigator]
                              ,[RequestUri]
                              ,[UrlReferrer]
                              ,[RequestType]
                              ,[Enabled]
                              ,[InUser]
                              ,[InDate]
                              ,[DelUser]
                              ,[DelState]
                              ,[DelDate]",
                WithWhere = " 1=1",
                LeftColumn = " B.UserName",
                LeftJoin = " Left join SysUser B on  A.UserId =B.Id",
            };
            var pageSearch = new PageSearch()
            {
                OrderBy = query.OrderBy,
                PageIndex = query.PageIndex,
                PageSize = query.PageSize,
                Where = query.Where
            };
            return this.PagedListQuery(model, pageSearch);
        }
    }
}
