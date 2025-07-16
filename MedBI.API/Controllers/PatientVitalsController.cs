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
    public class PatientVitalsController : ControllerBase
    {
        private readonly MedBIContext _context;

        public PatientVitalsController(MedBIContext context)
        {
            _context = context;
        }

        // GET: api/PatientVitals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientVitals>>> GetPatientVitals(
            [FromQuery] int? patientId,
            [FromQuery] DateTime? fromDate,
            [FromQuery] DateTime? toDate,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = _context.PatientVitals
                .Include(v => v.Patient)
                .AsQueryable();

            if (patientId.HasValue)
                query = query.Where(v => v.PatientId == patientId.Value);

            if (fromDate.HasValue)
                query = query.Where(v => v.RecordedAt >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(v => v.RecordedAt <= toDate.Value);

            var skip = (page - 1) * pageSize;

            var vitals = await query
                .OrderByDescending(v => v.RecordedAt)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            return Ok(vitals);
        }

        // GET: api/PatientVitals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientVitals>> GetPatientVitals(int id)
        {
            var vitals = await _context.PatientVitals
                .Include(v => v.Patient)
                .FirstOrDefaultAsync(v => v.VitalsId == id);

            if (vitals == null)
            {
                return NotFound();
            }

            return vitals;
        }

        // POST: api/PatientVitals
        [HttpPost]
        public async Task<ActionResult<PatientVitals>> PostPatientVitals(PatientVitals vitals)
        {
            vitals.RecordedAt = vitals.RecordedAt == default
                ? DateTime.Now
                : vitals.RecordedAt;

            _context.PatientVitals.Add(vitals);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatientVitals), new { id = vitals.VitalsId }, vitals);
        }

        // PUT: api/PatientVitals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientVitals(int id, PatientVitals vitals)
        {
            if (id != vitals.VitalsId)
            {
                return BadRequest();
            }

            _context.Entry(vitals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientVitalsExists(id))
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

        // DELETE: api/PatientVitals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientVitals(int id)
        {
            var vitals = await _context.PatientVitals.FindAsync(id);
            if (vitals == null)
            {
                return NotFound();
            }

            _context.PatientVitals.Remove(vitals);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientVitalsExists(int id)
        {
            return _context.PatientVitals.Any(e => e.VitalsId == id);
        }
    }
}
