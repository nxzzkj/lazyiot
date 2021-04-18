using System.Collections.Generic;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.ResponseParsers
{
    public interface ICqResponseParser
    {
        IEnumerable<ContinuousQuery> GetContinuousQueries(string dbName, IEnumerable<Serie> series);
    }
}
