using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{
    [Table("Analyst")]
    public class Analyst
    {
        [Key]
        [Column("AnalystId")]
        public int AnalystId { get; set; }

        [Required]
        [Column("UserId")]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public required ApplicationUser User { get; set; }

        [Column("Department")]
        public string? Department { get; set; }      // nullable in SQL

        [Column("Specialty")]
        public string? Specialty { get; set; }       // nullable in SQL

        [Required]
        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }
    }
}
