using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedBI.Data.Models
{
    [Table("ErrorLogs")]
    public class ErrorLogs
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        [Column("Path")]
        public string? Path { get; set; }

        [Column("QueryString")]
        public string? QueryString { get; set; }

        [Required]
        [Column("Message")]
        public required string Message { get; set; }

        [Column("StackTrace")]
        public string? StackTrace { get; set; }

        [Column("UserId")]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }

}
