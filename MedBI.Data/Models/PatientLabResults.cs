using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBI.Data.Models
{
    [Table("Patient_LabResults")]
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
