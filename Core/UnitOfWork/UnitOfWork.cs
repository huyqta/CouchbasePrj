using Core.Repositories;
using System;
using Entity.Collection;
using System.Collections.Generic;
using Couchbase.Core;

namespace Core.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private Dictionary<string, object> repositories;
        private bool disposed;

        public UnitOfWork(string bucket)
        {
            //if (Couchbase.CouchbaseConfig.Bucket == null)
            //{
            //    Couchbase.CouchbaseConfig.Cluster.OpenBucket(bucket);
            //}
        }

        public CbRepository<T> CbRepository<T>() where T : BaseEntity
        {
            if (repositories == null)
            {
                repositories = new Dictionary<string, object>();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(CbRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)));
                repositories.Add(type, repositoryInstance);
            }
            return (CbRepository<T>)repositories[type];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Couchbase.CouchbaseConfig.Cluster.CloseBucket(Couchbase.CouchbaseConfig.Bucket);
                }
            }
            disposed = true;
        }
    }
}
