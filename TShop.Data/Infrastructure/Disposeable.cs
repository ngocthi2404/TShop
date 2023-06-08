using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TShop.Data.Infrastructure
{
    public class Disposeable : IDisposable
    {
        private bool IsDisposed;
        ~Disposeable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                DisposeCore();
            }
            IsDisposed = true;
        }

        protected virtual void DisposeCore()
        {

        }
    }
}
