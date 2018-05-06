using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.InterFace;
using EB.ISCS.DapperServices.Services;
using Maticsoft.Model;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.Repository
{

    /// <summary>
    ///投诉信息表 ：服务类
    /// </summary>		
    public partial class ComplaintInfoService : Service, IComplaintInfoService
	{
   		
   		#region 构造 
   		private ComplaintInfoRepository _ComplaintInfoRepository;
        public ComplaintInfoService()  : this(string.Empty)
        {

        }

        public ComplaintInfoService(string connString) : base(connString)
        {
            this._ComplaintInfoRepository = new ComplaintInfoRepository(Provider,  OInfo);
        }

        public ComplaintInfoService(Service service) : base(service)
        {
            this._ComplaintInfoRepository = new ComplaintInfoRepository(Provider, OInfo);
        }
        #endregion
        
		/// <summary>
		///  新增
		/// </summary>
        public int Add(ComplaintInfo model,IDbTransaction transaction = null)
        {
            return _ComplaintInfoRepository.Insert(model,transaction);
        }
        
        /// <summary>
		///  根据Id获取模型
		/// </summary>
        public ComplaintInfo GetModelById(int id)
        {
            return _ComplaintInfoRepository.Get(id);
        }
        
        /// <summary>
        ///  删除ComplaintInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model,IDbTransaction transaction = null)
        {
            return this._ComplaintInfoRepository.Delete(model,transaction);
        }
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ComplaintInfo model,IDbTransaction transaction = null)
		{
            return  _ComplaintInfoRepository.Update(model,transaction);
		}
		
		/// <summary>
        /// 获取所有的Maticsoft.Model.ComplaintInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ComplaintInfo> GetAllList()
        {
            return this._ComplaintInfoRepository.GetAllList();
        }
	}
}