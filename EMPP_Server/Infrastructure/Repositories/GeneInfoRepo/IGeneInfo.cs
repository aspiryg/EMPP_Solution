namespace EMPP_Server.Infrastructure.Repositories.GeneInfoRepo
{
    public interface IGeneInfo 
    {
        // Get All Countries
        Task<List<string>> GetALLCountries();
    }
}
