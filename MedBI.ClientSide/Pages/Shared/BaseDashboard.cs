using MedBI.ClientSide.Models;
using MedBI.ClientSide.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedBI.ClientSide.Pages.Shared
{
    public class BaseDashboard : PageModel
    {
        protected readonly NavigationApiService _navApiService;

        public List<NavigationItem> NavItems { get; set; } = new();

        public BaseDashboard(NavigationApiService navApiService)
        {
            _navApiService = navApiService;
        }

        public async Task LoadNavigationAsync(string role)
        {
            NavItems = await _navApiService.GetNavigationForRoleAsync(role);
        }
    }
}
