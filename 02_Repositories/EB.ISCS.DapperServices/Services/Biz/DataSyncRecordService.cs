using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Repository;
using EB.ISCS.FrameworkEntity;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.Services
{
    public class DataSyncRecordService : Service, IDataSyncRecordService
    {
        #region 构造 
        private DataSyncRecordRepository _ComplaintInfoRepository;
        public DataSyncRecordService() : this(string.Empty)
        {

        }

        public DataSyncRecordService(string connString) : base(connString)
        {
            this._ComplaintInfoRepository = new DataSyncRecordRepository(Provider, OInfo);
        }

        public DataSyncRecordService(Service service) : base(service)
        {
            this._ComplaintInfoRepository = new DataSyncRecordRepository(Provider, OInfo);
        }
        #endregion

        /// <summary>
        ///  新增
        /// </summary>
        public int Add(DataSyncRecord model, IDbTransaction transaction = null)
        {
            return _ComplaintInfoRepository.Insert(model, transaction);
        }

        /// <summary>
        ///  根据Id获取模型
        /// </summary>
        public DataSyncRecord GetModelById(int id)
        {
            return _ComplaintInfoRepository.Get(id);
        }

        /// <summary>
        ///  删除ComplaintInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model, IDbTransaction transaction = null)
        {
            return this._ComplaintInfoRepository.Delete(model.Id, transaction);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DataSyncRecord model, IDbTransaction transaction = null)
        {
            return _ComplaintInfoRepository.Update(model, transaction);
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.ComplaintInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DataSyncRecord> GetAllList()
        {
            return this._ComplaintInfoRepository.GetAllList();
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.ComplaintInfo信息
        /// </summary>
        /// <returns></returns>
        public DataSyncRecord GetRecordByShipId(int shipid)
        {
            return this._ComplaintInfoRepository.GetRecordByShipId(shipid);
        }
    }
}
