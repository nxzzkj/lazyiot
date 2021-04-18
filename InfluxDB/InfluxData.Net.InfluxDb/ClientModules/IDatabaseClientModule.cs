using System.Collections.Generic;
using System.Threading.Tasks;
using Temporal.Net.Common.Infrastructure;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.ClientModules
{
    public interface IDatabaseClientModule
    {
        /// <summary>
        /// Creates a new Database.
        /// </summary>
        /// <param name="dbName">The name of the new database</param>
        /// <returns></returns>
        Task<IInfluxDataApiResponse> CreateDatabaseAsync(string dbName);

        /// <summary>
        /// Gets all available databases.
        /// </summary>
        /// <returns>A collection of all databases.</returns>
        Task<IEnumerable<Database>> GetDatabasesAsync();

        /// <summary>
        /// Drops a database.
        /// </summary>
        /// <param name="dbName">The name of the database to delete.</param>
        /// <returns></returns>
        Task<IInfluxDataApiResponse> DropDatabaseAsync(string dbName);
    }
}