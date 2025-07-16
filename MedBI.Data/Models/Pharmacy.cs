using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBI.Data.Models
{
    [Table("Pharmacy")]
    public class Pharmacy
    {
        [Key]
        [Column("pharmacy_id")]
        public int PharmacyId { get; set; }

        [Required]
        [Column("medicine_id")]
        public int MedicineId { get; set; }

        [ForeignKey("MedicineId")]
        public Medicine Medicine { get; set; }

        [Required]
        [Column("patient_id")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("prescription_date")]
        public DateTime PrescriptionDate { get; set; } = DateTime.Now;
    }

}
