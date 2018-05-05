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
            PagedListData<List<SysExceptionLog>> model = new PagedListData<List<SysExceptionLog>>();
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
           
                      SET @Sql = N'; WITH SysExceptionLogList AS
		                  (
			                     SELECT   ROW_NUMBER() OVER ( ' + @OrderByNumber
                        + ') RowNumber,
                                                    A.UserId, 
                                                    A.ID
                           FROM     [dbo].[SysExceptionLog] AS  A WITH (NOLOCK)
					                INNER JOIN dbo.VSysUser  AS  B WITH (NOLOCK) ON A.UserId = B.Id
                           WHERE  A.DeleteState=0 ' 
                        + '
                                    AND ( @BeginDate IS NULL OR A.InDate > @BeginDate)
					                AND ( @EndDate IS NULL OR A.InDate <= @EndDate )
							        AND ( @AccessChannelId IS NULL OR A.AccessChannelId = @AccessChannelId )
							        AND ( @CompanyId IS NULL OR A.CompanyId = @CompanyId )
							        AND ( @UserId IS NULL OR A.UserId = @UserId )
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
                              ,B.[ExceptionDate]
                              ,B.[ExceptionFunction]
                              ,B.[ExceptionVersions]
                              ,B.[ExceptionSource]
                              ,B.[ExceptionDescription]
                              ,B.[ExceptionStackTrace]
                              ,B.[ExceptionType]
                              ,B.[ExceptionTargetSite]
                              ,B.[ExceptionTypeName]
                              ,B.[ExceptionIP]
                              ,B.[IPNum]
                              ,B.[ComputerName]
                              ,B.[ExploreName]
                              ,B.[ExplorerVersions]
                              ,B.[SourceEquipment]
                              ,B.[Enabled]
                              ,B.[InUser]
                              ,B.[InDate]
						    FROM    SysExceptionLogList AS A
                                    INNER JOIN dbo.SysExceptionLog AS B WITH (NOLOCK) ON A.Id=B.Id
						            INNER JOIN dbo.VSysUser  AS C WITH (NOLOCK) ON  A.UserId = C.Id
						    WHERE          
			                ( @BeginDate IS NULL OR B.InDate > @BeginDate)
			                  AND ( @EndDate IS NULL OR B.InDate <= @EndDate )
							  AND ( @AccessChannelId IS NULL OR B.AccessChannelId = @AccessChannelId )
							  AND ( @CompanyId IS NULL OR B.CompanyId = @CompanyId )
							  AND ( @UserId IS NULL OR A.UserId = @UserId )
			                  AND (A.RowNumber BETWEEN ( @PageSize * ( @CurrentPageIndex - 1 ) + 1 )
					          AND  @PageSize * @CurrentPageIndex )
					     
					  SELECT  @Count = COUNT(1)
					  FROM    [dbo].[SysExceptionLog] AS A WITH (NOLOCK)
                              INNER JOIN dbo.VSysUser AS B WITH (NOLOCK) ON A.UserId = B.Id
					  WHERE  A.DeleteState= 0 '  + ' 
					          AND (@BeginDate IS NULL OR A.InDate > @BeginDate)
					          AND ( @EndDate IS NULL OR A.InDate <= @EndDate )
					          AND ( @AccessChannelId IS NULL OR A.AccessChannelId = @AccessChannelId )
							  AND ( @CompanyId IS NULL OR A.CompanyId = @CompanyId )
							  AND ( @UserId IS NULL OR A.UserId = @UserId )
					       '					   
                       EXEC sp_executesql @Sql, N'
							@CurrentPageIndex INT,
							@PageSize INT,
						    @BeginDate DATETIME,
						    @EndDate   DATETIME,
							@AccessChannelId INT,
							@CompanyId INT,
							@UserId INT,
                            @OrderBy NVARCHAR(200),
							@DeleteState INT,
							@Count  INT OUTPUT', 
										@CurrentPageIndex,
                                        @PageSize, 
										@BeginDate, 
										@EndDate, 
										@AccessChannelId, 
										@CompanyId,
										@UserId, 
										@OrderBy,
										@DeleteState, 										
										@Count OUTPUT ";

            DynamicParameters dp = new DynamicParameters();
            dp.Add("@CurrentPageIndex", query.PageIndex);
            dp.Add("@PageSize", query.PageSize);
            dp.Add("@BeginDate", query.BeginDate);
            dp.Add("@EndDate", query.EndDate);
            dp.Add("@AccessChannelId", query.AccessChannelId);
            dp.Add("@UserId", query.UserId);
            dp.Add("@DeleteState", query.DeleteState);
            dp.Add("@OrderBy", query.OrderBy);
            dp.Add("@Count", 0, DbType.Int32, ParameterDirection.Output);
            var data = Query(sql, dp);
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
