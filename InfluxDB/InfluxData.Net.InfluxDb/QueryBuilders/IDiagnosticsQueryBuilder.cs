namespace Temporal.Net.InfluxDb.QueryBuilders
{
    public interface IDiagnosticsQueryBuilder
    {
        string GetStats();

        string GetDiagnostics();
    }
}