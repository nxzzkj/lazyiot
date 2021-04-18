using System.Collections.Generic;
using Temporal.Net.InfluxDb.Models.Responses;

namespace Temporal.Net.InfluxDb.ResponseParsers
{
    public interface IUserResponseParser
    {
        IEnumerable<User> GetUsers(IEnumerable<Serie> series);

        IEnumerable<Grant> GetPrivileges(IEnumerable<Serie> series);
    }
}
