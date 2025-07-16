using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedBI.Data.Models;

namespace MedBI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientLabResultsController : ControllerBase
    {
        private readonly MedBIContext _context;

        public PatientLabResultsController(MedBIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientLabResults>>> GetAll()
        {
            return await _context.PatientLabResults
                .Include(r => r.Patient)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientLabResults>> GetById(int id)
        {
            var result = await _context.PatientLabResults
                .Include(r => r.Patient)
                .FirstOrDefaultAsync(r => r.LabResultId == id);

            if (result == null)
                return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<PatientLabResults>> Create(PatientLabResults result)
        {
            _context.PatientLabResults.Add(result);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = result.LabResultId }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientLabResults result)
        {
            if (id != result.LabResultId)
                return BadRequest();

            _context.Entry(result).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.PatientLabResults.FindAsync(id);
            if (result == null)
                return NotFound();

            _context.PatientLabResults.Remove(result);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
