
using DataModels.SystemModels;
using Newtonsoft.Json;

namespace EMPP_Server.Infrastructure.Repositories.GeneInfoRepo
{
    public class GeneInfoRepo : IGeneInfo
    {
        private readonly HttpClient _httpClient;
        public GeneInfoRepo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<string>> GetALLCountries()
        {
            // use this API: https://restcountries.com/v3.1/all
            HttpResponseMessage response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var countries = JsonConvert.DeserializeObject<List<CountryDTO>>(responseBody);

            List<string> countryList = new List<string>();
            // Extract country names
            foreach (var country in countries)
            {
                if (country.Name != null && country.Name.Common != null)
                {
                    countryList.Add(country.Name.Common);
                }
            }

            // Catch and try to handle exceptions
            try
            {
                return countryList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return [];
            }
        }
    }
}
