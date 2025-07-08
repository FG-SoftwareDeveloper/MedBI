using MedBI.ClientSide.Pages.Shared;
using MedBI.ClientSide.Services;

namespace MedBI.ClientSide.Pages.Admin
{
    public class AdminDashboard : BaseDashboard
    {
        public AdminDashboard(NavigationApiService navApiService)
            : base(navApiService)
        {
        }

        public async Task OnGetAsync()
        {
            await LoadNavigationAsync("Admin");
        }
    }
}
