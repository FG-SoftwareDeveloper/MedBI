using MedBI.ClientSide.Models;
using MedBI.ClientSide.Pages.Shared;
using MedBI.ClientSide.Services;

namespace MedBI.ClientSide.Pages.Admin
{
    public class AdminDashboard : DashboardLayoutModel
    {
        private readonly NavigationApiService _navApiService;
        public AdminDashboard(NavigationApiService navApiService)
        {
            _navApiService = navApiService;
        }
        public List<NavigationItem> NavItems { get; set; } = new();


        public async Task OnGetAsync()
        {
            // Load nav items
            NavItems = await _navApiService.GetNavigationForRoleAsync("Admin");

            // Load dashboard cards
            await LoadDashboardCardsAsync();
        }
    }
}
