using InfluxData.Net.Common.Enums;

namespace InfluxData.Net.Integration.InfluxDb
{
    public class IntegrationFixture_v_1_3 : IntegrationFixtureBase
    {
        public IntegrationFixture_v_1_3() : base("InfluxDbEndpointUri_v_1_3", InfluxDbVersion.v_1_3)
        {
        }
    }
}