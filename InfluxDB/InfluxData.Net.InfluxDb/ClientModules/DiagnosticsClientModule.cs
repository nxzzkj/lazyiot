using System.Net.Http;
using System.Threading.Tasks;
using Temporal.Net.Common.Helpers;
using Temporal.Net.InfluxDb.Constants;
using Temporal.Net.InfluxDb.Models.Responses;
using Temporal.Net.InfluxDb.QueryBuilders;
using Temporal.Net.InfluxDb.RequestClients;
using Temporal.Net.InfluxDb.ResponseParsers;

namespace Temporal.Net.InfluxDb.ClientModules
{
    public class DiagnosticsClientModule : ClientModuleBase, IDiagnosticsClientModule
    {
        private readonly IDiagnosticsQueryBuilder _diagnosticsQueryBuilder;
        private readonly IDiagnosticsResponseParser _diagnosticsResponseParser;

        public DiagnosticsClientModule(IInfluxDbRequestClient requestClient, IDiagnosticsQueryBuilder diagnosticsQueryBuilder, IDiagnosticsResponseParser diagnosticsResponseParser)
            : base(requestClient)
        {
            _diagnosticsQueryBuilder = diagnosticsQueryBuilder;
            _diagnosticsResponseParser = diagnosticsResponseParser;
        }

        public virtual async Task<Pong> PingAsync()
        {
            var watch = Stopwatch.StartNew();
            var response = await base.RequestClient.RequestAsync(HttpMethod.Get, RequestPaths.Ping, includeAuthToQuery: false, headerIsBody: true).ConfigureAwait(false);

            watch.Stop();

            var pong = new Pong
            {
                Version = response.Body,
                ResponseTime = watch.Elapsed,
                Success = true
            };

            return pong;
        }

        public virtual async Task<Stats> GetStatsAsync()
        {
            var query = _diagnosticsQueryBuilder.GetStats();
            var series = await base.ResolveSingleGetSeriesResultAsync(query).ConfigureAwait(false);
            var stats = _diagnosticsResponseParser.GetStats(series);

            return stats;
        }

        public virtual async Task<Diagnostics> GetDiagnosticsAsync()
        {
            var query = _diagnosticsQueryBuilder.GetDiagnostics();
            var series = await base.ResolveSingleGetSeriesResultAsync(query).ConfigureAwait(false);
            var diagnostics = _diagnosticsResponseParser.GetDiagnostics(series);

            return diagnostics;
        }
    }
}
