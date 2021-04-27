using Temporal.Net.Kapacitor.RequestClients;

namespace Temporal.Net.Kapacitor.ClientModules
{
    public class ClientModuleBase
    {
        protected IKapacitorRequestClient RequestClient { get; private set; }

        public ClientModuleBase(IKapacitorRequestClient requestClient)
        {
            this.RequestClient = requestClient;
        }
    }
}
