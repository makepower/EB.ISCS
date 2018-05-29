using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model.ISSC;
using EB.ISCS.Common.DataModel;

namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
	 	///交易信息 ：服务类
		/// </summary>		
	public partial class TradesService : Service, ITradesService
	{
   		
   		#region 构造 
   		private TradesRepository _TradesRepository;
        public TradesService()  : this(string.Empty)
        {

        }

        public TradesService(string connString) : base(connString)
        {
            this._TradesRepository = new TradesRepository(Provider,  OInfo);
        }

        public TradesService(Service service) : base(service)
        {
            this._TradesRepository = new TradesRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(Trades model,IDbTransaction transaction = null)
        {
            return _TradesRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public Trades GetModelById(int id)
        {
            return _TradesRepository.Get(id);
        }
        
        /// <summary>
        ///  删除Trades，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._TradesRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Trades model,IDbTransaction transaction = null)
		{
            return  _TradesRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.Trades信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Trades> GetAllList()
        {
            return this._TradesRepository.GetAllList();
        }
	}
}