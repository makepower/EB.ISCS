using Dapper;
using EB.ISCS.DapperServices.Base;
using EB.ISCS.FrameworkEntity;
using System.Collections.Generic;
using System.Linq;

namespace EB.ISCS.DapperServices.Repository
{
    public class DataSyncRecordRepository : BaseRepository<DataSyncRecord>
    {
        #region 构造 
        public DataSyncRecordRepository(SqlServerProvider provider, OperateInfo oInfo = null) : base(provider, oInfo)
        {
        }
        #endregion

        #region Costom Function 

        /// <summary>
        /// 获取所有的Maticsoft.Model.DataSyncRecord
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataSyncRecord> GetAllList()
        {
            var sql = @" select *   FROM DataSyncRecord ";
            return TraceExecFunc(() => this.Conn.Query<DataSyncRecord>(sql));
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.DataSyncRecord
        /// </summary>
        /// <returns></returns>
        public DataSyncRecord GetRecordByShipId(int shipId)
        {
            var sql = $@" select * from DataSyncRecord where ShopId ={shipId}";
            return TraceExecFunc(() => this.Conn.Query<DataSyncRecord>(sql))?.FirstOrDefault();
        }

        #endregion
    }
}
