using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedBI.Data.Models
{
    [Table("Messages")]
    public class Message
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("SenderUserId")]
        public string SenderUserId { get; set; }

        [ForeignKey("SenderUserId")]
        public ApplicationUser? Sender { get; set; }

        [Required]
        [Column("RecipientUserId")]
        public string RecipientUserId { get; set; }

        [ForeignKey("RecipientUserId")]
        public ApplicationUser? Recipient { get; set; }

        [Required]
        [Column("Subject")]
        public string Subject { get; set; }

        [Required]
        [Column("Body")]
        public string Body { get; set; }

        [Required]
        [Column("SentDate")]
        public DateTime SentDate { get; set; } = DateTime.Now;

        [Column("ReadDate")]
        public DateTime? ReadDate { get; set; }

        [Required]
        [Column("Status")]
        public string Status { get; set; }
    }
}
