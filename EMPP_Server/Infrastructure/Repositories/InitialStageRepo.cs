using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;
using EMPP_Server.Data;
using EMPP_Server.Infrastructure.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;

namespace EMPP_Server.Infrastructure.Repositories
{
    public class InitialStageRepo : IInitialStage
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InitialStageRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<InitialStageDTO> CreateApplication(InitialStageDTO initialStageDTO)
        {
            var initialStage = _mapper.Map<InitialStageDTO, InitialStage>(initialStageDTO);
            initialStage.CreatedDate = DateTime.Now;
            var result = await _context.InitialStages.AddAsync(initialStage);
            await _context.SaveChangesAsync();
            return _mapper.Map<InitialStage, InitialStageDTO>(result.Entity);
        }

        public async Task<InitialStageDTO> DeleteApplication(int id)
        {
            var initialStage = await _context.InitialStages.FindAsync(id);
            if (initialStage != null)
            {
                initialStage.IsDeleted = true;
                initialStage.DeletedDate = DateTime.Now;
                var result = _context.InitialStages.Update(initialStage);
                await _context.SaveChangesAsync();
                return _mapper.Map<InitialStage, InitialStageDTO>(result.Entity);
            }
            return new InitialStageDTO();
        }

        public async Task<IEnumerable<InitialStageDTO>> GetAllApplication()
        {
            var initialStages = await _context.InitialStages.ToListAsync();
            if (initialStages.Any())
            {
                return _mapper.Map<IEnumerable<InitialStage>, IEnumerable<InitialStageDTO>>(initialStages);
            }
            return [];
        }

        public async Task<IEnumerable<InitialStageDTO>> GetAllApplicationsByUserId(string userId)
        {
            var initialStages = await _context.InitialStages.Where(x => x.UserId == userId).ToListAsync();
            if (initialStages.Any())
            {
                return _mapper.Map<IEnumerable<InitialStage>, IEnumerable<InitialStageDTO>>(initialStages);
            }
            return [];
        }

        public async Task<InitialStageDTO> GetApplicationById(int id)
        {
            var initialStage = await _context.InitialStages.FindAsync(id);
            if (initialStage != null)
            {
                return _mapper.Map<InitialStage, InitialStageDTO>(initialStage);
            }
            return new InitialStageDTO();
        }

        public async Task<InitialStageDTO> GetApplicationByUserId(string userId, int id)
        {
            var initialStage = await _context.InitialStages.Where(x => x.UserId == userId && x.Id == id).FirstOrDefaultAsync();
            if (initialStage != null)
            {
                return _mapper.Map<InitialStage, InitialStageDTO>(initialStage);
            }
            return new InitialStageDTO();
        }

        public async Task<InitialStageDTO> GetLastApplication()
        {
            // Get the last application By order by id
            var initialStage = await _context.InitialStages.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            if (initialStage != null)
            {
                return _mapper.Map<InitialStage, InitialStageDTO>(initialStage);
            }
            return new InitialStageDTO();
        }

        public async Task<InitialStageDTO> UpdateApplication(InitialStageDTO initialStageDTO)
        {
            var initialStage = await _context.InitialStages.FindAsync(initialStageDTO.Id);
            if (initialStage != null)
            {
                _mapper.Map(initialStageDTO, initialStage);
                initialStage.UpdatedDate = DateTime.Now;
                var result = _context.InitialStages.Update(initialStage);
                await _context.SaveChangesAsync();
                return _mapper.Map<InitialStage, InitialStageDTO>(result.Entity);
            }
            return new InitialStageDTO();
        }
    }
}
