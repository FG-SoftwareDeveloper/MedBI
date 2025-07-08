using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBI.Data.Models
{
    public class NavigationItemRole
    {
        public int Id { get; set; }
        public int NavigationItemId { get; set; }
        public string RoleName { get; set; } = string.Empty;

        public NavigationItem? NavigationItem { get; set; }
    }
}
