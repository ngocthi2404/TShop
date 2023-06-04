using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TShop.Model.Models
{
    [Table("VisitorStatistics")]
    public class VisitorStatistic
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(50)]
        public string IPAddress { get; set; }

        [Required]
        public DateTime VisitedDate { get; set; }
    }
}
