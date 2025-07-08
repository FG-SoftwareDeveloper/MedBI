using MedBI.ClientSide.Pages.Shared;
using MedBI.ClientSide.Services;

namespace MedBI.ClientSide.Pages.Customer
{
    public class CustomerDashboardModel : BaseDashboard
    {
        

        public CustomerDashboardModel(NavigationApiService navApiService)
            : base(navApiService)
        {
        }
        public async Task OnGetAsync()
        {
            await LoadNavigationAsync("Customer");
        }
    }
}
