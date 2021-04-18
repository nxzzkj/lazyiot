using System.Linq;
using System.Net;
using Temporal.Net.Common.Infrastructure;
using Temporal.Net.InfluxData.Helpers;
using Temporal.Net.InfluxDb.Helpers;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.Helpers
{
    public static class ResponseExtensions
    {
        public static IInfluxDataApiResponse ValidateQueryResponse(this IInfluxDataApiResponse response, bool throwOnWarning)
        {
            response.ReadAs<QueryResponse>().Validate(throwOnWarning);
            return response;
        }

        public static QueryResponse Validate(this QueryResponse queryResponse, bool throwOnWarning)
        {
            Common.Helpers.Validate.IsNotNull(queryResponse, "queryResponse");
            Common.Helpers.Validate.IsNotNull(queryResponse.Results, "queryResponse.Results");

            if (queryResponse.Error != null)
            {
                throw new InfluxDataApiException(HttpStatusCode.BadRequest, queryResponse.Error);
            }

            if (throwOnWarning)
            {
                var warningMessage = queryResponse
                    .Results?
                    .FirstOrDefault(p => p.Messages != null)?
                    .Messages?
                    .FirstOrDefault(p => p.Level == "warning");
                if (warningMessage != null)
                    throw new InfluxDataWarningException(warningMessage.Text);
            }

            // Apparently a 200 OK can return an error in the results
            // https://github.com/influxdb/influxdb/pull/1813
            var erroredResult = queryResponse.Results.FirstOrDefault(result => result.Error != null);
            if (erroredResult != null)
                throw new InfluxDataApiException(HttpStatusCode.BadRequest, erroredResult.Error);

            return queryResponse;
        }
    }
}