   using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence.MongoDB
{
    public interface IMongoDbContext
    {
        /// <summary>
        /// Gets the collection of the specified entity type
        /// </summary>
        /// <typeparam name="T">The type of entity</typeparam>
        /// <returns>The mongo collection</returns>
        MongoCollection<T> GetCollection<T>();
    }
}
