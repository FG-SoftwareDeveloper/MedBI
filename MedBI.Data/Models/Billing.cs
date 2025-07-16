using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{
        [Table("Billing")]
        public class Billing
        {
            [Key]
            [Column("bill_id")]
            public int BillId { get; set; }

            [Required]
            [Column("patient_id")]
            public int PatientId { get; set; }

            [ForeignKey("PatientId")]
            public required Patient Patient { get; set; }

            [Column("appointment_id")]
            public int? AppointmentId { get; set; }   // nullable in DB

            [ForeignKey("AppointmentId")]
            public Appointment? Appointment { get; set; }

            [Required]
            [Column("total_amount", TypeName = "decimal(18,4)")]
            public decimal TotalAmount { get; set; }

            [Required]
            [Column("payment_status")]
            public required string PaymentStatus { get; set; }

            [Column("payment_date")]
            public DateTime? PaymentDate { get; set; }

            [Column("insurance_provider")]
            public string? InsuranceProvider { get; set; }

            [Required]
            [Column("created_at")]
            public DateTime CreatedAt { get; set; }
        }
    }


