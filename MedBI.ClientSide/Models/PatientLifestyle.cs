using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.ClientSide.Models
{
    public class PatientLifestyle
    {

        [Key]
        [Column("lifestyle_id")]
        public int LifestyleId { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Column("smoking_status")]
        [MaxLength(50)]
        public string? SmokingStatus { get; set; }

        [Column("alcohol_use")]
        [MaxLength(50)]
        public string? AlcoholUse { get; set; }

        [Column("exercise_frequency")]
        [MaxLength(50)]
        public string? ExerciseFrequency { get; set; }

        [Column("diet_quality")]
        [MaxLength(50)]
        public string? DietQuality { get; set; }

        [Column("notes")]
        [MaxLength(255)]
        public string? Notes { get; set; }
    }
}
