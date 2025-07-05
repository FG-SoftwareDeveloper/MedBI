using MedBI.ClientSide.Models;
using MedBI.ClientSide.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedBI.ClientSide.Pages.Analyst
{
    public class AnalystDashboard : PageModel
    {
        private readonly NavigationApiService _navApiService;

        public List<NavigationItem> NavItems { get; set; } = new();

        public AnalystDashboard(NavigationApiService navApiService)
        {
            _navApiService = navApiService;
        }

        public async Task OnGetAsync()
        {
            var role = "Analyst";
            NavItems = await _navApiService.GetNavigationForRoleAsync(role);
        }
    }
}
