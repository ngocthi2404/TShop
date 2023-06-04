using System;
using System.ComponentModel.DataAnnotations;

namespace TShop.Model.Abstract
{
    public abstract class Audittable : IAuditable
    {
        public DateTime CreatedDate { get; set; }
        [MaxLength(256)]
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(256)]
        public string UpdateBy { get; set; }
        [MaxLength(256)]
        public string MetaKeywork { get; set; }
        [MaxLength(256)]
        public string MetaDescription { get; set; }
        public bool Status { get; set; }


    }
}
