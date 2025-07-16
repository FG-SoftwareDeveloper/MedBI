using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{

    [Table("Documents")]
    public class Document
    {
        [Key]
        [Column("DocumentId")]
        public int DocumentId { get; set; }

        [Required]
        [Column("FileName")]
        public string FileName { get; set; }

        [Required]
        [Column("ContentType")]
        public string ContentType { get; set; }

        [Required]
        [Column("FileSize")]
        public long FileSize { get; set; }

        [Column("FileData")]
        public byte[]? FileData { get; set; }

        [Required]
        [Column("UploadedOn")]
        public DateTime UploadedOn { get; set; } = DateTime.Now;

        [Column("PatientId")]
        public int? PatientId { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient? Patient { get; set; }

        [Column("ClaimId")]
        public int? ClaimId { get; set; }

        [ForeignKey("ClaimId")]
        public virtual Claim? Claim { get; set; }

        [Column("DoctorId")]
        public int? DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor? Doctor { get; set; }
    }

}
