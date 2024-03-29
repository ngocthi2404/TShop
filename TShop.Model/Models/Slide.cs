﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using TShop.Model.Abstract;

namespace TShop.Model.Models
{
    [Table("Slides")]
    public class Slide 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
        [MaxLength(256)]
        public string Description { get; set; }
        [MaxLength(256)]
        public string Image { get; set; }
        [MaxLength(256)]
        public string URL { get; set; }
        public int? DisplayOrder { get; set; }
        public bool Status { get; set; }
        public int? ViewCount { get; set; }
    }
}
