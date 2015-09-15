using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Collection;
using Core.Services.Interfaces;

namespace Core.Services
{
    public class PublisherServices : IPublisherServices
    {
        private UnitOfWork.UnitOfWork uow;

        public PublisherServices()
        {
            uow = new UnitOfWork.UnitOfWork("default");
        }
        public void InsertPublisher(Publisher publisher)
        {
            uow.CbRepository<Publisher>().Insert(publisher);
        }
    }
}
