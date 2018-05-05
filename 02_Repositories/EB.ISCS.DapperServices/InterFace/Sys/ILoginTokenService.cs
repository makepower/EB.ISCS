using EB.ISCS.Common.DataModel;

namespace EB.ISCS.DapperServices.InterFace.Sys
{
    public interface ILoginTokenService : IService
    {
        int AddLoginToken(SysLoginTokenModel vodel);
        bool UpdateLoginToken(SysLoginTokenModel vodel);
        SysLoginTokenModel GetLoginTokenById(int id);

    }
}
