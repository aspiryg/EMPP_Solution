using DataModels.ApplicationModels;

namespace EMPP_Server.Infrastructure.Repositories.IRepo
{
    public interface IInitialStage
    {
        Task<InitialStageDTO> CreateApplication(InitialStageDTO initialStageDTO);
        Task<InitialStageDTO> UpdateApplication(InitialStageDTO initialStageDTO);
        Task<InitialStageDTO> GetApplicationById(int id);
        Task<IEnumerable<InitialStageDTO>> GetAllApplication();
        Task<InitialStageDTO> DeleteApplication(int id);

        // Get Application by User Id
        Task<InitialStageDTO> GetApplicationByUserId(string userId, int id);
        Task<IEnumerable<InitialStageDTO>> GetAllApplicationsByUserId(string userId);

        // Get Last Application
        Task<InitialStageDTO> GetLastApplication();
    }
}
