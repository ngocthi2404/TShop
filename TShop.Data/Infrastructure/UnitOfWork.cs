using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShop.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private TShopDbContext dbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public TShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = _dbFactory.Init()); }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }

}
