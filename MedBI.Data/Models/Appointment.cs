using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedBI.Data.Models
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("AppointmentDate")]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("Status")]
        public string Status { get; set; }

        [Required]
        [Column("PatientId")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Column("doctor_id")]
        public int? DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
    }

}
