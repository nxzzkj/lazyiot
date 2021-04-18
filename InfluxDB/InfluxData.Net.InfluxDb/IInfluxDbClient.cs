using Temporal.Net.InfluxDb.ClientModules;
using Temporal.Net.InfluxDb.RequestClients;

namespace Temporal.Net.InfluxDb
{
    // NOTE: potential "regions/classes": https://docs.influxdata.com/influxdb/v0.9/query_language/

    public interface IInfluxDbClient
    {
        IBasicClientModule Client { get; }

        ISerieClientModule Serie { get; }

        IDatabaseClientModule Database { get; }

        IRetentionClientModule Retention { get; }

        ICqClientModule ContinuousQuery { get; }

        IDiagnosticsClientModule Diagnostics { get; }

        IUserClientModule User { get; }

        IInfluxDbRequestClient RequestClient { get; }
    }
}