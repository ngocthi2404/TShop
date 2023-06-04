using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using TShop.Model.Abstract;

namespace TShop.Model.Models
{
    [Table("ProductTags")]
    public class ProductTag : Audittable
    {
        [Key]
        public string ProductId { get; set; }
        [Key]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string TagId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }

    }
}
