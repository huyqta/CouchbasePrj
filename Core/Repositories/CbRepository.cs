using Core.Couchbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class CbRepository
    {
        public void InitCouchbase()
        {
            if (CouchbaseConfig.CbCluster == null)
            {
                //var listUri = CouchbaseConfig.CouchbaseServer.Split('|').ToList();
                //CouchbaseConfig.CbCluster.Configuration.Servers = listUri.ToList<Uri>();

            }
        }
    }
}
