using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planru.DistributedServices.WebAPI
{
    public class MongoDbConfig
    {
        private static Lazy<MongoDatabase> _database = new Lazy<MongoDatabase>(() =>
        {
            //var credential = MongoCredential.CreateMongoCRCredential("planru_system", "liepnguyen", "@dmin348");

            //var settings = new MongoClientSettings
            //{
            //    Credentials = new[] { credential },
            //    Server = new MongoServerAddress("localhost", 27017)
            //};

            //var client = new MongoClient(settings);
            //var server = client.GetServer();
            //var database = server.GetDatabase("planru_system");

            var credential = MongoCredential.CreateMongoCRCredential("planru_system", "liepnguyen", "@dmin348");

            var settings = new MongoClientSettings
            {
                Credentials = new[] { credential },
                Server = new MongoServerAddress("ds055680.mongolab.com", 55680)
            };

            var client = new MongoClient(settings);
            var server = client.GetServer();
            var database = server.GetDatabase("planru_system");

            return database;
        });

        public static MongoDatabase GetMongoDbDatabase()
        {
            return _database.Value;
        }
    }
}