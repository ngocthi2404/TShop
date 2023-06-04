using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShop.Model.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerName { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerAddress { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerEmail { get; set; }
        [Required]
        [MaxLength(256)]
        public string CustomerMessage { get; set; }
        [Required]
        [MaxLength(256)]
        public string PaymentMethod { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy{ get; set; }
        public string PaymentStatus{ get; set; }
        public bool Status{ get; set; }
        public virtual IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
