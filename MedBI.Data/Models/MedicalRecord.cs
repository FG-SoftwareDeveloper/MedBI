using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{
    [Table("Medical_Records")]
    public class MedicalRecord
    {
        [Key]
        [Column("record_id")]
        public int RecordId { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Required]
        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [Column("appointment_id")]
        public int? AppointmentId { get; set; }

        [ForeignKey("AppointmentId")]
        public Appointment? Appointment { get; set; }

        [Required]
        [Column("diagnosis")]
        public string Diagnosis { get; set; }

        [Column("prescription")]
        public string? Prescription { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
