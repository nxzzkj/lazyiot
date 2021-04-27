﻿using System.Collections.Generic;
using System.Linq;
using Temporal.Net.Common.Helpers;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.ResponseParsers
{
    internal class BasicResponseParser : IBasicResponseParser
    {
        public virtual IEnumerable<Serie> FlattenResultsSeries(IEnumerable<SeriesResult> seriesResults)
        {
            var series = new List<Serie>();

            foreach (var result in seriesResults)
            {
                series.AddRange(result.Series ?? new List<Serie>());
            }

            return series;
        }

        public virtual IEnumerable<IEnumerable<Serie>> MapResultsSeries(IEnumerable<SeriesResult> seriesResults)
        {
            return seriesResults.Select(GetSeries);
        }

        protected virtual IEnumerable<Serie> GetSeries(SeriesResult result)
        {
            Validate.IsNotNull(result, "result");
            return result.Series != null ? result.Series.ToList() : new List<Serie>();
        }
    }
}
