using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{
    [Table("Patient_Allergies")]
    public class PatientAllergies
    {
        [Key]
        [Column("allergy_id")]
        public int AllergyId { get; set; }

        [Required]
        [Column("allergy_name")]
        public required string AllergyName { get; set; }

        [Column("severity")]
        public string? Severity { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public required Patient Patient { get; set; }
    }
}
