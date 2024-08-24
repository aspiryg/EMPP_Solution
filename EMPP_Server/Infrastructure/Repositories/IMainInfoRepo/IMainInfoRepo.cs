using DataModels.ApplicationModels;

namespace EMPP_Server.Infrastructure.Repositories.IMainInfoRepo
{
    public interface IMainInfoRepo
    {
        Task<MainInfoDTO> GetMainInfoById(int id);
        Task<MainInfoDTO> GetMainInfoByGuid(Guid guid);
        Task<MainInfoDTO> GetMainInfoByUserId(string userId);
        Task<MainInfoDTO> AddMainInfo(MainInfoDTO mainInfo);
        Task<MainInfoDTO> UpdateMainInfo(MainInfoDTO mainInfo);
        Task<MainInfoDTO> DeleteMainInfo(int id);
        Task<IEnumerable<MainInfoDTO>> GetAll();
        // Search
        Task<IEnumerable<MainInfoDTO>> SearchMainInfo(string search);

        // Get Last Application Id
        Task<int> GetLastApplicationId();

        // Get Main by application Id
        Task<MainInfoDTO> GetMainInfoByAppId(int appId);
    }
}
