using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;
using DataModels.SystemModels;
using EMPP_Server.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EMPP_Server.Infrastructure.Repositories.IMainInfoRepo
{
    public class MainInfoRepo : IMainInfoRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MainInfoRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MainInfoDTO> AddMainInfo(MainInfoDTO mainInfo)
        {
            var newMainInfo = _mapper.Map<MainInfoDTO, MainInfo>(mainInfo);
            newMainInfo.CreatedDate = DateTime.Now;
            var result = await _context.MainInfo.AddAsync(newMainInfo);
            await _context.SaveChangesAsync();
            return _mapper.Map<MainInfo, MainInfoDTO>(result.Entity);
        }

        public async Task<MainInfoDTO> DeleteMainInfo(int id)
        {
            var mainInfo = await _context.MainInfo.FindAsync(id);
            if (mainInfo == null)
            {
                return new MainInfoDTO();
            }
            mainInfo.IsDeleted = true;
            mainInfo.DeletedDate = DateTime.Now;
            mainInfo.UpdatedDate = DateTime.Now;
            var result = _context.MainInfo.Update(mainInfo);
            await _context.SaveChangesAsync();
            return _mapper.Map<MainInfo, MainInfoDTO>(result.Entity);
        }

        public async Task<IEnumerable<MainInfoDTO>> GetAll()
        {
            var mainInfo = await _context.MainInfo.Include(w=>w.WorkHistories).ToListAsync();
            if (mainInfo == null)
            {
                return [];
            }
            return _mapper.Map<IEnumerable<MainInfo>, IEnumerable<MainInfoDTO>>(mainInfo);
        }

        public async Task<int> GetLastApplicationId()
        {
            var mainInfo = await _context.MainInfo.OrderByDescending(x => x.ApplicationNumber).FirstOrDefaultAsync();
            if (mainInfo == null)
            {
                return 0;
            }
            return mainInfo.Id;
        }

        public async Task<MainInfoDTO> GetMainInfoByGuid(Guid guid)
        {
            var mainInfo = await _context.MainInfo.Include(w => w.WorkHistories).FirstOrDefaultAsync(x => x.ApplicationNumber == guid);
            if (mainInfo == null)
            {
                return new MainInfoDTO();
            }
            return _mapper.Map<MainInfo, MainInfoDTO>(mainInfo);
        }

        public async Task<MainInfoDTO> GetMainInfoById(int id)
        {
            var mainInfo = await _context.MainInfo.FindAsync(id);
            if (mainInfo == null)
            {
                return new MainInfoDTO();
            }
            return _mapper.Map<MainInfo, MainInfoDTO>(mainInfo);
        }

        public async Task<MainInfoDTO> GetMainInfoByUserId(string userId)
        {
            var mainInfo = await _context.MainInfo.Include(w => w.WorkHistories).FirstOrDefaultAsync(x => x.UserId == userId);
            if (mainInfo == null)
            {
                return new MainInfoDTO();
            }
            return _mapper.Map<MainInfo, MainInfoDTO>(mainInfo);
        }

        public async Task<IEnumerable<MainInfoDTO>> SearchMainInfo(string search)
        {
            var mainInfo = await _context.MainInfo.Include(w => w.WorkHistories).Where(x => x.FirstName.Contains(search) || x.MiddleName.Contains(search) || x.LastName.Contains(search)).ToListAsync();
            if (mainInfo == null)
            {
                return [];
            }
            return _mapper.Map<IEnumerable<MainInfo>, IEnumerable<MainInfoDTO>>(mainInfo);
        }

        public async Task<MainInfoDTO> UpdateMainInfo(MainInfoDTO mainInfo)
        {
            var mainInfoToUpdate = await _context.MainInfo.FindAsync(mainInfo.Id);
            if (mainInfoToUpdate == null)
            {
                return new MainInfoDTO();
            }
            _mapper.Map(mainInfo, mainInfoToUpdate);
            mainInfoToUpdate = _mapper.Map<MainInfoDTO, MainInfo>(mainInfo);
            mainInfoToUpdate.UpdatedDate = DateTime.Now;
            var result = _context.MainInfo.Update(mainInfoToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<MainInfo, MainInfoDTO>(result.Entity);
        }
    }
}
