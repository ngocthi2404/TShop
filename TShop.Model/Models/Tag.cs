using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TShop.Model.Models
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [ForeignKey("PostId")]

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }
    }
}
