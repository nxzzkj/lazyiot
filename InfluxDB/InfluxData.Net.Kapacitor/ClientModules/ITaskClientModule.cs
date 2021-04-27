using System.Collections.Generic;
using System.Threading.Tasks;
using Temporal.Net.Common.Infrastructure;
using Temporal.Net.Kapacitor.Models;
using Temporal.Net.Kapacitor.Models.Responses;

namespace Temporal.Net.Kapacitor.ClientModules
{
    public interface ITaskClientModule
    {
        Task<KapacitorTask> GetTaskAsync(string taskId);

        Task<IEnumerable<KapacitorTask>> GetTasksAsync();

        Task<IInfluxDataApiResponse> DefineTaskAsync(DefineTaskParams taskParams);

        Task<IInfluxDataApiResponse> DefineTaskAsync(DefineTemplatedTaskParams taskParams);

        Task<IInfluxDataApiResponse> DeleteTaskAsync(string taskId);

        Task<IInfluxDataApiResponse> EnableTaskAsync(string taskId);

        Task<IInfluxDataApiResponse> DisableTaskAsync(string taskId);
    }
}