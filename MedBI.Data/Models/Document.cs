using System;

namespace MedBI.Data.Models;

public class Document
{
    public int DocumentId { get; set; }
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public DateTime UploadedOn { get; set; } = DateTime.Now;

    public int? ClaimId { get; set; }
    public int? DoctorId { get; set; }
    public int? PatientId { get; set; }

    public virtual Claim Claim { get; set; }
    public virtual Doctor Doctor { get; set; }
    public virtual Patient Patient { get; set; }
}
