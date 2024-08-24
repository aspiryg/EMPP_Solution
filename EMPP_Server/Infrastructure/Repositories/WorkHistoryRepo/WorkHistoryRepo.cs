using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;
using EMPP_Server.Data;
using Microsoft.EntityFrameworkCore;

namespace EMPP_Server.Infrastructure.Repositories.WorkHistoryRepo
{
    public class WorkHistoryRepo : IWorkHistoryRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public WorkHistoryRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<WorkHistoryDTO> AddWorkHistoryAsync(WorkHistoryDTO workHistory)
        {
            var workHistoryModel = _mapper.Map<WorkHistoryDTO,WorkHistory>(workHistory);
            var result = await _context.WorkHistory.AddAsync(workHistoryModel);
            await _context.SaveChangesAsync();
            return _mapper.Map<WorkHistory, WorkHistoryDTO>(result.Entity);
        }

        public async Task<bool> DeleteWorkHistoryAsync(int id)
        {
            var workHistory = await _context.WorkHistory.FindAsync(id);
            if (workHistory == null)
            {
                return false;
            }
            _context.WorkHistory.Remove(workHistory);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<WorkHistoryDTO>> GetWorkHistoriesByAppIdAsync(int appId)
        {
            var workHistories = await _context.WorkHistory.Where(x => x.AppId == appId).ToListAsync();
            if (workHistories == null)
            {
                return [];
            }
            return _mapper.Map<IEnumerable<WorkHistory>, IEnumerable<WorkHistoryDTO>>(workHistories);
        }

        public async Task<WorkHistoryDTO> GetWorkHistoryByIdAsync(int id)
        {
            var workHistory = await _context.WorkHistory.FindAsync(id);
            if (workHistory == null)
            {
                return new WorkHistoryDTO();
            }
            return _mapper.Map<WorkHistory, WorkHistoryDTO>(workHistory);
        }

        public async Task<WorkHistoryDTO> UpdateWorkHistoryAsync(WorkHistoryDTO workHistory)
        {
            var workHistoryModel = await _context.WorkHistory.FindAsync(workHistory.Id);
            if (workHistoryModel == null)
            {
                return new WorkHistoryDTO();
            }

            _mapper.Map(workHistory, workHistoryModel);
            workHistoryModel.UpdatedDate = DateTime.Now;
            var result = _context.WorkHistory.Update(workHistoryModel);
            await _context.SaveChangesAsync();
            return _mapper.Map<WorkHistory, WorkHistoryDTO>(result.Entity);
        }
    }
}
