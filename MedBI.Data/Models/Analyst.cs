using System.ComponentModel.DataAnnotations;

namespace MedBI.Data.Models
{
    public class Analyst
    {
        public int AnalystId { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        public string? Email { get; set; }

        // Optionally link to Claims or Reports if needed
        // public ICollection<Claim> ClaimsReviewed { get; set; }
    }
}
