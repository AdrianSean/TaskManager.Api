using Web.Api.Models;

namespace Data.QueryProcessors
{
    public interface ICompleteTaskWorkflowProcessor
    {
        Task CompleteTask(long taskId);
    }
}
