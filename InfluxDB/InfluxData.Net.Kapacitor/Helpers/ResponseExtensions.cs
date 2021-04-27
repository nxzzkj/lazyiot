using Temporal.Net.Common.Helpers;
using Temporal.Net.Common.Infrastructure;
using Temporal.Net.InfluxData.Helpers;
using Temporal.Net.Kapacitor.Models.Responses;

namespace Temporal.Net.Kapacitor.Helpers
{
    public static class ResponseExtensions
    {
        public static IInfluxDataApiResponse ValidateTaskResponse(this IInfluxDataApiResponse response, bool throwOnWarning)
        {
            response.ReadAs<KapacitorTasks>().Validate(throwOnWarning);
            return response;
        }

        public static KapacitorTasks Validate(this KapacitorTasks kapacitorTask, bool throwOnWarning)
        {
            // TODO: implement kapacitor task warning validation

            //Common.Helpers.Validate.IsNotNull(kapacitorTask, "queryResponse");
            //Common.Helpers.Validate.IsNotNull(kapacitorTask.Results, "queryResponse.Results");

            //if (kapacitorTask.Error != null)
            //{
            //    throw new InfluxDataApiException(HttpStatusCode.BadRequest, kapacitorTask.Error);
            //}

            //if (throwOnWarning)
            //{
            //    var warningMessage = kapacitorTask
            //        .Results?
            //        .FirstOrDefault(p => p.Messages != null)?
            //        .Messages?
            //        .FirstOrDefault(p => p.Level == "warning");
            //    if (warningMessage != null)
            //        throw new InfluxDataWarningException(warningMessage.Text);
            //}

            //// Apparently a 200 OK can return an error in the results
            //// https://github.com/influxdb/influxdb/pull/1813
            //var erroredResult = kapacitorTask.Results.FirstOrDefault(result => result.Error != null);
            //if (erroredResult != null)
            //    throw new InfluxDataApiException(HttpStatusCode.BadRequest, erroredResult.Error);

            return kapacitorTask;
        }
    }
}