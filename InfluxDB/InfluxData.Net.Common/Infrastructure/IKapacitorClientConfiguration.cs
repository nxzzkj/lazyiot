using Temporal.Net.Common.Enums;

namespace Temporal.Net.Common.Infrastructure
{
    public interface IKapacitorClientConfiguration : IConfiguration
    {
        KapacitorVersion KapacitorVersion { get; }
    }
}