using MedBI.ClientSide.Pages.Shared;
using MedBI.ClientSide.Services;
using MedBI.ClientSide.Models;


namespace MedBI.ClientSide.Pages.Analyst
{
    public class AnalystDashboard : DashboardLayoutModel
    {
        private readonly NavigationApiService _navApiService;
        public AnalystDashboard(NavigationApiService navApiService)
        {
            _navApiService = navApiService;
        }

        public List<NavigationItem> NavItems { get; set; } = new();



        public async Task OnGetAsync()
        {
            // Load nav items
            NavItems = await _navApiService.GetNavigationForRoleAsync("Analyst");

            // Load dashboard cards
            await LoadDashboardCardsAsync();
        }
    }   
}
