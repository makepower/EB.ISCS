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
            PagedListData<List<SysOperationLog>> model = new PagedListData<List<SysOperationLog>>();
            var sql = @"DECLARE @Sql NVARCHAR(MAX);
              DECLARE @OrderByNumber NVARCHAR(200);
               
              IF @OrderBy IS NULL  OR @OrderBy = ''
                BEGIN
                    SET @OrderByNumber = N' ORDER BY A.InDate DESC';
                END;	
              ELSE
                BEGIN
                    SET @OrderByNumber = N'ORDER BY ' + @OrderBy;
                END;              
           
              SET @Sql = N'; WITH SysOperateLogList AS
		          (
			             SELECT   ROW_NUMBER() OVER ( ' + @OrderByNumber
                + ') RowNumber,
                                            A.UserId, 
                                            A.ID
                   FROM     [dbo].[SysOperationLog] AS  A WITH (NOLOCK)
					        INNER JOIN dbo.VSysUser  AS  B WITH (NOLOCK) ON A.UserId = B.Id
                   WHERE  A.DelState=0 ' 
                + '
                            AND ( @BeginDate IS NULL OR A.InDate > @BeginDate)
					        AND ( @EndDate IS NULL OR A.InDate <= @EndDate )
							AND ( @AccessChannelId IS NULL OR A.AccessChannelId = @AccessChannelId )
							AND ( @CompanyId IS NULL OR A.CompanyId = @CompanyId )
							AND ( @UserId IS NULL OR A.UserId = @UserId )
					        AND ( @MenuName IS NULL OR A.MenuName LIKE ''%'' + @MenuName + ''%'')
							AND ( @Exception IS NULL OR A.Exception LIKE ''%'' + @Exception + ''%'') 
							AND ( @MenuActionName IS NULL OR A.MenuActionName LIKE ''%'' + @MenuActionName + ''%'') 
		          )			
					   SELECT
                               B.Id
                              ,C.UserName
						      ,C.LoginName
						      ,C.CompanyName
							    ,B.[AccessChannelId]
								  ,B.[CompanyId]
								  ,B.[UserId]
								  ,B.[CustomerId]
								  ,B.[ClientIpAddress]
								  ,B.[MenuName]
								  ,B.[MenuId]
								  ,B.[MenuActionId]
								  ,B.[MenuActionName]
								  ,B.[ServiceName]
								  ,B.[FunctionController]
								  ,B.[MethodAction]
								  ,B.[Parameters]
								  ,B.[ExecutionTime]
								  ,B.[ExecutionDuration]
								  ,B.[ClientName]
								  ,B.[BrowserInfo]
								  ,B.[Exception]
								  ,B.[Description]
								  ,B.[SourceEquipment]
								  ,B.[CustomData]
								  ,B.[Navigator]
								  ,B.[RequestUri]
								  ,B.[UrlReferrer]
								  ,B.[RequestType]
								  ,B.[InDate]
						    FROM    SysOperateLogList AS A
                                    INNER JOIN dbo.SysOperationLog AS B WITH (NOLOCK) ON A.Id=B.Id
						            INNER JOIN dbo.VSysUser  AS C WITH (NOLOCK) ON  A.UserId = C.Id
						    WHERE          
			                ( @BeginDate IS NULL OR B.InDate > @BeginDate)
			                  AND ( @EndDate IS NULL OR B.InDate <= @EndDate )
							  AND ( @AccessChannelId IS NULL OR B.AccessChannelId = @AccessChannelId )
							  AND ( @CompanyId IS NULL OR B.CompanyId = @CompanyId )
							  AND ( @UserId IS NULL OR A.UserId = @UserId )
					          AND ( @MenuName IS NULL OR B.MenuName LIKE ''%'' + @MenuName + ''%'')
							  AND ( @Exception IS NULL OR B.Exception LIKE ''%'' + @Exception + ''%'') 
							  AND ( @MenuActionName IS NULL OR B.MenuActionName LIKE ''%'' + @MenuActionName + ''%'')
			                  AND (A.RowNumber BETWEEN ( @PageSize * ( @CurrentPageIndex - 1 ) + 1 )
					          AND  @PageSize * @CurrentPageIndex )
					     
					  SELECT  @Count = COUNT(1)
					  FROM    [dbo].[SysOperationLog] AS A WITH (NOLOCK)
                              INNER JOIN dbo.VSysUser AS B WITH (NOLOCK) ON A.UserId = B.Id
					  WHERE  A.DelState= 0 ' 
                + ' 
					          AND (@BeginDate IS NULL OR A.InDate > @BeginDate)
					          AND ( @EndDate IS NULL OR A.InDate <= @EndDate )
					          AND ( @AccessChannelId IS NULL OR A.AccessChannelId = @AccessChannelId )
							  AND ( @CompanyId IS NULL OR A.CompanyId = @CompanyId )
							  AND ( @UserId IS NULL OR A.UserId = @UserId )
					          AND ( @MenuName IS NULL OR A.MenuName LIKE ''%'' + @MenuName + ''%'')
							  AND ( @Exception IS NULL OR A.Exception LIKE ''%'' + @Exception + ''%'') 
							  AND ( @MenuActionName IS NULL OR A.MenuActionName LIKE ''%'' + @MenuActionName + ''%'')	  
					       '					   
              EXEC sp_executesql @Sql, N'
							            @CurrentPageIndex INT,
							            @PageSize INT,
							            @BeginDate DATETIME,
							            @EndDate   DATETIME,
									      	@AccessChannelId INT,
									      	@CompanyId INT,
									      	@UserId INT,
									      	@MenuName NVARCHAR(200),
									      	@Exception  NVARCHAR(200),
									      	@MenuActionName  NVARCHAR(200),
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
										@MenuName, 
										@Exception,
										@MenuActionName,
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
            dp.Add("@MenuName", query.MenuName);
            dp.Add("@Exception", query.Exception);
            dp.Add("@MenuActionName", query.MenuActionName);
            dp.Add("@DelState", query.DelState);
            dp.Add("@OrderBy", query.OrderBy);
            dp.Add("@Count", 0, DbType.Int32, ParameterDirection.Output);
            var data = this.Query(sql, dp);
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
