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
            PagedListData<List<SysLoginLog>> model = new PagedListData<List<SysLoginLog>>();
            var sql = @"  DECLARE @Sql NVARCHAR(MAX);
                          DECLARE @OrderByNumber NVARCHAR(200);
               
                          IF @OrderBy IS NULL  OR @OrderBy = ''
                            BEGIN
                                SET @OrderByNumber = N' ORDER BY A.LogDate DESC';
                            END;	
                          ELSE
                            BEGIN
                                SET @OrderByNumber = N'ORDER BY ' + @OrderBy;
                            END;              
           
                          SET @Sql = N'; WITH SysLoginLogList AS
		                      (
			                SELECT   ROW_NUMBER() OVER ( ' + @OrderByNumber + ') RowNumber,
                                            A.UserId, 
                                            A.ID
                           FROM     [dbo].[SysLoginLog] AS  A WITH (NOLOCK)
					                INNER JOIN dbo.VSysUser  AS  B WITH (NOLOCK) ON A.UserId = B.Id
                           WHERE  A.DelState= 0  '  + '
                                    AND ( @BeginDate IS NULL OR A.LogDate > @BeginDate)
					                AND ( @EndDate IS NULL OR A.LogDate <= @EndDate )
							        AND ( @AccessChannelId IS NULL OR A.AccessChannelId = @AccessChannelId )
							        AND ( @CompanyId IS NULL OR A.CompanyId = @CompanyId )
							        AND ( @UserId IS NULL OR A.UserId = @UserId ) 
		                  )			
					        SELECT
                               B.Id
                              ,B.[UserName]
						      ,C.LoginName
							  ,B.[AccessChannelId]
                              ,B.[CompanyId]
                              ,B.[CompanyName]
                              ,B.[UserId]
                              ,B.[UserName] as UserName
                              ,B.[LogDate]
                              ,B.[Token]
                              ,B.[LogOutDate]
                              ,B.[ClientIpAddress]
                              ,B.[ClientName]
                              ,B.[OnlineDate]
                              ,B.[IsSucceed]
                              ,B.[LogReason]
                              ,B.[SessionId]
                              ,B.[InUserType]
						    FROM    SysLoginLogList AS A
                                    INNER JOIN dbo.SysLoginLog AS B WITH (NOLOCK) ON A.Id=B.Id
						            INNER JOIN dbo.VSysUser  AS C WITH (NOLOCK) ON  A.UserId = C.Id
						    WHERE          
			                ( @BeginDate IS NULL OR B.LogDate > @BeginDate)
			                  AND ( @EndDate IS NULL OR B.LogDate <= @EndDate )
							  AND ( @AccessChannelId IS NULL OR B.AccessChannelId = @AccessChannelId )
							  AND ( @CompanyId IS NULL OR B.CompanyId = @CompanyId )
							  AND ( @UserId IS NULL OR A.UserId = @UserId )
			                  AND (A.RowNumber BETWEEN ( @PageSize * ( @CurrentPageIndex - 1 ) + 1 )
					          AND  @PageSize * @CurrentPageIndex )
					     
					  SELECT  @Count = COUNT(1)
					  FROM    [dbo].[SysLoginLog] AS A WITH (NOLOCK)
                              INNER JOIN dbo.VSysUser AS B WITH (NOLOCK) ON A.UserId = B.Id
					  WHERE  A.DelState= 0 '   + ' 
					          AND (@BeginDate IS NULL OR A.LogDate > @BeginDate)
					          AND ( @EndDate IS NULL OR A.LogDate <= @EndDate )
					          AND ( @AccessChannelId IS NULL OR A.AccessChannelId = @AccessChannelId )
							  AND ( @CompanyId IS NULL OR A.CompanyId = @CompanyId )
							  AND ( @UserId IS NULL OR A.UserId = @UserId )   '					   
              EXEC sp_executesql @Sql, N'
					@CurrentPageIndex INT,
					@PageSize INT,
					@BeginDate DATETIME,
					@EndDate   DATETIME,
					@AccessChannelId INT,
					@CompanyId INT,
					@UserId INT,
                    @OrderBy NVARCHAR(200),
					@DelState INT,
					@Count  INT OUTPUT', 
							@CurrentPageIndex,
                            @PageSize, 
						    @BeginDate, 
						    @EndDate, 
							@AccessChannelId, 
							@CompanyId,
							@UserId, 
							@OrderBy ,
							@DelState, 										
							@Count OUTPUT ";
            DynamicParameters dp = new DynamicParameters();
            dp.Add("@CurrentPageIndex", query.PageIndex);
            dp.Add("@PageSize", query.PageSize);
            dp.Add("@BeginDate", query.BeginDate);
            dp.Add("@EndDate", query.EndDate);
            dp.Add("@AccessChannelId", query.AccessChannelId);
            dp.Add("@UserId", query.UserId);
            dp.Add("@DelState", query.DelState);
            dp.Add("@OrderBy", query.OrderBy);
            dp.Add("@Count", 0, DbType.Int32, ParameterDirection.Output);
            var data = this.Query("", dp);
            if (data != null)
            {
                var pageInfo = new PagingInfo(query.PageSize, query.PageIndex);
                model.PagingData = data?.ToList();
                pageInfo.TotalCount = dp.Get<int>("@Count");
                model.PagingInfo = pageInfo;
            }
            return model;
        }
    }
}
