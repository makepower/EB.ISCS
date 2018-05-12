using System;
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
    public class SysUserRepository : BaseRepository<SysUser>
    {
        public SysUserRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }

        /// <summary>
        /// 获取用户权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserRoles GetUserRoles(int userId)
        {
            const string sql = @"select a.*,c.* from SysUser a 
                              left join SysUserRole b on b.UserId = a.id 
                              left join sysrole c on c.id = b.RoleId
                              where UserId = @UserId";
            List<UserRoles> urList = new List<UserRoles>();
            return TraceExecFunc<UserRoles>(() =>
            {
                var list = Conn.Query<SysUser, SysRole, UserRoles>(sql,
                    (u, r) => new UserRoles
                    {
                        User = u,
                        Roles = new List<SysRole>() { r }
                    },
                    new { UserId = userId }, splitOn: "id,id").ToList();
                list.ForEach(x =>
                {
                    var tmp = urList.FirstOrDefault(y => y.User.Id == x.User.Id);
                    if (tmp == null)
                    {
                        urList.Add(x);
                    }
                    else
                    {
                        tmp.Roles.AddRange(x.Roles);
                    }
                });
                return urList.FirstOrDefault(x => x.User.Id == userId);
            }, sql);
        }


        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="dbTrans"></param>
        /// <returns></returns>
        public int Insert(SysUser user, IDbTransaction dbTrans = null)
        {
            return TraceExecFunc(() =>
            {
                var sql = @"INSERT INTO [dbo].[SysUser]
           (
            [UserName]
           ,[LoginName]
           ,[PassWord]
           ,[LastPassword]
           ,[UserExtent]
           ,[Enabled]
           ,[UserIsFreeze]
           ,[UserIsManage]
           ,[UserRemark]
           ,[BeginDate]
           ,[ExpireDade]
           ,[IsExpireDate]
           ,[PartitionFalg]
           ,[FlowDepId]
           ,[FlowTypeCode]
           ,[UserType]
           ,[UserPosition]
           ,[UserCustomerId]
           ,[PlaneNumber]
           ,[WhetherDog]
           ,[Securitylevel]
           ,[DistrictId]
           ,[DataGroupId]
           ,[InUser]
           ,[InDate]
           ,[EditUser]
           ,[EditDate]
           ,[DelState]
           ,[DelUser]
           ,[DelDate])
     VALUES
           (
           @UserName
           ,@LoginName
           ,@PassWord
           ,@LastPassword
           ,@UserExtent
           ,@Enabled
           ,@UserIsFreeze
           ,@UserIsManage
           ,@UserRemark
           ,@BeginDate
           ,@ExpireDade
           ,@IsExpireDate
            ,@PartitionFalg
           ,@FlowDepId
           ,@FlowTypeCode
           ,@UserType
           ,@UserPosition
           ,@UserCustomerId
           ,@PlaneNumber
           ,@WhetherDog
           ,@Securitylevel
           ,@DistrictId
           ,@DataGroupId
           ,@InUser
           ,@InDate
           ,@EditUser
           ,@EditDate
           ,@DelState
           ,@DelUser
           ,@DelDate)";
                return this.Conn.Execute(sql, user, dbTrans);
            });
        }

        public List<SysUser> GetList()
        {
            var command = $"SELECT * FROM SYS_USER";
            return this.Conn.Query<SysUser>(command).ToList();
        }
       

        public SysUser Login(string loginName, string password)
        {
            return TraceExecFunc(() => GetFirst(" WHERE DelState = 0 AND LoginName = @LoginName AND PassWord = @PassWord ",
                new
                {
                    LoginName = loginName,
                    PassWord = password
                }));
        }

        public SysUser SuperLogin(string loginName, string password)
        {
            return TraceExecFunc(() => GetFirst(" WHERE DelState = 0 AND UserType = 2 AND LoginName = @LoginName AND PassWord = @PassWord ",
                new
                {
                    LoginName = loginName,
                    PassWord = password
                }));
        }

        /// <summary>
        /// 用户名是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="loginName"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool GetLoginNameIsRepeat(int id, string loginName, IDbTransaction transaction = null)
        {
            var command = @" SELECT 
            COUNT(1) 
        FROM SysUser
        WHERE DelState = 0 AND Id<>@Id AND LoginName=@LoginName ";
            return TraceExecFunc(() => Conn.ExecuteScalar<int>(command, new { Id = id, LoginName = loginName }, transaction) > 0);
        }

        public SysUser GetModelByPk(int id, IDbTransaction transaction = null)
        {
            var command = $@"SELECT 
			                    Id ,
			                    UserName ,
			                    LoginName ,
			                    PassWord ,
			                    LastPassword ,
			                    UserExtent ,
			                    Enabled ,
			                    UserIsFreeze ,
			                    UserIsManage ,
			                    UserRemark ,
			                    BeginDate ,
			                    ExpireDade ,
			                    IsExpireDate ,
			                    PartitionFalg ,
			                    FlowDepId ,
			                    FlowTypeCode ,
			                    UserType ,
			                    UserPosition ,
			                    UserCustomerId ,
			                    PlaneNumber ,
			                    WhetherDog ,
			                    Securitylevel ,
			                    DistrictId ,
			                    DataGroupId ,
			                    InUser ,
			                    InDate ,
			                    EditUser ,
			                    EditDate ,
			                    DelUser ,
			                    DelState ,
			                    DelDate
	   	                    FROM dbo.SysUser WHERE 
	                       Id = @Id";
            return TraceExecFunc(() => Conn.QueryFirstOrDefault<SysUser>(command, new { Id = id }, transaction));
        }


        #region 自定义方法

        /// <summary>
        /// 更改用户密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePassWord(SysUser model, IDbTransaction transaction = null)
        {
            var command = @"UPDATE dbo.SysUser SET			
				                        PassWord = @PassWord ,
				                        LastPassword = @LastPassword ,			
				                        EditUser = @EditUser,
                                EditDate = @EditDate
		                        WHERE
                              LoginName = @LoginName AND Id = @UserID";
            return TraceExecFunc(() => Conn.Execute(command,
                new
                {
                    Password = model.PassWord,
                    LastPassword = model.LastPassword,
                    EditUser = model.EditUser,
                    EditDate = model.EditDate,
                    LoginName = model.LoginName,
                    UserID = model.Id
                }, transaction) >= 0);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ChangePassword(SysUser model, IDbTransaction transaction = null)
        {
            var command = @"UPDATE dbo.SysUser SET
				                    PassWord = @PassWord
                            WHERE Id=@Id";
            var dp = new DynamicParameters();
            dp.Add("@Id", model.Id);
            dp.Add("@PassWord", model.PassWord);

            return TraceExecFunc(() => Conn.Execute(command,
                new
                {
                    Id = model.Id,
                    PassWord = model.PassWord
                },
                transaction) >= 0);
        }
        /// <summary>
        /// 根据公司编号和 用户名称查询是否存在
        /// </summary>
        /// <param name="companyCode"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool Exists(string companyCode, string loginName, IDbTransaction transaction = null)
        {
            var command = @"SELECT COUNT(1)
	   	                FROM dbo.SysUser WHERE
                      CompanyCode = @CompanyCode AND LoginName = @LoginName AND Id<>@UserID";
            return TraceExecFunc(() => Conn.ExecuteScalar<bool>(command,
                new
                {
                    CompanyCode = companyCode,
                    LoginName = loginName,
                }, transaction));
        }

        /// <summary>
        /// 查询下拉用户列表信息
        /// </summary>
        /// <returns></returns>
        public List<SysUser> GetList(IDbTransaction transaction = null)
        {
            return TraceExecFunc(() => this.GetAll(" WHERE DelState = 0", transaction).ToList());
        }

        #endregion


        #region MyRegion

        /// <summary>
        /// 根据条件获取用户列表
        /// </summary>
        /// <param name="query"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public PagedListData<List<SysUser>> GetUserListByQuery(QueryUserModel query, IDbTransaction transaction = null)
        {
            var sql = @"  DECLARE @Sql NVARCHAR(MAX);
                            DECLARE @Order NVARCHAR(200);      
                            IF ( @OrderBy IS NOT  NULL AND  @OrderBy<>'')
                                BEGIN
                        SET @Order = 'ORDER BY ' + @OrderBy;
                                END;
                            ELSE
                                BEGIN
                                    SET @Order = '  ORDER BY InDate DESC ';
                                END;
                           IF ( @Where IS  NULL)
                                BEGIN
                        SET @Where = '';
                                END;
                            SET @Sql = N' 
                         WITH  SysUserList  AS
                      (
                       SELECT  ROW_NUMBER() OVER ( ' + @Order + ' ) RowNumber,
                        [Id]
                          ,[UserName]
                          ,[LoginName]
                          ,[UserExtent]
                          ,[Enabled]
                          ,[UserIsFreeze]
                          ,[UserIsManage]
                          ,[UserRemark]
                          ,[BeginDate]
                          ,[ExpireDade]
                          ,[IsExpireDate]
                          ,[PartitionFalg]
                          ,[FlowDepId]
                          ,[FlowTypeCode]
                          ,[UserType]
                          ,[UserPosition]
                          ,[UserCustomerId]
                          ,[PlaneNumber]
                          ,[WhetherDog]
                          ,[Securitylevel]
                          ,[DistrictId]
                          ,[DataGroupId]
                          ,[InUser]
                          ,[InDate]
                          ,[EditUser]
                          ,[EditDate]
                          ,[DelUser]
                          ,[DelState]
                          ,[DelDate]
                      FROM    dbo.SysUser WHERE DelState = 0 AND Enabled=1' + @Where + '
                       )
                      SELECT
                         A.[Id]
                        ,A.[UserName]
                        ,A.[LoginName]
                        ,A.[UserExtent]
                        ,A.[Enabled]
                        ,A.[UserIsFreeze]
                        ,A.[UserIsManage]
                        ,A.[UserRemark]
                        ,A.[BeginDate]
                        ,A.[ExpireDade]
                        ,A.[IsExpireDate]
                        ,A.[PartitionFalg]
                        ,A.[FlowDepId]
                        ,A.[FlowTypeCode]
                        ,A.[UserType]
                        ,A.[UserPosition]
                        ,A.[UserCustomerId]
                        ,A.[PlaneNumber]
                        ,A.[WhetherDog]
                        ,A.[Securitylevel]
                        ,A.[DistrictId]
                        ,A.[DataGroupId]
                        ,A.[InUser]
                        ,CONVERT(varchar(20), A.[InDate], 20) InDate
                        ,A.[EditUser]
                        ,CONVERT(varchar(20), A.[EditDate], 20) EditDate
                        ,A.[DelUser]
                        ,A.[DelState]
                        ,A.[DelDate]
                        ,D.UserName InUserName
                        ,E.UserName EditUserName
                      FROM SysUserList A
                      LEFT JOIN  SysUser D
                      ON   A.InUser=D.Id
                      LEFT JOIN SysUser E
                      ON A.EditUser=E.Id
                      WHERE (RowNumber BETWEEN ( @PageSize * ( @CurrentPageIndex - 1 ) + 1 )
                                   AND  @PageSize * @CurrentPageIndex )

                     SELECT   @Count = COUNT(1)
                     FROM dbo.SysUser WHERE DelState = 0 AND Enabled=1  AND UserIsManage=0 ' + @Where;              
                            EXECUTE sp_executesql @Sql,N'  
                           @CurrentPageIndex INT,
                           @PageSize  INT,
                           @Where NVARCHAR(1000),
                           @OrderBy NVARCHAR(200),         
                           @Count int OUT',
                           @CurrentPageIndex, 
                           @PageSize,
                           @Where,
                           @OrderBy,
                           @Count OUTPUT;";

            PagedListData<List<SysUser>> model = new PagedListData<List<SysUser>>();
            var dp = new DynamicParameters();
            dp.Add("@CurrentPageIndex", query.PageIndex);
            dp.Add("@PageSize", query.PageSize);
            dp.Add("@Where", query.Where);
            dp.Add("@OrderBy", query.OrderBy);
            dp.Add("@Count", 0, DbType.Int32, ParameterDirection.Output);
            var data = this.Query(sql, dp, transaction);
            var pageInfo = new PagingInfo(query.PageSize, query.PageIndex);
            model.PagingData = data?.ToList();
            pageInfo.TotalCount = dp.Get<int>("@Count");
            model.PagingInfo = pageInfo;
            return model;
        }

        #endregion


        /// <summary>
        /// 获取所有的SysUser信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SysUser> GetAllList(IDbTransaction transaction = null)
        {
            var sql = @" select * FROM SysUser where DelState = 0 or DelState is null AND Enabled=1 ";
            return TraceExecFunc(() => this.Conn.Query<SysUser>(sql, transaction));
        }
    }
}
