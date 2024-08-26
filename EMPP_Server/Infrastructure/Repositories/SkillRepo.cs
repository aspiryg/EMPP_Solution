using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;
using EMPP_Server.Data;
using EMPP_Server.Infrastructure.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;

namespace EMPP_Server.Infrastructure.Repositories
{
    public class SkillRepo : ISkillRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SkillRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<SkillDTO> Create(SkillDTO skillDTO)
        {
            var skillModel = _mapper.Map<SkillDTO, Skill>(skillDTO);
            skillModel.CreatedDate = DateTime.Now;
            var result = await _context.Skills.AddAsync(skillModel);
            await _context.SaveChangesAsync();
            return _mapper.Map<Skill, SkillDTO>(result.Entity);
        }

        public async Task<bool> Delete(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return false;
            }
            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SkillDTO>> GetAll()
        {
            var skills = await _context.Skills.ToListAsync();
            if (skills == null)
            {
                return [];
            }
            return _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDTO>>(skills);
        }

        public async Task<IEnumerable<SkillDTO>> GetAllByWorkIdAsync(int workId)
        {
            var skills = await _context.Skills.Where(x => x.WorkHistoryId == workId).ToListAsync();
            if (skills == null)
            {
                return [];
            }
            return _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillDTO>>(skills);
        }

        public async Task<SkillDTO> GetByGuid(Guid id)
        {
            var skill = await _context.Skills.FirstOrDefaultAsync(x => x.Guid == id);
            if (skill == null)
            {
                return new SkillDTO();
            }
            return _mapper.Map<Skill, SkillDTO>(skill);
        }

        public async Task<SkillDTO> GetById(int id)
        {
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return new SkillDTO();
            }
            return _mapper.Map<Skill, SkillDTO>(skill);
        }

        public async Task<SkillDTO> Update(SkillDTO skillDTO)
        {
            var skillModel = await _context.Skills.FindAsync(skillDTO.Id);
            if (skillModel != null)
            {
                skillModel.SkillName = skillDTO.SkillName;
                skillModel.SkillLevel = skillDTO.SkillLevel;
                skillModel.UpdatedDate = DateTime.Now;
                var result = _context.Skills.Update(skillModel);
                await _context.SaveChangesAsync();
                return _mapper.Map<Skill, SkillDTO>(result.Entity);
            }
            return new SkillDTO();
        }
    }
}
