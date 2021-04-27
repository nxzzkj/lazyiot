using System.Collections.Generic;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.ResponseParsers
{
    public interface IDiagnosticsResponseParser
    {
        Stats GetStats(IEnumerable<Serie> series);

        Diagnostics GetDiagnostics(IEnumerable<Serie> series);
    }
}
