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
                },
            UseSsl = false,
            BucketConfigs = new Dictionary<string, BucketConfiguration>()
            {
                {
                    "default2", new BucketConfiguration()
                    {
                        BucketName = "default2",
                        UseSsl = false,
                        Password = "",
                        PoolConfiguration = new PoolConfiguration()
                        {
                            MaxSize = 10,
                            MinSize = 5
                        }
                    }
                },
                {
                    "default3", new BucketConfiguration()
                    {
                        BucketName = "default3",
                        UseSsl = false,
                        Password = "",
                        PoolConfiguration = new PoolConfiguration()
                        {
                            MaxSize = 10,
                            MinSize = 5
                        }
                    }
                }
            }
        };
    }
}
