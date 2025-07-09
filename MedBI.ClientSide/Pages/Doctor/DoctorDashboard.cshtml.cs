using MedBI.ClientSide.Models;
using MedBI.ClientSide.Pages.Shared;
using MedBI.ClientSide.Services;



namespace MedBI.ClientSide.Pages.Doctor
{
    public class DoctorDashboardModel : DashboardLayoutModel
    {
        private readonly NavigationApiService _navApiService;

        public DoctorDashboardModel(NavigationApiService navApiService)
        {
            _navApiService = navApiService;
        }
        public List<NavigationItem> NavItems { get; set; } = new();


        public async Task OnGetAsync()
        {
            // Load nav items
            NavItems = await _navApiService.GetNavigationForRoleAsync("Doctor");

            // Load dashboard cards
            await LoadDashboardCardsAsync();
        }
    }
}
