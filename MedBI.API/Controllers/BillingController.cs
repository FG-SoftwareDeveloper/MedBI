using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedBI.Data.Models;

namespace MedBI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly MedBIContext _context;

        public BillingController(MedBIContext context)
        {
            _context = context;
        }

        // GET: api/Billing with filters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Billing>>> GetBillings(
            [FromQuery] int? patientId,
            [FromQuery] int? appointmentId,
            [FromQuery] string? paymentStatus,
            [FromQuery] string? insuranceProvider,
            [FromQuery] string? sortBy = "createdAt",
            [FromQuery] string? sortOrder = "desc",
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = _context.Billings
                .Include(b => b.Patient)
                .Include(b => b.Appointment)
                .AsQueryable();

            if (patientId.HasValue)
                query = query.Where(b => b.PatientId == patientId.Value);

            if (appointmentId.HasValue)
                query = query.Where(b => b.AppointmentId == appointmentId.Value);

            if (!string.IsNullOrEmpty(paymentStatus))
                query = query.Where(b => b.PaymentStatus == paymentStatus);

            if (!string.IsNullOrEmpty(insuranceProvider))
                query = query.Where(b => b.InsuranceProvider == insuranceProvider);

            // Sorting
            query = sortBy?.ToLower() switch
            {
                "totalamount" => sortOrder == "asc"
                    ? query.OrderBy(b => b.TotalAmount)
                    : query.OrderByDescending(b => b.TotalAmount),

                "paymentdate" => sortOrder == "asc"
                    ? query.OrderBy(b => b.PaymentDate)
                    : query.OrderByDescending(b => b.PaymentDate),

                _ => sortOrder == "asc"
                    ? query.OrderBy(b => b.CreatedAt)
                    : query.OrderByDescending(b => b.CreatedAt)
            };

            var skip = (page - 1) * pageSize;
            var paged = await query.Skip(skip).Take(pageSize).ToListAsync();

            return Ok(paged);
        }


        // GET: api/Billing/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Billing>> GetBilling(int id)
        {
            var billing = await _context.Billings
                .Include(b => b.Patient)
                .Include(b => b.Appointment)
                .FirstOrDefaultAsync(b => b.BillId == id);

            if (billing == null)
            {
                return NotFound();
            }

            return billing;
        }


        // PUT: api/Billing/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBilling(int id, Billing billing)
        {
            if (id != billing.BillId)
            {
                return BadRequest();
            }

            _context.Entry(billing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillingExists(id))
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


        // POST: api/Billing
        [HttpPost]
        public async Task<ActionResult<Billing>> PostBilling(Billing billing)
        {
            _context.Billings.Add(billing);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBilling), new { id = billing.BillId }, billing);
        }


        // DELETE: api/Billing/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBilling(int id)
        {
            var billing = await _context.Billings.FindAsync(id);
            if (billing == null)
            {
                return NotFound();
            }

            _context.Billings.Remove(billing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillingExists(int id)
        {
            return _context.Billings.Any(e => e.BillId == id);
        }
    }
}
