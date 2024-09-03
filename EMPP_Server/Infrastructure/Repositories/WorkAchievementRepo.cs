using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;
using EMPP_Server.Data;
using EMPP_Server.Infrastructure.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;

namespace EMPP_Server.Infrastructure.Repositories
{
    public class WorkAchievementRepo : IWorkAchievement
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public WorkAchievementRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkAchievementDTO> AddAsync(WorkAchievementDTO workAchievementDTO)
        {
            var workAchievement = _mapper.Map<WorkAchievement>(workAchievementDTO);
            await _context.WorkAchievements.AddAsync(workAchievement);
            await _context.SaveChangesAsync();
            return _mapper.Map<WorkAchievementDTO>(workAchievement);
        }

        public async Task<WorkAchievementDTO> DeleteAsync(int id)
        {
            var workAchievement = await _context.WorkAchievements.FindAsync(id);
            if (workAchievement == null)
            {
                return new WorkAchievementDTO();
            }

            _context.WorkAchievements.Remove(workAchievement);
            await _context.SaveChangesAsync();
            return _mapper.Map<WorkAchievementDTO>(workAchievement);
        }

        public async Task<IEnumerable<WorkAchievementDTO>> GetAllAsync()
        {
            var workAchievements = await _context.WorkAchievements.ToListAsync();
            return _mapper.Map<IEnumerable<WorkAchievementDTO>>(workAchievements);
        }

        public async Task<WorkAchievementDTO> GetAsync(int id)
        {
            var workAchievement = await _context.WorkAchievements.FindAsync(id);
            if(workAchievement == null)
            {
                return new WorkAchievementDTO();
            }
            return _mapper.Map<WorkAchievementDTO>(workAchievement);
        }

        public async Task<IEnumerable<WorkAchievementDTO>> GetByWorkHistoryIdAsync(int workHistoryId)
        {
            var workAchievements = await _context.WorkAchievements.Where(x => x.WorkHistoryId == workHistoryId).ToListAsync();
            if (workAchievements.Count > 0)
            {
                return _mapper.Map<IEnumerable<WorkAchievementDTO>>(workAchievements);
            }
            else
            {
                return [];
            }
        }

        public async Task<WorkAchievementDTO> UpdateAsync(WorkAchievementDTO workAchievementDTO)
        {
            var workAchievement = _context.WorkAchievements.Find(workAchievementDTO.Id);
            if (workAchievement == null)
            {
                return new WorkAchievementDTO();
            }
            _mapper.Map(workAchievementDTO, workAchievement);
            workAchievement.UpdatedDate = DateTime.Now;
            var achievementUpdated = _context.WorkAchievements.Update(workAchievement);
            await _context.SaveChangesAsync();
            return _mapper.Map<WorkAchievementDTO>(achievementUpdated.Entity);
        }
    }
}
