using System.Collections.Generic;
using System.Linq;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.ResponseParsers
{
    internal class DatabaseResponseParser : IDatabaseResponseParser
    {
        public virtual IEnumerable<Database> GetDatabases(IEnumerable<Serie> series)
        {
            var databases = new List<Database>();

            if (series == null)
                return databases;

            databases.AddRange(series.Single().Values.Select(p => new Database()
            {
                Name = (string)p[0]
            }));

            return databases;
        }
    }
}
