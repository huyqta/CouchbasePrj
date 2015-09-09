using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using System.Configuration;
using Couchbase.Configuration.Client;

namespace Core.Couchbase
{
    public static class CouchbaseConfig
    {
        private static ClientConfiguration _config;
        public static Cluster CbCluster;

        public static string CouchbaseBucket = ConfigurationManager.AppSettings["CouchbaseBucket"];

        public static string CouchbaseUser = ConfigurationManager.AppSettings["CouchbaseUser"];

        public static string CouchbasePassword = ConfigurationManager.AppSettings["CouchbasePassword"];

        public static string CouchbaseServer = ConfigurationManager.AppSettings["CouchbaseServer"];

        public static ClientConfiguration ClientConfiguration
        {
            get
            {
                List<Uri> listServer = new List<Uri>();
                foreach (var server in CouchbaseServer.Split(';'))
                {
                    listServer.Add(new Uri(server));
                }
                if (_config == null)
                {
                    var config = new ClientConfiguration
                    {
                        Servers = listServer,
                        UseSsl = false,
                        DefaultOperationLifespan = 1000,

                        BucketConfigs = new Dictionary<string, BucketConfiguration>
                        {
                            {"default", new BucketConfiguration
                                {
                                    BucketName = "default",
                                    UseSsl = false,
                                    Password = "",
                                    DefaultOperationLifespan = 2000,
                                    PoolConfiguration = new PoolConfiguration
                                    {
                                        MaxSize = 10,
                                        MinSize = 5,
                                        SendTimeout = 12000
                                    }
                                }
                            }
                        }
                    };
                    return config;
                }
                else
                {
                    return _config;
                }
            }
        }

        public static Cluster Cluster
        {
            get
            {
                var cluster = new Cluster();
                return new Cluster("couchbaseClients/couchbase");
            }
        }
    }
}
