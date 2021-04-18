using Temporal.Net.Common.Constants;
using Temporal.Net.InfluxDb.Models;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.Formatters
{
    public interface IPointFormatter
    {
        string PointToString(Point point, string precision = TimeUnit.Milliseconds);

        Serie PointToSerie(Point point);
    }
}