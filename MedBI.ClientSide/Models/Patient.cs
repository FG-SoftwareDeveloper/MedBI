using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.ClientSide.Models
{
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

       
    }
}
