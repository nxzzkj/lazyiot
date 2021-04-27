using System.Collections.Generic;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.ResponseParsers
{
    public interface IBasicResponseParser
    {
        IEnumerable<Serie> FlattenResultsSeries(IEnumerable<SeriesResult> seriesResults);

        IEnumerable<IEnumerable<Serie>> MapResultsSeries(IEnumerable<SeriesResult> seriesResults);
    }
}
