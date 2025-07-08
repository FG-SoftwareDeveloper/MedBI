using MedBI.Data.Models;
using MedBI.UI.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedBI.UI.Pages.Claims
{
    public class IndexModel : PageModel
    {
        private readonly ClaimApiService _claimApiService;

        public IndexModel(ClaimApiService claimApiService)
        {
            _claimApiService = claimApiService;
        }

        public List<Claim> Claims { get; set; } = new();

        public async Task OnGetAsync()
        {
            Claims = await _claimApiService.GetAllClaimsAsync();
            Console.WriteLine($"[Index] Retrieved {Claims.Count} claims");
        }
    }

}
