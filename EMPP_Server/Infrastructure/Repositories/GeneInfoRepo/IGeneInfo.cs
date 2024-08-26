namespace EMPP_Server.Infrastructure.Repositories.GeneInfoRepo
{
    public interface IGeneInfo 
    {
        // Get All Countries
        Task<List<string>> GetALLCountries();
        // Get All States
        Task<List<string>> GetALLStates();
        // Get All Cities
        Task<List<string>> GetALLCities();

        // Get All Languages
        Task<List<string>> GetALLLanguages();
    }
}
