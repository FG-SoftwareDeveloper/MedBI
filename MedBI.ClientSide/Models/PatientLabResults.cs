using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.ClientSide.Models
{
    public class PatientLabResults
    {
        [Key]
        [Column("lab_result_id")]
        public int LabResultId { get; set; }

        [Required]
        [Column("test_name")]
        public string TestName { get; set; }

        [Column("result_value")]
        public string? ResultValue { get; set; }

        [Column("unit")]
        public string? Unit { get; set; }

        [Column("reference_range")]
        public string? ReferenceRange { get; set; }

        [Required]
        [Column("result_date")]
        public DateTime ResultDate { get; set; } = DateTime.Now;

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
    }
}
