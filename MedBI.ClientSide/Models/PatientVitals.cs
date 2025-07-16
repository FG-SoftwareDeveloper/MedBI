using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.ClientSide.Models
{
    public class PatientVitals
    {
        [Key]
        [Column("vitals_id")]
        public int VitalsId { get; set; }

        [Required]
        [Column("recorded_at")]
        public DateTime RecordedAt { get; set; }

        [Column("height_cm")]
        public decimal? HeightCm { get; set; }

        [Column("weight_kg")]
        public decimal? WeightKg { get; set; }

        [Column("systolic_bp")]
        public int? SystolicBp { get; set; }

        [Column("diastolic_bp")]
        public int? DiastolicBp { get; set; }

        [Column("heart_rate")]
        public int? HeartRate { get; set; }

        [Column("temperature")]
        public decimal? Temperature { get; set; }

        [Column("oxygen_saturation")]
        public int? OxygenSaturation { get; set; }

        [Column("respiration_rate")]
        public int? RespirationRate { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
