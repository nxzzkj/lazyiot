using System.Collections.Generic;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.ResponseParsers
{
    public interface IDatabaseResponseParser
    {
        IEnumerable<Database> GetDatabases(IEnumerable<Serie> series);
    }
}
