using MedBI.ClientSide.Models;
using MedBI.ClientSide.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedBI.ClientSide.Pages.Admin
{
    public class AdminDashboard : PageModel
    {
        private readonly NavigationApiService _navApiService;

        public List<NavigationItem> NavItems { get; set; } = new();

        public AdminDashboard(NavigationApiService navApiService)
        {
            _navApiService = navApiService;
        }

        public async Task OnGetAsync()
        {
            var role = "Admin";
            NavItems = await _navApiService.GetNavigationForRoleAsync(role);
        }
    }
}
