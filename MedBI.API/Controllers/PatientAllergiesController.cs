using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedBI.Data.Models;

namespace MedBI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAllergiesController : ControllerBase
    {
        private readonly MedBIContext _context;

        public PatientAllergiesController(MedBIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientAllergies>>> GetAll()
        {
            return await _context.PatientAllergies
                .Include(a => a.Patient)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientAllergies>> GetById(int id)
        {
            var allergy = await _context.PatientAllergies
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(a => a.AllergyId == id);

            if (allergy == null)
                return NotFound();

            return allergy;
        }

        [HttpPost]
        public async Task<ActionResult<PatientAllergies>> Create(PatientAllergies allergy)
        {
            _context.PatientAllergies.Add(allergy);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = allergy.AllergyId }, allergy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientAllergies allergy)
        {
            if (id != allergy.AllergyId)
                return BadRequest();

            _context.Entry(allergy).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var allergy = await _context.PatientAllergies.FindAsync(id);
            if (allergy == null)
                return NotFound();

            _context.PatientAllergies.Remove(allergy);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
