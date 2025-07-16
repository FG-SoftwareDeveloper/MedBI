using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{

    [Table("Doctors")]
    public class Doctor
    {
        [Key]
        [Column("DoctorId")]
        public int DoctorId { get; set; }

        [Required]
        [Column("FirstName")]
        public required string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        public required string LastName { get; set; }

        [Column("Specialty")]
        public string? Specialty { get; set; }

        [Required]
        [Column("Email")]
        public required string Email { get; set; }

        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [Column("available_schedule")]
        public string? AvailableSchedule { get; set; }

        [Column("UserId")]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }

}
