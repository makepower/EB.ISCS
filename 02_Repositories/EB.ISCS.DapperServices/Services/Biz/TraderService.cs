using EB.ISCS.Common.DataModel;
using EB.ISCS.DapperServices.Repository.Biz;
using EB.ISCS.FrameworkEntity.Biz;
using System.Collections.Generic;
using System.Data;

namespace EB.ISCS.DapperServices.Services.Biz
{
    public partial class TraderService : Service
    {
        #region 构造 
        private TraderRepository _traderRepository;
        public TraderService()  : this(string.Empty)
        {

        }

        public TraderService(string connString) : base(connString)
        {
            this._traderRepository = new TraderRepository(Provider, OInfo);
        }

        public TraderService(Service service) : base(service)
        {
            this._traderRepository = new TraderRepository(Provider, OInfo);
        }
        #endregion

        /// <summary>
        ///  新增
        /// </summary>
        public int Add(TraderInfo model, IDbTransaction transaction = null)
        {
            return _traderRepository.Insert(model, transaction);
        }

        /// <summary>
        ///  根据Id获取模型
        /// </summary>
        public TraderInfo GetModelById(int id)
        {
            return _traderRepository.Get(id);
        }

        /// <summary>
        ///  删除GoodInfo，并记录删除人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(DeleteModel model, IDbTransaction transaction = null)
        {
            return this._traderRepository.Delete(model, transaction);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(TraderInfo model, IDbTransaction transaction = null)
        {
            return _traderRepository.Update(model, transaction);
        }

        /// <summary>
        /// 获取所有的Maticsoft.Model.GoodInfo信息
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TraderInfo> GetAllList()
        {
            return this._traderRepository.GetAllList();
        }
    }
}
