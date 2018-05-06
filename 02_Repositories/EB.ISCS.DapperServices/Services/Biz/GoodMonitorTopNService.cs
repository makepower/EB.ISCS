using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///首页监控指标信息 ：服务类
    /// </summary>		
    public partial class GoodMonitorTopNService : Service, IGoodMonitorTopNService
	{
   		
   		#region 构造 
   		private GoodMonitorTopNRepository _GoodMonitorTopNRepository;
        public GoodMonitorTopNService()  : this(string.Empty)
        {

        }

        public GoodMonitorTopNService(string connString) : base(connString)
        {
            this._GoodMonitorTopNRepository = new GoodMonitorTopNRepository(Provider,  OInfo);
        }

        public GoodMonitorTopNService(Service service) : base(service)
        {
            this._GoodMonitorTopNRepository = new GoodMonitorTopNRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(GoodMonitorTopN model,IDbTransaction transaction = null)
        {
            return _GoodMonitorTopNRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public GoodMonitorTopN GetModelById(int id)
        {
            return _GoodMonitorTopNRepository.Get(id);
        }
        
        /// <summary>
        ///  删除GoodMonitorTopN，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._GoodMonitorTopNRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoodMonitorTopN model,IDbTransaction transaction = null)
		{
            return  _GoodMonitorTopNRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.GoodMonitorTopN信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GoodMonitorTopN> GetAllList()
        {
            return this._GoodMonitorTopNRepository.GetAllList();
        }

        /// <summary>
        /// 获取最近30天的汇总信息
        /// 统计截至时间默认为前一天
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GoodMonitorTopN> GetMonitorStstisForThirtyDays(string shipIds)
        {
            return this._GoodMonitorTopNRepository.GetMonitorStstisForThirtyDays(shipIds);
        }

        
    }
}