using MedBI.ClientSide.Models;
using MedBI.ClientSide.Pages.Shared;
using MedBI.ClientSide.Services;

namespace MedBI.ClientSide.Pages.IT
{
    public class IT_DashModel : DashboardLayoutModel 
    {
        private readonly NavigationApiService _navApiService;
        public IT_DashModel(NavigationApiService navApiService)
        {
            _navApiService = navApiService;
        }

        public List<NavigationItem> NavItems { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Load nav items
            NavItems = await _navApiService.GetNavigationForRoleAsync("Customer");

            // Load dashboard cards
            await LoadDashboardCardsAsync();
        }
    }
}
