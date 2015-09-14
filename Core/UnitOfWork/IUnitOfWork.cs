using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Dispose(bool disposing);
        

        //private bool disposed = false;

            ///// <summary>
            ///// Protected Virtual Dispose method
            ///// </summary>
            ///// <param name="disposing"></param>
            //protected virtual void Dispose(bool disposing)
            //{
            //    if (!this.disposed)
            //    {
            //        if (disposing)
            //        {
            //            Debug.WriteLine("UnitOfWork is being disposed");
            //            _context.Dispose();
            //        }
            //    }
            //    this.disposed = true;
            //}

            ///// <summary>
            ///// Dispose method
            ///// </summary>
            //public void Dispose()
            //{
            //    Dispose(true);
            //    GC.SuppressFinalize(this);
            //}
    }
}
