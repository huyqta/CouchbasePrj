using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using System.Configuration;

namespace Core.Couchbase
{
    public static class CouchbaseConfig
    {
        public static Cluster CbCluster;

        public static string CouchbaseBucket = ConfigurationManager.AppSettings["CouchbaseBucket"];

        public static string CouchbaseUser = ConfigurationManager.AppSettings["CouchbaseUser"];

        public static string CouchbasePassword = ConfigurationManager.AppSettings["CouchbasePassword"];

        public static string CouchbaseServer = ConfigurationManager.AppSettings["CouchbaseServer"];
    }
}
