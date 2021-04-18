using Temporal.Net.Kapacitor.ClientModules;

namespace Temporal.Net.Kapacitor
{
    public interface IKapacitorClient
    {
        ITaskClientModule Task { get; }
    }
}