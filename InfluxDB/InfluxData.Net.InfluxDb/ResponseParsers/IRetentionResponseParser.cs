using System.Collections.Generic;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.ResponseParsers
﻿{
    public interface IRetentionResponseParser
    {
        IEnumerable<RetentionPolicy> GetRetentionPolicies(string dbName, IEnumerable<Serie> series);
    }
}
