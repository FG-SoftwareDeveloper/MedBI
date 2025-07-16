using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models;

[Table("Claims")]
public class Claim
{
    [Key]
    [Column("ClaimId")]
    public int ClaimId { get; set; }

    [Required]
    [Column("PatientId")]
    public int PatientId { get; set; }

    [Required]
    [Column("DoctorId")]
    public int DoctorId { get; set; }

    [Required]
    [Column("Diagnosis")]
    public required string Diagnosis { get; set; }

    [Required]
    [Column("ProcedureCode")]
    public required string ProcedureCode { get; set; }

    [Required]
    [Column("Amount", TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }

    [Required]
    [Column("Status")]
    public required string Status { get; set; }

    [Required]
    [Column("DateOfService", TypeName = "date")]
    public DateTime DateOfService { get; set; }

    [ForeignKey("DoctorId")]
    public virtual Doctor? Doctor { get; set; }

    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }

    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}

