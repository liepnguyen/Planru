using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Planru.Core.Persistence.MongoDB
{
    public class MongoSessionFactory : IMongoSessionFactory
    {
        /// <summary>
        /// Gets the connection string
        /// </summary>
        public string ConnectionString { get; private set; }

        public MongoSessionFactory(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException("connectionString");

            this.ConnectionString = connectionString;
        }

        public MongoDatabase OpenConnection(string databaseName)
        {
            throw new NotImplementedException();
        }
    }
}
