using MedBI.ClientSide.Models;

namespace MedBI.ClientSide.Services
{
    public class NavigationApiService
    {
        private readonly HttpClient _http;

        public NavigationApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("MedBI.API");
        }

        public async Task<List<NavigationItem>> GetNavigationForRoleAsync(string roleName)
        {
            var items = await _http.GetFromJsonAsync<List<NavigationItem>>($"api/navigation/{roleName}");


            return items ?? new List<NavigationItem>();
        }
    }
}
