using DataModels.ApplicationModels;

namespace EMPP_Server.Infrastructure.Repositories.IRepo
{
    public interface ISkillRepo
    {
        Task<IEnumerable<SkillDTO>> GetAll();
        Task<SkillDTO> GetByGuid(Guid id);
        Task<SkillDTO> GetById(int id);
        Task<SkillDTO> Create(SkillDTO skillDTO);
        Task<SkillDTO> Update(SkillDTO skillDTO);
        Task<bool> Delete(int id);

        Task<IEnumerable<SkillDTO>> GetAllByWorkIdAsync(int workId);
    }
}
