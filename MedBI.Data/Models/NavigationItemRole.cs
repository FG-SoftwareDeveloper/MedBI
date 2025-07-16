using Microsoft.AspNetCore.Identity;

namespace MedBI.Data.Models
{
    public class NavigationItemRole
    {
        public int Id { get; set; }
        public int NavigationItemId { get; set; }
        public string RoleId { get; set; } = null!;

        public NavigationItem? NavigationItem { get; set; }


    }
}
