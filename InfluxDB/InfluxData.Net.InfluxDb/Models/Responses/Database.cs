namespace Temporal.Net.InfluxDb.Models.Responses
{
    /// <summary>
    /// Represents <see cref="{Database}"/> query response.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// Database name.
        /// </summary>
        public string Name { get; set; }
    }
}