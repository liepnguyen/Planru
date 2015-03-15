using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planru.Core.Persistence.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// The default key MongoRepository will look for in the App.config or Web.config file.
        /// </summary>
        private const string DefaultConnectionstringName = "MongoServerSettings";

        /// <summary>
        /// Gets the default connection string loaded from the App.config or Web.config file.
        /// </summary>
        /// <returns>The default connection string</returns>
        public static string GetDefaultConnectionString()
        {
            return ConfigurationManager
                .ConnectionStrings[DefaultConnectionstringName].ConnectionString;
        }
    }
}
