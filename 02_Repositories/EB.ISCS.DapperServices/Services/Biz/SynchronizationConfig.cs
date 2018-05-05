using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///SynchronizationConfig ：服务类
    /// </summary>		
    public partial class SynchronizationConfigService : Service, ISynchronizationConfigService
	{
   		
   		#region 构造 
   		private SynchronizationConfigRepository _SynchronizationConfigRepository;
        public SynchronizationConfigService()  : this(string.Empty)
        {

        }

        public SynchronizationConfigService(string connString) : base(connString)
        {
            this._SynchronizationConfigRepository = new SynchronizationConfigRepository(Provider,  OInfo);
        }

        public SynchronizationConfigService(Service service) : base(service)
        {
            this._SynchronizationConfigRepository = new SynchronizationConfigRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(SynchronizationConfig model,IDbTransaction transaction = null)
        {
            return _SynchronizationConfigRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public SynchronizationConfig GetModelById(int id)
        {
            return _SynchronizationConfigRepository.Get(id);
        }
        
        /// <summary>
        ///  删除SynchronizationConfig，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._SynchronizationConfigRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(SynchronizationConfig model,IDbTransaction transaction = null)
		{
            return  _SynchronizationConfigRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.SynchronizationConfig信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SynchronizationConfig> GetAllList()
        {
            return this._SynchronizationConfigRepository.GetAllList();
        }
	}
}