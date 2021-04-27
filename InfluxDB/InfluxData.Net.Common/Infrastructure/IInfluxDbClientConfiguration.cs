using Temporal.Net.Common.Enums;

namespace Temporal.Net.Common.Infrastructure
{
    public interface IInfluxDbClientConfiguration : IConfiguration
    {
        /// <summary>
        /// InfluxDb server version.
        /// </summary>
        InfluxDbVersion InfluxVersion { get; }

        /// <summary>
        /// Where queries are located in the request (URI params vs. Form Data).
        /// </summary>
        QueryLocation QueryLocation { get; }
    }
}