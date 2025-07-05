using MedBI.ClientSide.Models;
using MedBI.ClientSide.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedBI.ClientSide.Pages.Customer
{
    public class CustomerDashboardModel : PageModel
    {
        private readonly NavigationApiService _navApiService;

        public List<NavigationItem> NavItems { get; set; } = new();

        public CustomerDashboardModel(NavigationApiService navApiService)
        {
            _navApiService = navApiService;
        }

        public async Task OnGetAsync()
        {
            var role = "Customer";
            NavItems = await _navApiService.GetNavigationForRoleAsync(role);
        }
    }
}
