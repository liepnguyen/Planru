using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence.MongoDB
{
    public interface IMongoSessionFactory
    {
        /// <summary>
        /// Opens a connection to connection to the specified database.
        /// </summary>
        /// <param name="databaseName">The database name</param>
        /// <returns></returns>
        MongoDatabase OpenConnection(string databaseName);
    }
}
