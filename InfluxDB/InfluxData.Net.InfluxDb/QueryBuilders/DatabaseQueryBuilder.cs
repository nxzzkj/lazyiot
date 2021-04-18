using System;
using Temporal.Net.InfluxDb.Constants;

namespace Temporal.Net.InfluxDb.QueryBuilders
{
    internal class DatabaseQueryBuilder : IDatabaseQueryBuilder
    {
        public virtual string CreateDatabase(string dbName)
        {
            var query = String.Format(QueryStatements.CreateDatabase, dbName);

            return query;
        }

        public virtual string GetDatabases()
        {
            return QueryStatements.GetDatabases;
        }

        public virtual string DropDatabase(string dbName)
        {
            var query = String.Format(QueryStatements.DropDatabase, dbName);

            return query;
        }
    }
}
