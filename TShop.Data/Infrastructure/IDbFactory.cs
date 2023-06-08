using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        TShopDbContext Init();
    }
}
