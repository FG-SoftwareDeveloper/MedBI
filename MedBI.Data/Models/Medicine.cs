using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBI.Data.Models
{
    [Table("Medicine")]
    public class Medicine
    {
        [Key]
        [Column("medicine_id")]
        public int MedicineId { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("brand")]
        public string? Brand { get; set; }

        [Column("type")]
        public string? Type { get; set; }

        [Column("dosage")]
        public string? Dosage { get; set; }

        [Required]
        [Column("stock_quantity")]
        public int StockQuantity { get; set; }

        [Column("expiry_date", TypeName = "date")]
        public DateTime? ExpiryDate { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("PharmacyId")]
        public int? PharmacyId { get; set; }

        [ForeignKey("PharmacyId")]
        public virtual Pharmacy? Pharmacy { get; set; }
    }


}
