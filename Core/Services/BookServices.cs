using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Collection;

namespace Core.Services
{
    public class BookServices : IBookServices
    {
        private UnitOfWork.UnitOfWork uow;

        public BookServices()
        {
            uow = new UnitOfWork.UnitOfWork("default");
        }
        public void InsertBook(Book book)
        {
            uow.CbRepository<Book>().Insert(book);
        }
    }
}
