using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///店铺信息 ：服务类
    /// </summary>		
    public partial class ShipInfoService : Service, IShipInfoService
	{
   		
   		#region 构造 
   		private ShipInfoRepository _ShipInfoRepository;
        public ShipInfoService()  : this(string.Empty)
        {

        }

        public ShipInfoService(string connString) : base(connString)
        {
            this._ShipInfoRepository = new ShipInfoRepository(Provider,  OInfo);
        }

        public ShipInfoService(Service service) : base(service)
        {
            this._ShipInfoRepository = new ShipInfoRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(ShipInfo model,IDbTransaction transaction = null)
        {
            return _ShipInfoRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public ShipInfo GetModelById(int id)
        {
            return _ShipInfoRepository.Get(id);
        }
        
        /// <summary>
        ///  删除ShipInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._ShipInfoRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ShipInfo model,IDbTransaction transaction = null)
		{
            return  _ShipInfoRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.ShipInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ShipInfo> GetAllList()
        {
            return this._ShipInfoRepository.GetAllList();
        }
	}
}