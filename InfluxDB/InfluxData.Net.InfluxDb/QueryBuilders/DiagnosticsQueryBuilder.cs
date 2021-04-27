using Temporal.Net.InfluxDb.Constants;

namespace Temporal.Net.InfluxDb.QueryBuilders
{
    internal class DiagnosticsQueryBuilder : IDiagnosticsQueryBuilder
    {
        public virtual string GetStats()
        {
            return QueryStatements.GetStats;
        }

        public virtual string GetDiagnostics()
        {
            return QueryStatements.GetDiagnostics;
        }
    }
}
