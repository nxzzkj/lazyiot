using System.Net.Http;
using System.Threading.Tasks;
using Temporal.Net.Common.Infrastructure;
using Temporal.Net.InfluxDb.Constants;
using Temporal.Net.InfluxDb.Infrastructure;
using Temporal.Net.InfluxDb.Formatters;

namespace Temporal.Net.InfluxDb.RequestClients
{
    public class InfluxDbRequestClient_v_1_0_0 : InfluxDbRequestClient
    {
        public InfluxDbRequestClient_v_1_0_0(IInfluxDbClientConfiguration configuration)
            : base(configuration)
        {
        }

        public override async Task<IInfluxDataApiResponse> QueryAsync(string query, HttpMethod method, string dbName = null, string epochFormat = null, long? chunkSize = null)
        {
            var requestParams = RequestParamsBuilder.BuildQueryRequestParams(query, dbName, epochFormat, chunkSize);

            return await base.RequestAsync(method, RequestPaths.Query, requestParams).ConfigureAwait(false);
        }

        public override IPointFormatter GetPointFormatter()
        {
            return new PointFormatter_v_1_0_0();
        }
    }
}