using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Planru.Core.Configuration.Annotations;
using System.Configuration;

namespace Planru.Core.Persistence.MongoDB
{
    /// <summary>
    /// Represent for the implementation of <see cref="IMongoDbContext"/> interface.
    /// </summary>
    public class MongoDbContext : IMongoDbContext
    {
        /// <summary>
        /// Gets the connection string
        /// </summary>
        public string ConnectionString { get; private set; }

        /// <summary>
        /// Gets the mongo database
        /// </summary>
        public MongoDatabase Database { get; private set; }

        /// <summary>
        /// Gets the mongo client
        /// </summary>
        public MongoClient Client { get; private set; }

        /// <summary>
        /// Gets the mongo server
        /// </summary>
        public MongoServer Server { get; private set; }

        /// <summary>
        /// Initializes for a new instance of the <see cref="MongoDbContext"/> class with the specified parameters.
        /// </summary>
        public MongoDbContext(string databaseName)
            : this(Util.GetDefaultConnectionString(), databaseName)
        { 
        }

        /// <summary>
        /// Initializes for a new instance of the <see cref="MongoDbContext"/> class with the specified parameters.
        /// </summary>
        /// <param name="connectionString"></param>
        public MongoDbContext(string connectionString, string databaseName)
        {
            this.ConnectionString = connectionString;

            this.Client = new MongoClient(connectionString);
            this.Server = this.Client.GetServer();
            this.Database = Server.GetDatabase(databaseName);
        }

        /// <inheritdoc/>
        public MongoCollection<T> GetCollection<T>()
        {
            return this.Database.GetCollection<T>(this.GetCollectionName<T>());
        }

        /// <summary>
        /// Gets the collection name of the specifiedentity type
        /// </summary>
        /// <typeparam name="T">The type of entity</typeparam>
        /// <returns>The collection name</returns>
        private string GetCollectionName<T>()
        {
            var collectionAttr = ((CollectionAttribute)typeof(T).GetCustomAttributes(true)
                    .FirstOrDefault(attr => attr.GetType() == typeof(CollectionAttribute)));
            return collectionAttr != null ? collectionAttr.Name : typeof(T).Name;
        }   
    }
}
