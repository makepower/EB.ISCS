using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Repository.Sys
{
    public class SysExceptionLogRepository : BaseRepository<SysExceptionLog>
    {
        public SysExceptionLogRepository(SqlServerProvider provider, OperateInfo oInfo = null): base(provider, oInfo)
        {
        }

        public PagedListData<List<SysExceptionLog>> GetListByQuery(QueryExceptionLogModel query)
        {
            var model = new PageListModel()
            {
                WithColumn = @"[Id]
                              ,[AccessChannelId]
                              ,[UserId]
                              ,[CustomerId]
                              ,[ExceptionDate]
                              ,[ExceptionFunction]
                              ,[ExceptionVersions]
                              ,[ExceptionSource]
                              ,[ExceptionDescription]
                              ,[ExceptionStackTrace]
                              ,[ExceptionType]
                              ,[ExceptionTargetSite]
                              ,[ExceptionTypeName]
                              ,[ExceptionIP]
                              ,[IPNum]
                              ,[ComputerName]
                              ,[ExploreName]
                              ,[ExplorerVersions]
                              ,[SourceEquipment]
                              ,[Enabled]
                              ,[InUser]
                              ,[InDate]
                              ,[DeleteState]
                              ,[DeleteUser]
                              ,[DeleteDate]",
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
