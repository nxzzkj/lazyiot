using Temporal.Net.Common.Infrastructure;

namespace Temporal.Net.Kapacitor.RequestClients
{
    public class KapacitorRequestClient_v_0_10_0 : KapacitorRequestClient, IKapacitorRequestClient
    {
        protected override string BasePath
        {
            get { return "api/v1/"; }
        }

        public KapacitorRequestClient_v_0_10_0(IKapacitorClientConfiguration configuration)
            : base(configuration)
        {
        }
    }
}