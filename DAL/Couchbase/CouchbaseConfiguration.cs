using Couchbase.Configuration.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Couchbase
{
    public static class CouchbaseConfiguration
    {
        public static ClientConfiguration CBConfig = new ClientConfiguration()
        {
            Servers = new List<Uri>
                {
                    new Uri("http://localhost:8091/pools")
                }
        };
    }
}
