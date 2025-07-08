using MedBI.ClientSide.Pages.Shared;
using MedBI.ClientSide.Services;



namespace MedBI.ClientSide.Pages.Doctor
{
    public class DoctorDashboardModel : BaseDashboard
    {
        public DoctorDashboardModel(NavigationApiService navApiService)
            : base(navApiService)
        {
        }

        public async Task OnGetAsync()
        {
            await LoadNavigationAsync("Doctor");
        }
    }
}
