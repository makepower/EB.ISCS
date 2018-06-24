using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using EB.ISCS.Common.Models;

namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///首页监控指标信息 ：服务类
    /// </summary>		
    public partial class MonitorIndicatorRecordService : Service, IMonitorIndicatorRecordService
    {

        #region 构造 
        private MonitorIndicatorRecordRepository _monitorIndicatorRecordRepository;
        private MonitorIndicatorRepository _monitorIndicatorRepository;
        private MonitorIndicatorHistoryRecordRepository _monitorIndicatorHistoryRecordRepository;

        public MonitorIndicatorRecordService() : this(string.Empty)
        {

        }

        public MonitorIndicatorRecordService(string connString) : base(connString)
        {
            this._monitorIndicatorRecordRepository = new MonitorIndicatorRecordRepository(Provider, OInfo);
            _monitorIndicatorRepository = new MonitorIndicatorRepository(Provider, OInfo);
            _monitorIndicatorHistoryRecordRepository = new MonitorIndicatorHistoryRecordRepository(Provider, OInfo);
        }

        public MonitorIndicatorRecordService(Service service) : base(service)
        {
            this._monitorIndicatorRecordRepository = new MonitorIndicatorRecordRepository(Provider, OInfo);
            _monitorIndicatorRepository = new MonitorIndicatorRepository(Provider, OInfo);
            _monitorIndicatorHistoryRecordRepository = new MonitorIndicatorHistoryRecordRepository(Provider, OInfo);
        }
        #endregion

        /// <summary>
        ///  新增
        /// </summary>
        public int Add(MonitorIndicatorRecord model, IDbTransaction transaction = null)
        {
            return _monitorIndicatorRecordRepository.Insert(model, transaction);
        }

        /// <summary>
        ///  根据Id获取模型
        /// </summary>
        public MonitorIndicatorRecord GetModelById(int id)
        {
            return _monitorIndicatorRecordRepository.Get(id);
        }

        public bool RemoveRecord(int id)
        {
            return _monitorIndicatorRecordRepository.RemoveRecord(id);
        }

        /// <summary>
        /// 添加历史记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int RemoveToHistory(IDbTransaction transaction = null, params MonitorIndicatorRecord[] modelList)
        {
            foreach (var model in modelList)
            {
                var recordId = model.Id;
                model.Id = 0;
                _monitorIndicatorHistoryRecordRepository.Insert(model.ToHistory(), transaction);
                _monitorIndicatorRecordRepository.RemoveRecord(recordId, transaction);
            }
            return modelList?.Length ?? 0;

        }

        /// <summary>
        ///  删除GoodMonitorTopN，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model, IDbTransaction transaction = null)
        {
            return this._monitorIndicatorRecordRepository.Delete(model, transaction);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MonitorIndicatorRecord model, IDbTransaction transaction = null)
        {
            return _monitorIndicatorRecordRepository.Update(model, transaction);
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.GoodMonitorTopN信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MonitorIndicatorRecord> GetAllList()
        {
            return this._monitorIndicatorRecordRepository.GetAllList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MonitorIndicatorRecord> QueryLastRecord(int userId, string code, bool isStatisRecord = true)
        {
            var indicator = _monitorIndicatorRepository.GetByCode(code);
            var querySQL = $" and UserId={userId} and IndicatorId={indicator.Id} and IsStatisRecord ={isStatisRecord}";
            return this._monitorIndicatorRecordRepository.GetAllList(querySQL)?.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<MonitorIndicatorRecord> QueryRecordByShipIds(int[] ids)
        {
            return _monitorIndicatorRecordRepository.GetAllList($" and ShipInfoId in({ string.Join(",", ids)})")?.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<MonitorIndicatorRecord> QueryMonitorIndicator(QueryRecordModel query)
        {
            var filterSql = $" and ShipInfoId ={ query.ShipId} and UserId={query.UserId} and SyncSerialNumber={query.SeriesNum}";
            if (query.IndicatorId > 0)
            {
                filterSql += $" and query.IndicatorId={query.IndicatorId}";
            }
            var cur = _monitorIndicatorRecordRepository.GetAllList(filterSql)?.ToList();
            if (cur == null || !cur.Any())
            {
                cur = new List<MonitorIndicatorRecord>();
                _monitorIndicatorHistoryRecordRepository.GetAllList(filterSql)?.ToList().ForEach(d =>
                {
                    cur.Add(d.ToCurrent());
                });
            }
            return cur;
        }

    }
}