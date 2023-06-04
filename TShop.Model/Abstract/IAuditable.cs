using System;

namespace TShop.Model.Abstract
{
    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateBy{ get; set; }
        string MetaKeywork { get; set; }
        string MetaDescription { get; set; }
        bool Status { get; set; }
    }
}
