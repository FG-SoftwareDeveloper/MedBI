using MedBI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedBI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NavigationController : ControllerBase
    {
        private readonly MedBIContext _context;

        public NavigationController(MedBIContext context)
        {
            _context = context;
        }

        // GET: api/navigation/{role}
        [HttpGet("{role}")]
        public async Task<ActionResult<List<NavigationItem>>> GetNavigationItems(string role)
        {
            var navItems = await
     (from navRole in _context.NavigationItemRoles
      join dbRole in _context.Roles
          on navRole.RoleId equals dbRole.Id
      join navItem in _context.NavigationItems
          on navRole.NavigationItemId equals navItem.Id
      where dbRole.NormalizedName == role.ToUpper()
      orderby navItem.Order
      select navItem)
     .ToListAsync();


            return Ok(navItems);
        }

    }
}
