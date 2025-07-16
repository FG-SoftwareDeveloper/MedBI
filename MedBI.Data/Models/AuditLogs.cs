using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBI.Data.Models
{
    [Table("AuditLogs")]
    public class AuditLogs
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("UserId")]
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [Required]
        [Column("Event")]
        public string Event { get; set; }

        [Required]
        [Column("Timestamp")]
        public DateTime Timestamp { get; set; }

        [Column("DataJson")]
        public string? DataJson { get; set; }

        [Column("IPAddress")]
        public string? IPAddress { get; set; }

        [Column("BrowserInfo")]
        public string? BrowserInfo { get; set; }
    }

}
