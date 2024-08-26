using DataModels.ApplicationModels;

namespace EMPP_Server.Infrastructure.Repositories.IRepo
{
    public interface ILanguageTestRepo
    {
        Task<LanguageTestDTO> GetLanguageTestByIdAsync(int id);

        //Get Language Tests by Language Id
        Task<IEnumerable<LanguageTestDTO>> GetLanguageTestsByLangIdAsync(int langId);

        // Get Language Tests by Application Id
        Task<IEnumerable<LanguageTestDTO>> GetLanguageTestsByAppIdAsync(int appId);
        // Add Language Test
        Task<LanguageTestDTO> AddLanguageTestAsync(LanguageTestDTO languageTest);
        // Update Language Test
        Task<LanguageTestDTO> UpdateLanguageTestAsync(LanguageTestDTO languageTest);
        // Delete Language Test
        Task<bool> DeleteLanguageTestAsync(int id);
    }
}
