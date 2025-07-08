using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBI.Data.Models
{
    public class NavigationItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? IconCssClass { get; set; }
        public string? PageUrl { get; set; }
        public int Order { get; set; }

        public ICollection<NavigationItemRole> NavigationItemRoles { get; set; } = new List<NavigationItemRole>();
    }
}
