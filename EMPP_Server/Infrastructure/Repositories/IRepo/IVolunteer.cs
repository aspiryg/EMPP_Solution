using DataModels.ApplicationModels;

namespace EMPP_Server.Infrastructure.Repositories.IRepo
{
    public interface IVolunteer
    {
        Task<VolunteerDTO> CreateAsync(VolunteerDTO volunteerDTO);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<VolunteerDTO>> GetAllAsync();
        Task<VolunteerDTO> GetByUserIdAsync(string userId);
        Task<VolunteerDTO> GetByIdAsync(int id);
        Task<VolunteerDTO> UpdateAsync(VolunteerDTO volunteerDTO);
    }
}
