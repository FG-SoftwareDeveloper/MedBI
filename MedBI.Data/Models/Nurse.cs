using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{
    [Table("Nurses")]
    public class Nurse
    {
        [Key]
        [Column("nurse_id")]
        public int Id { get; set; }

        [Required]
        [Column("staff_id")]
        public int Staff_Id { get; set; }

        [Column("specialization")]
        public string? Specialization { get; set; }

        [Column("shift_hours")]
        public int ShiftHours { get; set; }

        [Column("FullName")]
        public string? FullName { get; set; }

        [Column("Department")]
        public string? Department { get; set; }

        [Column("UserId")]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }


}
