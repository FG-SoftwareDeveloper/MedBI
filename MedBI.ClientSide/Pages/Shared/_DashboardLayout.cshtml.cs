using MedBI.ClientSide.Models;
using MedBI.ClientSide.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedBI.ClientSide.Pages.Shared
{
    public class DashboardLayoutModel : PageModel
    {
        public List<DashboardCardModel> DashboardCards { get; set; } = new();

        public async Task LoadDashboardCardsAsync()
        {
            // TEMPORARY STATIC CARDS FOR MVP
            DashboardCards = new List<DashboardCardModel>
            {
                new DashboardCardModel
                {
                    Title = "Claims Summary",
                    ContentHtml = "<p>Total Claims: 152</p>",
                    Width = 6
                },
                new DashboardCardModel
                {
                    Title = "System Status",
                    ContentHtml = "<p>All systems operational</p>",
                    Width = 6
                }
            };

            // TODO: Later load from DB or API per user
            await Task.CompletedTask;
        }
    }
}
