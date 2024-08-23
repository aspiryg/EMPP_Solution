using DataModels.ApplicationModels;

namespace EMPP_Server.Infrastructure.Repositories.WorkHistoryRepo
{
    public interface IWorkHistoryRepo
    {
        Task<WorkHistoryDTO> GetWorkHistoryByIdAsync(int id);
        // Get Work Histories by Application Id
        Task<IEnumerable<WorkHistoryDTO>> GetWorkHistoriesByAppIdAsync(int appId);
        // Add Work History
        Task<WorkHistoryDTO> AddWorkHistoryAsync(WorkHistoryDTO workHistory);
        // Update Work History
        Task<WorkHistoryDTO> UpdateWorkHistoryAsync(WorkHistoryDTO workHistory);
        // Delete Work History
        Task<bool> DeleteWorkHistoryAsync(int id);
    }
}
