using MedBI.ClientSide.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedBI.ClientSide.Pages
{
    public class IndexModel : PageModel
    {
        /* private readonly ILogger<IndexModel> _logger;
         private readonly IHttpClientFactory _httpClientFactory;
         public List<Claim> Claims { get; set; } = new();

         public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory httpClientFactory)
         {
             _logger = logger;
             _httpClientFactory = httpClientFactory;
         }

         public async Task OnGetAsync()
         {
             var client = _httpClientFactory.CreateClient("MedBI.API");

             try
             {
                 var response = await client.GetAsync("/api/claims");

                 if (response.IsSuccessStatusCode)
                 {
                     var data = await response.Content.ReadFromJsonAsync<List<Claim>>();
                     Claims = data ?? new List<Claim>();
                 }
                 else
                 {
                     Console.WriteLine($"[Index] API returned status code: {response.StatusCode}");
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"[Index] Error fetching claims: {ex.Message}");
             }
         }*/
       
            public IActionResult OnGet()
            {
                // Optional redirect
                return RedirectToPage("/Account/Login");
            }
        

    }
}
