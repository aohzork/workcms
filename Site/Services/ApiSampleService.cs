using Site.Data;

namespace Site.Services
{
    public class ApiSampleService
    {
        private readonly HttpClient _httpClient;
        public ApiSampleService(HttpClient httpClient, ApiSettings apiSettings, IHostEnvironment environment)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(environment.EnvironmentName.Equals("Development", StringComparison.OrdinalIgnoreCase) 
                ? apiSettings.Development
                : apiSettings.Production);
        }
    }
}
