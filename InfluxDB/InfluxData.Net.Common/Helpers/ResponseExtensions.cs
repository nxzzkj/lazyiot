using Newtonsoft.Json;
using Temporal.Net.Common.Infrastructure;

namespace Temporal.Net.InfluxData.Helpers
{
    public static class ResponseExtensionsBase
    {
        public static T ReadAs<T>(this IInfluxDataApiResponse response)
        {
            return response.Body.ReadAs<T>();
        }

        public static T ReadAs<T>(this string responseBody)
        {
            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}