using Couchbase;
using Couchbase.Configuration.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Couchbase
{
    public static class CouchbaseMain
    {
        private static Cluster cluster;

        public static string Test()
        {
            using (cluster = new Cluster(CouchbaseConfiguration.CBConfig))
            {

                using (var bucket = cluster.OpenBucket())
                {
                    var document = new Document<dynamic>
                    {
                        Id = "Hello2",
                        Content = new
                        {
                            name = "Couchbase"
                        }
                    };

                    var upsert = bucket.Upsert(document);
                    if (upsert.Success)
                    {
                        var get = bucket.GetDocument<dynamic>(document.Id);
                        document = get.Document;
                        return document.Id + " " + document.Content.name;
                    }
                }
            }

            return "";
        }
    }
}
