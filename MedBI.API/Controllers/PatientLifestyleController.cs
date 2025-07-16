using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedBI.Data.Models;

namespace MedBI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientLifestyleController : ControllerBase
    {
        private readonly MedBIContext _context;

        public PatientLifestyleController(MedBIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientLifestyle>>> GetAll()
        {
            return await _context.PatientLifestyle
                .Include(l => l.Patient)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientLifestyle>> GetById(int id)
        {
            var lifestyle = await _context.PatientLifestyle
                .Include(l => l.Patient)
                .FirstOrDefaultAsync(l => l.LifestyleId == id);

            if (lifestyle == null)
                return NotFound();

            return lifestyle;
        }

        [HttpPost]
        public async Task<ActionResult<PatientLifestyle>> Create(PatientLifestyle lifestyle)
        {
            _context.PatientLifestyle.Add(lifestyle);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = lifestyle.LifestyleId }, lifestyle);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientLifestyle lifestyle)
        {
            if (id != lifestyle.LifestyleId)
                return BadRequest();

            _context.Entry(lifestyle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lifestyle = await _context.PatientLifestyle.FindAsync(id);
            if (lifestyle == null)
                return NotFound();

            _context.PatientLifestyle.Remove(lifestyle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
