using DataModels.ApplicationModels;

namespace EMPP_Server.Infrastructure.Repositories.IRepo
{
    public interface ILanguageData
    {
        Task<LanguageDataDTO> GetLanguageByIdAsync(int id);
        // Get Languages by Application Id
        Task<LanguageDataDTO> GetLanguageByAppIdAsync(int appId);
        // Add Language
        Task<LanguageDataDTO> AddLanguageAsync(LanguageDataDTO language);
        // Update Language
        Task<LanguageDataDTO> UpdateLanguageAsync(LanguageDataDTO language);
        // Delete Language
        Task<bool> DeleteLanguageAsync(int id);

        // Check if Language Exists for a particular Application
        Task<bool> LanguageExistsAsync(int appId);
    }
}
