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
            var navItems = await _context.NavigationItemRoles
                .Where(r => r.RoleName == role && r.NavigationItem != null)
                .Select(r => r.NavigationItem!)
                .OrderBy(n => n.Order)
                .ToListAsync();

            return Ok(navItems);
        }
    }
}
