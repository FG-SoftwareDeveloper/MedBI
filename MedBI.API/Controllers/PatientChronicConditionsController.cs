using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MedBI.Data.Models;

namespace MedBI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientChronicConditionsController : ControllerBase
    {
        private readonly MedBIContext _context;

        public PatientChronicConditionsController(MedBIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientChronicConditions>>> GetAll()
        {
            return await _context.PatientChronicConditions
                .Include(c => c.Patient)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientChronicConditions>> GetById(int id)
        {
            var condition = await _context.PatientChronicConditions
                .Include(c => c.Patient)
                .FirstOrDefaultAsync(c => c.ChronicConditionId == id);

            if (condition == null)
                return NotFound();

            return condition;
        }

        [HttpPost]
        public async Task<ActionResult<PatientChronicConditions>> Create(PatientChronicConditions condition)
        {
            _context.PatientChronicConditions.Add(condition);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = condition.ChronicConditionId }, condition);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PatientChronicConditions condition)
        {
            if (id != condition.ChronicConditionId)
                return BadRequest();

            _context.Entry(condition).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var condition = await _context.PatientChronicConditions.FindAsync(id);
            if (condition == null)
                return NotFound();

            _context.PatientChronicConditions.Remove(condition);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
