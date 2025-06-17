using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedBI.Data.Models;

namespace MedBI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly MedBIContext _context;

        public ClaimsController(MedBIContext context)
        {
            _context = context;
        }

        // GET: api/Claims with Filtering 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Claim>>> GetClaims(
    [FromQuery] string? status,
    [FromQuery] int? doctorId,
    [FromQuery] int? patientId,
    [FromQuery] string? sortBy = "dateOfService",
    [FromQuery] string? sortOrder = "desc",
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10)
        {
            var query = _context.Claims
                .Include(c => c.Doctor)
                .Include(c => c.Patient)
                .Include(c => c.Documents)
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
                query = query.Where(c => c.Status == status);

            if (doctorId.HasValue)
                query = query.Where(c => c.DoctorId == doctorId.Value);

            if (patientId.HasValue)
                query = query.Where(c => c.PatientId == patientId.Value);

            // Sorting
            query = sortBy?.ToLower() switch
            {
                "amount" => sortOrder == "asc" ? query.OrderBy(c => c.Amount) : query.OrderByDescending(c => c.Amount),
                "status" => sortOrder == "asc" ? query.OrderBy(c => c.Status) : query.OrderByDescending(c => c.Status),
                _ => sortOrder == "asc" ? query.OrderBy(c => c.DateOfService) : query.OrderByDescending(c => c.DateOfService)
            };

            // Pagination
            var skip = (page - 1) * pageSize;
            var paged = await query.Skip(skip).Take(pageSize).ToListAsync();

            return Ok(paged);
        }


        // GET: api/Claims/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Claim>> GetClaim(int id)
        {
            var claim = await _context.Claims.FindAsync(id);

            if (claim == null)
            {
                return NotFound();
            }

            return claim;
        }

        // PUT: api/Claims/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClaim(int id, Claim claim)
        {
            if (id != claim.ClaimId)
            {
                return BadRequest();
            }

            _context.Entry(claim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClaimExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Claims
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Claim>> PostClaim(Claim claim)
        {
            _context.Claims.Add(claim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClaim", new { id = claim.ClaimId }, claim);
        }

        // DELETE: api/Claims/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClaim(int id)
        {
            var claim = await _context.Claims.FindAsync(id);
            if (claim == null)
            {
                return NotFound();
            }

            _context.Claims.Remove(claim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClaimExists(int id)
        {
            return _context.Claims.Any(e => e.ClaimId == id);
        }
    }
}
