using Dapper;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.Repository.Sys
{
    public class SysLoginTokenRepository : BaseRepository<SysLoginToken>
    {
        public SysLoginTokenRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }

        /// <summary>
        /// 根据token获取用户
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public SysLoginToken GetByToken(string token)
        {
            var sql = @"SELECT  
                            UserId ,
                            CustomerId ,
                            Token ,
                            CustomerUser ,
                            AccessChannelId ,
                            ExpriedTime 
                      FROM dbo.SysLoginToken 
                      WHERE     Token = @Token";
            var result = TraceExecFunc<SysLoginToken>(
                () => this.Conn.QueryFirstOrDefault<SysLoginToken>(sql, new { Token = token }));
            return result;
        }


        /// <summary>
        /// 禁用token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public int DisableToken(string token, System.Data.IDbTransaction trans = null)
        {
            var sql = @"  update [SysLoginToken] set [ExpriedTime] =GETDATE() where Token = @Token";
            var result = TraceExecFunc<int>(
                () => this.Conn.Execute(sql, new { Token = token }, transaction: trans));
            return result;
        }

        public bool Add(SysLoginToken model)
        {
            var sql = @"Insert Into SysLoginToken(         
                            UserId ,
                            CustomerId ,
                            Token ,
                            CustomerUser ,
                            AccessChannelId ,
                            ExpriedTime,
                            InDate) 
                        values(    
                            @UserId ,
                            @CustomerId ,
                            @Token ,
                            @CustomerUser ,
                            @AccessChannelId ,
                            @ExpriedTime,
                            @InDate
                            )";
            return this.Conn.Execute(sql, new
            {
                UserId = model.UserId,
                CustomerId = model.CustomerId,
                Token = model.Token,
                CustomerUser = model.CustomerUser,
                AccessChannelId = model.AccessChannelId,
                ExpriedTime = model.ExpriedTime,
                InDate = model.InDate
            }) > 0;
        }
    }
}
