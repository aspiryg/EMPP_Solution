using DataModels.ApplicationModels;

namespace EMPP_Server.Infrastructure.Repositories.IRepo
{
    public interface IWorkAchievement
    {
        Task<WorkAchievementDTO> AddAsync(WorkAchievementDTO workAchievementDTO);
        Task<WorkAchievementDTO> DeleteAsync(int id);
        Task<WorkAchievementDTO> GetAsync(int id);
        Task<IEnumerable<WorkAchievementDTO>> GetAllAsync();
        Task<IEnumerable<WorkAchievementDTO>> GetByWorkHistoryIdAsync(int workHistoryId);
        Task<WorkAchievementDTO> UpdateAsync(WorkAchievementDTO workAchievementDTO);
    }
}
