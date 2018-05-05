using Dapper;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity.Base;
using EB.ISCS.FrameworkLog.LogModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EB.ISCS.DapperServices.Repository
{
    /// <summary>
    /// 仓储层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> where T : class
    {
        private readonly SqlServerProvider _provider;
        private OperateInfo _oInfo;

        public BaseRepository(SqlServerProvider provider, OperateInfo oInfo = null)
        {
            _provider = provider ?? DapperProvider.GetProvider(DapperProvider.GetConnString());
            _oInfo = oInfo;
        }

        /// <summary>
        /// 设置操作信息
        /// </summary>
        /// <param name="oInfo"></param>
        public void SetOperateInfo(OperateInfo oInfo = null)
        {
            _oInfo = oInfo;
        }
        private bool IsConnection()
        {
            return _provider != null && _provider.Conn != null &&
                   _provider.Conn.State == ConnectionState.Open;
        }
        protected SqlConnection Conn { get { return _provider.Conn; } }

        #region 普通增删改查操作

        public T Get(int id, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                //此处语句为构造日志用
                var sql = $"select * from {GetTableName()} where Id = {id}";
                return TraceExecFunc<T>(() => Conn.Get<T>(id, transaction), sql);
            }
            return null;
        }

        #region 记录日志信息
        public T2 TraceExecFunc<T2>(Func<T2> funcProcess, string msg = "")
        {
            if (funcProcess == null)
            {
                return default(T2);
            }
            var sb = new StringBuilder();
            sb.AppendFormat("执行函数：{0},返回：{1}，详细信息：{2}", funcProcess.Method.Name, typeof(T2).Name, msg ?? "");
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                var rtn = funcProcess();
                sw.Stop();
                sb.AppendFormat(",函数执行时间：{0} ms", sw.ElapsedMilliseconds);
                LogHelper.WriteInfoLog(sb.ToString());
                return rtn;
            }
            catch (Exception e)
            {
                LogHelper.WriteErrorLog(sb.ToString(), e);
                return default(T2);
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conditions">eg:where @a=a and b=b </param>
        /// <param name="param">eg:new{a=a} </param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public T GetFirst(string conditions, object param = null, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                var tableName = GetTableName();
                string sql = $"select top 1 * from  {tableName} {conditions}";
                return TraceExecFunc<T>(() => Conn.QueryFirstOrDefault<T>(sql, param, transaction), sql);
            }
            return null;
        }
        /// <summary>
        ///  查询表内所有的记录
        ///  异常时函数返回 null，无法.ToList(),此处不处理，以便异常时处理内部查询错误
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                var tableName = GetTableName();
                var sql = $"select * from  {tableName}";
                var rtn = TraceExecFunc<IEnumerable<T>>(() => Conn.GetList<T>(transaction), sql);
                return rtn ?? new List<T>();
            }
            return new List<T>();
        }
        /// <summary>
        ///  使用实体属性过滤查询，例如 new {Id=1,Name="abc"}
        ///  异常时函数返回 null，无法.ToList(),此处不处理，以便异常时处理内部查询错误
        /// </summary>
        /// <param name="whereConditions"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(object whereConditions, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                var tableName = GetTableName();
                var sql = $"select * from  {tableName} where {GetEntityDesc(whereConditions)}";
                var rtn = TraceExecFunc<IEnumerable<T>>(() => Conn.GetList<T>(whereConditions, transaction), sql);
                //return rtn ?? new List<T>();
                return rtn;
            }
            return new List<T>();
        }

        #region 产生日志信息的输出语句
        private string GetEntityDesc(object entity)
        {
            if (entity == null)
            {
                return " 1=1";
            }
            var idProps = GetAllProperties(entity);
            StringBuilder sb = new StringBuilder();
            foreach (var pinfo in idProps)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" , ");
                }

                var v = pinfo.GetValue(entity, null);
                sb.AppendFormat("{0} {1} {2}", pinfo.Name, "=", v?.ToString() ?? "null");
            }
            return sb.ToString();
        }

        /// <summary>
        /// 判断是否有删除标识
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private bool HasDelState(T entity)
        {
            var obj = Activator.CreateInstance<T>();
            var idprops = GetAllProperties(obj);
            return idprops.Any(x => x.Name == "DelState");
        }
        private bool HasDelState(Type t)
        {
            var obj = Activator.CreateInstance(t);
            var idprops = GetAllProperties(obj);
            return idprops.Any(x => x.Name == "DelState");
        }
        private static IEnumerable<PropertyInfo> GetAllProperties(object entity)
        {
            if (entity == null) entity = new { };
            return entity.GetType().GetProperties();
        }
        #endregion
        /// <summary>
        /// 返回根据条件查询的集合数据
        /// 异常时函数返回 null，无法.ToList(),此处不处理，以便异常时处理内部查询错误
        /// </summary>
        /// <param name="conditions"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IEnumerable<T> GetAll(string conditions, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                var tableName = GetTableName();
                var sql = $"select * from  {tableName} {conditions}";
                var rtn = TraceExecFunc(
                    () => Conn.GetList<T>(
                        conditions,
                        transaction, null),
                    sql);
                //return rtn ?? new List<T>();
                return rtn;
            }
            return new List<T>();
        }
        public int Insert(T entity, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                return TraceExecFunc<int>(() => Conn.Insert(entity, transaction) ?? 0, GetEntityDesc(entity));
            }
            else
            {
                return 0;
            }
        }
        public bool Update(T entity, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                return TraceExecFunc<bool>(() => Conn.Update(entity, transaction) > 0, GetEntityDesc(entity));
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新数据行，值为Null，不更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool UpdateReal(T entity, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                PropertyInfo[] properties = entity.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if (properties.Length <= 0)
                {
                    return false;
                }

                var where = string.Empty;
                var sql = $@"Update {entity.GetType().Name} Set ";
                foreach (var item in properties)
                {
                    var value = item.GetValue(entity, null);
                    var keys = item.GetCustomAttributes(typeof(Dapper.KeyAttribute), true);
                    if (keys.Length == 1)
                    {
                        where = $" WHERE {item.Name}={Convert.ToInt32(value)}";
                    }
                    else
                    {
                        if (value == null) continue;
                        var noMapped = item.GetCustomAttributes(typeof(Dapper.NotMappedAttribute), true);
                        if (noMapped.Length < 1)
                        {
                            sql += $@" {item.Name}='{value}',";
                        }
                    }
                }

                sql = sql.Substring(0, sql.Length - 1) + where;
                return TraceExecFunc<bool>(() => Conn.Execute(sql, null, transaction) > 0);
            }
            else
            {
                return false;
            }
        }


        public bool Delete(T entity, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                if (HasDelState(entity))
                {
                    var sql = $"update {this.GetTableName()} set DelState = 1 where id = {((dynamic)entity).Id}";
                    return TraceExecFunc<bool>(() => Conn.Execute(sql) >= 0, sql);
                }
                else
                {
                    return TraceExecFunc<bool>(() => Conn.Delete(entity) >= 0, GetEntityDesc(entity));
                }
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                if (HasDelState(typeof(T)))
                {
                    var sql = $"update {this.GetTableName()} set DelState = 1 where Id=@Id";
                    return TraceExecFunc<bool>(() => Conn.Execute(sql, new
                    {
                        Id = id
                    }, transaction) >= 0, sql);
                }
                else
                {
                    return TraceExecFunc<bool>(() => Conn.Delete<T>(id, transaction) >= 0, "id=" + id.ToString());
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除指定的ids集合，形如: 1,2,3,4
        /// </summary>
        /// <param name="ids">,分割</param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Delete(string ids, IDbTransaction transaction = null)
        {
            var arrIds = ids?.Split(new char[] { ',' });
            if (arrIds == null)
            {
                return true;
            }
            if (IsConnection())
            {
                if (HasDelState(typeof(T)))
                {
                    var sql = $"update {this.GetTableName()} set DelState = 1 where Id in @Ids";
                    return TraceExecFunc<bool>(() => Conn.Execute(sql, new { Ids = arrIds }) >= 0, sql);
                }
                else
                {
                    var sql = $"Delete {this.GetTableName()} where Id in @Ids";
                    return TraceExecFunc<bool>(() => Conn.Execute(sql, new { Ids = arrIds }) >= 0, sql);
                }
            }
            else
            {
                return false;
            }
        }
        public bool DeleteAll(string conditions, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                return TraceExecFunc<bool>(() => Conn.DeleteList<T>(conditions, transaction, null) >= 0, conditions);
            }
            else
            {
                return false;
            }
        }
        public bool DeleteAll(object whereConditions, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                return TraceExecFunc<bool>(() => Conn.DeleteList<T>(whereConditions, transaction) >= 0, GetEntityDesc(whereConditions));
            }
            else
            {
                return false;
            }
        }
        public bool RecordCount(object whereConditions, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                return Conn.RecordCount<T>(whereConditions, transaction) >= 0;
            }
            else
            {
                return false;
            }
        }
        public bool RecordCount(string conditions, IDbTransaction transaction = null)
        {
            if (IsConnection())
            {
                return Conn.RecordCount<T>(conditions, transaction, null) >= 0;
            }
            else
            {
                return false;
            }
        }
        #endregion

        protected string GetTableName()
        {
            string tableName;
            var ta = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();
            if (ta != null)
            {
                var tbAttr = ta as TableAttribute;
                if (tbAttr != null && !string.IsNullOrEmpty(tbAttr.Name))
                    tableName = tbAttr.Name;
                else
                    tableName = typeof(T).Name;
            }
            else
            {
                tableName = typeof(T).Name;
            }

            return tableName;
        }

        #region 分页操作


        /// <summary>
        /// 需要添加到Order by 后面才生效
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="rows">每页记录数</param>
        /// <returns></returns>
        public static string GetPageSql(int page = 0, int rows = 0)
        {
            page = page - 1;
            if (page < 0) page = 0;
            if (rows < 0) rows = 0;
            if (page == 0 && rows == 0)
                return "";

            return $" OFFSET {page * rows} ROWS FETCH NEXT {rows} ROWS ONLY";
        }



        /// <summary>
        /// 分页，条件由SqlBuilder传递过来
        /// 因为使用了查询模板，因此需要 使用Select，where，OrderBy三个方法生成builder
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public PagedListData<IEnumerable<T>> Query(SqlBuilder builder, PagingInfo page)
        {
            if (IsConnection())
            {
                int noffset = page.PageIndex * page.PageSize;
                string tableName = GetTableName();
                var countTemplate = builder.AddTemplate($@"select count(*) from {tableName} /**where**/");
                var selectTemplate = builder.AddTemplate($@"select /**select**/ FROM {tableName} /**where**/ /**orderby**/ OFFSET @Offset ROWS FETCH NEXT @Limit ROWS ONLY ",
                    new
                    {
                        Limit = page.PageSize,
                        Offset = noffset
                    });

                return TraceExecFunc<PagedListData<IEnumerable<T>>>(
                    () =>
                    {
                        //DynamicParameters d = new DynamicParameters();
                        //d.AddDynamicParams(new {tablename = "fdfds"});
                        var count = Conn.Query<int>(countTemplate.RawSql, selectTemplate.Parameters).Single();
                        var rows = Conn.Query<T>(selectTemplate.RawSql, selectTemplate.Parameters);
                        PagedListData<IEnumerable<T>> pData = new PagedListData<IEnumerable<T>>();
                        page.TotalCount = count;
                        pData.PagingInfo = page;
                        pData.PagingData = rows;
                        return pData;
                    }, $"{countTemplate.RawSql};{selectTemplate.RawSql}; ");
            }
            else
            {
                page.TotalCount = 0;
                return new PagedListData<IEnumerable<T>>()
                {
                    PagingInfo = page
                };
            }
        }

        /// <summary>
        /// 分页查询，传入参数
        /// </summary>
        /// <param name="obj">分页条件</param>
        /// <param name="info">查询条件</param>
        /// <returns></returns>
        public PagedListData<List<T>> PagedListQuery(PageListModel obj, PageSearch info)
        {
            if (IsConnection())
            {
                var sql = $@"DECLARE @Sql NVARCHAR(MAX);
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
                   WITH  Select_List  AS
                   (
					   SELECT  ROW_NUMBER() OVER ( ' + @Order + ' ) RowNumber,
                        {obj.WithColumn}
                        FROM {GetTableName()}
						WHERE {obj.WithWhere} ' + @Where + '
                  )
                  SELECT
			          A.* ";
                sql += !string.IsNullOrWhiteSpace(obj.LeftColumn) ? $@",{obj.LeftColumn}" : "";

                sql += $@" FROM Select_List A 
                  {obj.LeftJoin}
                  WHERE (RowNumber BETWEEN ( @PageSize * ( @CurrentPageIndex - 1 ) + 1 )  AND  @PageSize * @CurrentPageIndex )
          
                 SELECT @Count = COUNT(1) FROM {GetTableName()} WHERE {obj.WithWhere} ' + @Where;              
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
                       @Count OUTPUT; ";

                var model = new PagedListData<List<T>>();
                var dp = new DynamicParameters();
                dp.Add("@CurrentPageIndex", info.PageIndex);
                dp.Add("@PageSize", info.PageSize);
                dp.Add("@Where", info.Where);
                dp.Add("@OrderBy", info.OrderBy);
                dp.Add("@Count", 0, DbType.Int32, ParameterDirection.Output);
                var data = this.Query(sql, dp);
                var pageInfo = new PagingInfo(info.PageSize, info.PageIndex);
                if (data != null)
                {
                    model.PagingData = data.ToList();
                    pageInfo.TotalCount = dp.Get<int>("@Count");
                    model.PagingInfo = pageInfo;
                }
                else
                {
                    model.PagingData = new List<T>();
                    pageInfo.TotalCount = 0;
                    model.PagingInfo = pageInfo;
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="page"></param>
        /// <param name="conditions">eg:where a=a </param>
        /// <param name="orderby">eg:id,name desc</param>
        /// <returns></returns>
        public PagedListData<IEnumerable<T>> Query(PagingInfo page, string conditions, string orderby)
        {
            if (IsConnection())
            {
                return TraceExecFunc<PagedListData<IEnumerable<T>>>(() =>
                {
                    var count = Conn.RecordCount<T>(conditions);
                    var rows = Conn.GetListPaged<T>(page.PageIndex, page.PageSize, conditions, orderby);
                    PagedListData<IEnumerable<T>> pData = new PagedListData<IEnumerable<T>>();
                    page.TotalCount = count;
                    pData.PagingInfo = page;
                    pData.PagingData = rows;
                    return pData;
                }, GetEntityDesc(new { start = page.PageIndex, size = page.PageSize, conditions = conditions, orderby = orderby }));
            }
            else
            {
                page.TotalCount = 0;
                return new PagedListData<IEnumerable<T>>()
                {
                    PagingInfo = page
                };
            }
        }
        #endregion

        #region 扩展对Commond以及自定义语句的支持
        public int Execute(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null)
        {
            return TraceExecFunc(
                () => this.Conn.Execute(sql, param, transaction, commandTimeout, commandType), sql);
        }

        public TT ExecuteScalar<TT>(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            int? commandTimeout = null,
            CommandType? commandType = null)
        {
            return TraceExecFunc(
                () => this.Conn.ExecuteScalar<TT>(sql, param, transaction, commandTimeout, commandType), sql);

        }

        public IEnumerable<T> Query(
            string sql,
            object param = null,
            IDbTransaction transaction = null,
            bool buffered = true,
            int? commandTimeout = null,
            CommandType? commandType = null)
        {
            return TraceExecFunc(
                () => this.Conn.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType), sql);
        }

        #endregion
    }

    public class PageListModel
    {
        /// <summary>
        /// with 块内的查询字段
        /// </summary>
        public string WithColumn { get; set; }
        /// <summary>
        /// 主表查询的条件
        /// </summary>
        public string WithWhere { get; set; }
        /// <summary>
        /// 联查对应的联查字段
        /// </summary>
        public string LeftColumn { get; set; }
        /// <summary>
        /// 联查的表 As
        /// </summary>
        public string LeftJoin { get; set; }
    }
}
