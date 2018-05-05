using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EB.ISCS.FrameworkEntity.SystemEntity;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    interface ISysUser : IService
    {
        int Insert(SysUser user);

        bool Update(SysUser user);

        bool DelUser(int? id);

        List<SysUser> GetList();

        SysUser Login(string loginName, string password);

        SysUser SuperLogin(string loginName, string password);
    }
}
