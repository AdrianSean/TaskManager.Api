using Web.Api.Models;

namespace Data.QueryProcessors
{
    public interface IReactivateTaskWorkflowProcessor
    {
        Task ReactivateTask(long taskId);
    }
}
