using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    interface ISysLoginTokenService
    {
        #region 基本方法(新增、更新、删除、查询) 

        /// <summary>
        ///  新增SysLoginToken
        /// </summary>
        /// <param name="model">SysLoginToken实体</param>
        /// <returns>bool</returns>
        bool Add(SysLoginToken model);

        #endregion
    }
}
