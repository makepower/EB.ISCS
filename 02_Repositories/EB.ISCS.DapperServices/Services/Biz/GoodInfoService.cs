using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;
namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///商品信息 ：服务类
    /// </summary>		
    public partial class GoodInfoService : Service, IGoodInfoService
	{
   		
   		#region 构造 
   		private GoodInfoRepository _GoodInfoRepository;
        public GoodInfoService()  : this(string.Empty)
        {

        }

        public GoodInfoService(string connString) : base(connString)
        {
            this._GoodInfoRepository = new GoodInfoRepository(Provider,  OInfo);
        }

        public GoodInfoService(Service service) : base(service)
        {
            this._GoodInfoRepository = new GoodInfoRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(GoodInfo model,IDbTransaction transaction = null)
        {
            return _GoodInfoRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public GoodInfo GetModelById(int id)
        {
            return _GoodInfoRepository.Get(id);
        }
        
        /// <summary>
        ///  删除GoodInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._GoodInfoRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(GoodInfo model,IDbTransaction transaction = null)
		{
            return  _GoodInfoRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.GoodInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GoodInfo> GetAllList()
        {
            return this._GoodInfoRepository.GetAllList();
        }
	}
}