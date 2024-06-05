using System.Text.Json;
using System.Text;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class AirSearchService
    {
        private readonly HttpClient _httpClient;

        public AirSearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SearchAvailabilityAsync(SearchRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("https://localhost:5002/api/AirSearch/availability", content);

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

        public async Task<string> GetAirportsAsync()
        {
            var requestUri = "https://localhost:5002/api/AirSearch/airports";
            var response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
