using MedBI.Data.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MedBI.UI.Services
{
    public class ClaimApiService
    {
        private readonly HttpClient _http;

        public ClaimApiService(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("MedBI.API");
        }

        public async Task<List<Claim>> GetAllClaimsAsync()
        {
            try
            {
                var claims = await _http.GetFromJsonAsync<List<Claim>>("api/claims", new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                });

                return claims ?? new List<Claim>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"[ClaimApiService] HTTP error: {ex.Message}");
                return new List<Claim>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ClaimApiService] Unexpected error: {ex.Message}");
                return new List<Claim>();
            }
        }
    }
}
