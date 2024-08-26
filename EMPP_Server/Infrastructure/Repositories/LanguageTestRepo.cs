using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;
using EMPP_Server.Data;
using EMPP_Server.Infrastructure.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;

namespace EMPP_Server.Infrastructure.Repositories
{
    public class LanguageTestRepo : ILanguageTestRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LanguageTestRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LanguageTestDTO> AddLanguageTestAsync(LanguageTestDTO languageTest)
        {
            var newLanguageTest = _mapper.Map<LanguageTestDTO, LanguageTest>(languageTest);
            newLanguageTest.CreatedDate = DateTime.Now;
            var result = await _context.LanguageTests.AddAsync(newLanguageTest);
            await _context.SaveChangesAsync();
            return _mapper.Map<LanguageTest, LanguageTestDTO>(result.Entity);
        }

        public async Task<bool> DeleteLanguageTestAsync(int id)
        {
            var languageTest = await _context.LanguageTests.FindAsync(id);
            if (languageTest == null)
            {
                return false;
            }
            _context.LanguageTests.Remove(languageTest);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<LanguageTestDTO> GetLanguageTestByIdAsync(int id)
        {
            var languageTest = await _context.LanguageTests.FindAsync(id);
            if (languageTest == null)
            {
                return new LanguageTestDTO();
            }
            return _mapper.Map<LanguageTest, LanguageTestDTO>(languageTest);
        }

        public async Task<IEnumerable<LanguageTestDTO>> GetLanguageTestsByAppIdAsync(int appId)
        {
            // Get language data by application id
            var languageData = await _context.LanguageData.FirstOrDefaultAsync(x => x.InitialStageId == appId);
            if (languageData != null)
            {
                var languageTests = await _context.LanguageTests.Where(x => x.LanguageDataId == languageData.Id).ToListAsync();
                if (languageTests.Any())
                {
                    return _mapper.Map<IEnumerable<LanguageTest>, IEnumerable<LanguageTestDTO>>(languageTests);
                }
                return [];
            }
            return [];
        }

        public async Task<IEnumerable<LanguageTestDTO>> GetLanguageTestsByLangIdAsync(int langId)
        {
            var languageTests = await _context.LanguageTests.Where(x => x.LanguageDataId == langId).ToListAsync();
            if (languageTests.Any())
            {
                return _mapper.Map<IEnumerable<LanguageTest>, IEnumerable<LanguageTestDTO>>(languageTests);
            }
            return [];
        }

        public async Task<LanguageTestDTO> UpdateLanguageTestAsync(LanguageTestDTO languageTest)
        {
            var languageTestToUpdate = await _context.LanguageTests.FindAsync(languageTest.Id);
            if (languageTestToUpdate == null)
            {
                return new LanguageTestDTO();
            }
            _mapper.Map(languageTest, languageTestToUpdate);
            languageTestToUpdate.UpdatedDate = DateTime.Now;
            var result = _context.LanguageTests.Update(languageTestToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<LanguageTest, LanguageTestDTO>(result.Entity);
        }
    }
}
