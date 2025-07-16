using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{
    [Table("Patient_ChronicConditions")]
    public class PatientChronicConditions
    {
        [Key]
        [Column("chronic_condition_id")]
        public int ChronicConditionId { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Required]
        [Column("condition_name")]
        public string ConditionName { get; set; }

        [Column("diagnosis_date", TypeName = "date")]
        public DateTime? DiagnosisDate { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("notes")]
        public string? Notes { get; set; }
    }
}

