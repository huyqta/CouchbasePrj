using Couchbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal Cluster GRCluster;

        public GenericRepository(Cluster cluster)
        {
            this.GRCluster = cluster;
        }

        //public virtual IEnumerable<TEntity> Get()
        //{
            
        //}
    }
}
