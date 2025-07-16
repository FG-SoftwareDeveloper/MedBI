using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{
    [Table("SystemLogs")]
    public class SystemLogs
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [Required]
        [Column("LogLevel")]
        [MaxLength(50)]
        public required string LogLevel { get; set; }

        [Required]
        [Column("Message")]
        public required string Message { get; set; }

        [Column("Exception")]
        public string? Exception { get; set; }

        [Column("StackTrace")]
        public string? StackTrace { get; set; }

        [Column("UserId")]
        [MaxLength(450)]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }

}
