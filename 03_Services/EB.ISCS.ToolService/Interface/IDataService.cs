using EB.ISCS.Common.Enum;

namespace EB.ISCS.ToolService
{
    interface IDataService:IService
    {
        ApiPlatform Platform { get; }
        void SyncData();
    }
}
