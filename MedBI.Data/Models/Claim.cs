using System;
using System.Collections.Generic;

namespace MedBI.Data.Models;

public class Claim
{
    public int ClaimId { get; set; }
    public decimal Amount { get; set; }
    public string Diagnosis { get; set; }
    public string ProcedureCode { get; set; }
    public string Status { get; set; }
    public DateTime DateOfService { get; set; }

    public int DoctorId { get; set; }
    public int PatientId { get; set; }

    public virtual Doctor? Doctor { get; set; }
    public virtual Patient? Patient { get; set; }
    public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
}
