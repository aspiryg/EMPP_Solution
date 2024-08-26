using AutoMapper;
using DataAccess.ApplicationData;
using DataModels.ApplicationModels;
using EMPP_Server.Data;
using EMPP_Server.Infrastructure.Repositories.IRepo;
using Microsoft.EntityFrameworkCore;

namespace EMPP_Server.Infrastructure.Repositories
{
    public class LanguageDataRepo : ILanguageData
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LanguageDataRepo(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<LanguageDataDTO> AddLanguageAsync(LanguageDataDTO language)
        {
            var newLanguage = _mapper.Map<LanguageDataDTO,LanguageData>(language);
            newLanguage.CreatedDate = DateTime.Now;
            var result = await _context.LanguageData.AddAsync(newLanguage);
            await _context.SaveChangesAsync();
            return _mapper.Map<LanguageData, LanguageDataDTO>(result.Entity);
        }

        public async Task<bool> DeleteLanguageAsync(int id)
        {
            var language = await _context.LanguageData.FindAsync(id);
            if (language == null)
            {
                return false;
            }
            _context.LanguageData.Remove(language);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<LanguageDataDTO> GetLanguageByIdAsync(int id)
        {
            var language = await _context.LanguageData.FindAsync(id);
            if (language == null) 
            {
                return new LanguageDataDTO();
            }
            return _mapper.Map<LanguageData, LanguageDataDTO>(language);
        }

        public async Task<LanguageDataDTO> GetLanguageByAppIdAsync(int appId)
        {
            var languages = await _context.LanguageData.Include(u=>u.LanguageTests).FirstOrDefaultAsync(x => x.InitialStageId == appId);
            if (languages == null)
            {
                return new LanguageDataDTO();
            }
            return _mapper.Map<LanguageData, LanguageDataDTO>(languages);
        }

        public async Task<LanguageDataDTO> UpdateLanguageAsync(LanguageDataDTO language)
        {
            var languageToUpdate = await _context.LanguageData.FindAsync(language.Id);
            if (languageToUpdate == null)
            {
                return new LanguageDataDTO();
            }
            _mapper.Map(language, languageToUpdate);
            languageToUpdate.UpdatedDate = DateTime.Now;
            var result = _context.LanguageData.Update(languageToUpdate);
            await _context.SaveChangesAsync();
            return _mapper.Map<LanguageData, LanguageDataDTO>(result.Entity);
        }

        public async Task<bool> LanguageExistsAsync(int appId)
        {
            return await _context.LanguageData.AnyAsync(x => x.InitialStageId == appId);
        }
    }
}
