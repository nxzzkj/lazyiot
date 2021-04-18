using Temporal.Net.Kapacitor.ClientModules;
using Temporal.Net.Kapacitor.RequestClients;

namespace Temporal.Net.Kapacitor.Infrastructure
{
    /// <summary>
    /// Container class which holds resolved InfluxDbClient dependencies based on 'InfluxDbVersion'.
    /// </summary>
    internal class KapacitorClientDependencies
    {
        public IKapacitorRequestClient KapacitorRequestClient { get; set; }

        public ITaskClientModule TaskClientModule { get; set; }
    }
}
