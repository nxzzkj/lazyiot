using System;
using Temporal.Net.Common.Infrastructure;

namespace Temporal.Net.Kapacitor.RequestClients
{
    public class KapacitorRequestClient_v_0_10_1 : KapacitorRequestClient, IKapacitorRequestClient
    {
        protected override string BasePath
        {
            get { return String.Empty; }
        }

        public KapacitorRequestClient_v_0_10_1(IKapacitorClientConfiguration configuration)
            : base(configuration)
        {
        }
    }
}