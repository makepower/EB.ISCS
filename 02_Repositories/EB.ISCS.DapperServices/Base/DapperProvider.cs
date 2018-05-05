using System;
using System.Data;
using System.Data.SqlClient;

namespace EB.ISCS.DapperServices.Base
{
    /// <summary>
    /// 数据库服务提供商，默认提供sqlserver引擎链接服务
    /// </summary>
    public static class DapperProvider
    {

        public static SqlServerProvider GetProvider(string connString)
        {
            return new SqlServerProvider(connString);
        }

        /// <summary>
        /// 得到指定配置数据库的连接字符串
        /// </summary>
        /// <returns></returns>
        public static string GetConnString()
        {
            return "Data Source=localhost;Initial Catalog=QS_DEV;Persist Security Info=True;User ID=sa;Password=p@ssw0rd;";
        }
    }



    /// <summary>
    /// MSSqlServer 数据连接服务
    /// 提供数据库引擎的打开和关闭以及资源池化支持
    /// </summary>
    public class SqlServerProvider : IDisposable
    {
        private readonly SqlConnection _conn;
        /// <summary>
        /// 构造连接管理器
        /// </summary>
        /// <param name="connString">Data Source=xxx;Initial Catalog=Express;User ID=sa;Password=123</param>
        public SqlServerProvider(string connString)
        {
            _conn = new SqlConnection(connString);
            ////手动打开的话会保持长连接，否则每次查询之后会关闭连接
            _conn.Open();
        }

        public void Close()
        {
            if (_conn != null && _conn.State != ConnectionState.Closed && _conn.State != ConnectionState.Broken)
            {
                _conn.Close();
            }
        }
        public SqlConnection Conn => _conn;

        public SqlConnection GetConn()
        {
            return _conn;
        }
        public void Dispose()
        {
            Close();
            Conn?.Dispose();
        }
    }
}
