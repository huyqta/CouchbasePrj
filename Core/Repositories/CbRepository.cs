using Core;
using Couchbase;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Entity.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class CbRepository<TEntity> : ICbRepository<TEntity> where TEntity : BaseEntity
    {
        private IBucket iBucket;
        private ClientConfiguration _config;

        public CbRepository()
        {

        }

        public CbRepository(string bucket)
        {


            List<Uri> listServer = new List<Uri>();
            //foreach (var server in CouchbaseServer.Split(';'))
            //{
            listServer.Add(new Uri("http://localhost:8091/pools"));
            //}
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

                using (var cluster = new Cluster(_config))
                {
                    iBucket = cluster.OpenBucket();
                }
            }
        }

        public virtual bool Insert(TEntity doc)
        {
            //List<Uri> listServer = new List<Uri>();
            ////foreach (var server in CouchbaseServer.Split(';'))
            ////{
            //listServer.Add(new Uri("http://localhost:8091/pools"));
            ////}

            //var config = new ClientConfiguration
            //{
            //    Servers = listServer,
            //    UseSsl = false,
            //    //DefaultOperationLifespan = 1000,

            //    BucketConfigs = new Dictionary<string, BucketConfiguration>
            //            {
            //                {"default", new BucketConfiguration
            //                    {
            //                        BucketName = "default",
            //                        UseSsl = false,
            //                        Password = "",
            //                        //DefaultOperationLifespan = 2000,
            //                        PoolConfiguration = new PoolConfiguration
            //                        {
            //                            MaxSize = 10,
            //                            MinSize = 5,
            //                            SendTimeout = 12000
            //                        }
            //                    }
            //                }
            //            }
            //};

            //var cluster = new Cluster(config);

            //var bucket = cluster.OpenBucket();

            var bucket = Couchbase.CouchbaseConfig.Cluster.OpenBucket();

            var result = Couchbase.CouchbaseConfig.Bucket.Insert<TEntity>(doc._id, doc);
            return result.Success;
            //return true;
        }

        public virtual TEntity GetDocument(string id)
        {
            var result = Couchbase.CouchbaseConfig.Bucket.GetDocument<TEntity>(id);
            if (result.Success)
            {
                return result.Content;
            }
            else
            {
                return null;
            }
        }

        public virtual dynamic BulkGetDocument(List<string> ids)
        {
            var result = Couchbase.CouchbaseConfig.Bucket.Get<TEntity>(ids);
            return result;
        }

        public virtual bool Upsert(TEntity doc)
        {
            var result = Couchbase.CouchbaseConfig.Bucket.Upsert<TEntity>(doc._id, doc);
            return result.Success;
        }

        public virtual void BulkUpsert(Dictionary<string, Document<TEntity>> docs)
        {
            var result = Couchbase.CouchbaseConfig.Bucket.Upsert(docs);
        }

        public virtual bool Delete(string id)
        {
            var doc = Couchbase.CouchbaseConfig.Bucket.GetDocument<TEntity>(id);
            var result = Couchbase.CouchbaseConfig.Bucket.Remove<TEntity>(doc.Document);
            return result.Success;
        }

        public virtual IEnumerable<TEntity> QueryViewAll(string designDoc, string view, bool isDevelopement)
        {
            var query = Couchbase.CouchbaseConfig.Bucket.CreateQuery(designDoc, view, isDevelopement).Limit(5);
            var result = Couchbase.CouchbaseConfig.Bucket.Query<TEntity>(query);
            return result.Values;
        }

        public virtual IEnumerable<TEntity> QueryViewLimit(string designDoc, string view, bool isDevelopement, int limit)
        {
            var query = Couchbase.CouchbaseConfig.Bucket.CreateQuery(designDoc, view, isDevelopement).Limit(limit);
            var result = Couchbase.CouchbaseConfig.Bucket.Query<TEntity>(query);
            return result.Values;
        }
    }
}
