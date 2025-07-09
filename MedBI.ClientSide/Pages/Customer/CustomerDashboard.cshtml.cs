using MedBI.ClientSide.Models;
using MedBI.ClientSide.Pages.Shared;
using MedBI.ClientSide.Services;

namespace MedBI.ClientSide.Pages.Customer
{
    public class CustomerDashboardModel : DashboardLayoutModel
    {
        private readonly NavigationApiService _navApiService;

        public CustomerDashboardModel(NavigationApiService navApiService)
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
