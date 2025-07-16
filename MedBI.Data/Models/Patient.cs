using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{
    [Table("Patients")]
    public class Patient
    {
        [Key]
        [Column("PatientId")]
        public int PatientId { get; set; }

        [Required]
        [Column("FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        public string LastName { get; set; }

        [Required]
        [Column("DateOfBirth", TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Column("Gender")]
        public string? Gender { get; set; }

        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Column("Email")]
        public string Email { get; set; }

        [Column("medical_history")]
        public string? MedicalHistory { get; set; }

        [Column("UserId")]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? ApplicationUser { get; set; }

        public virtual ICollection<Claim> Claims { get; set; } = new List<Claim>();
        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public virtual ICollection<PatientAllergies> Allergies { get; set; } = new List<PatientAllergies>();
        public virtual ICollection<PatientVitals> Vitals { get; set; } = new List<PatientVitals>();
        public virtual ICollection<PatientChronicConditions> ChronicConditions { get; set; } = new List<PatientChronicConditions>();
        public virtual ICollection<PatientLifestyle> Lifestyle { get; set; } = new List<PatientLifestyle>();
        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public virtual ICollection<Billing> Billings { get; set; } = new List<Billing>();
    }

}
