using System.Collections.Generic;
using System.Threading.Tasks;
using Temporal.Net.Common.Infrastructure;
using Temporal.Net.InfluxDb.Models.Responses;
using Temporal.Net.InfluxDb.QueryBuilders;
using Temporal.Net.InfluxDb.RequestClients;
using Temporal.Net.InfluxDb.ResponseParsers;

namespace Temporal.Net.InfluxDb.ClientModules
{
    public class DatabaseClientModule : ClientModuleBase, IDatabaseClientModule
    {
        private readonly IDatabaseQueryBuilder _databaseQueryBuilder;
        private readonly IDatabaseResponseParser _databaseResponseParser;

        public DatabaseClientModule(IInfluxDbRequestClient requestClient, IDatabaseQueryBuilder databaseQueryBuilder, IDatabaseResponseParser databaseResponseParser)
            : base(requestClient)
        {
            _databaseQueryBuilder = databaseQueryBuilder;
            _databaseResponseParser = databaseResponseParser;
        }

        public virtual async Task<IInfluxDataApiResponse> CreateDatabaseAsync(string dbName)
        {
            var query = _databaseQueryBuilder.CreateDatabase(dbName);
            var response = await base.PostAndValidateQueryAsync(query).ConfigureAwait(false);

            return response;
        }

        public virtual async Task<IEnumerable<Database>> GetDatabasesAsync()
        {
            var query = _databaseQueryBuilder.GetDatabases();
            var series = await base.ResolveSingleGetSeriesResultAsync(query).ConfigureAwait(false);
            var databases = _databaseResponseParser.GetDatabases(series);

            return databases;
        }

        public virtual async Task<IInfluxDataApiResponse> DropDatabaseAsync(string dbName)
        {
            var query = _databaseQueryBuilder.DropDatabase(dbName);
            var response = await base.PostAndValidateQueryAsync(query).ConfigureAwait(false);

            return response;
        }
    }
}
