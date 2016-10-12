

using Web.Api.Models;

namespace Data.QueryProcessors
{
    public interface IStartTaskWorkflowProcessor
    {
        Task StartTask(long taskId);
    }
}
