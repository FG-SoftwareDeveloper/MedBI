using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models;

public class Claim
{
    public int ClaimId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    public required string Diagnosis { get; set; }
    public required string ProcedureCode { get; set; }
    public required string Status { get; set; }
    public DateTime DateOfService { get; set; }

    public int DoctorId { get; set; }
    public int PatientId { get; set; }

    public virtual Doctor? Doctor { get; set; }
    public virtual Patient? Patient { get; set; }
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
