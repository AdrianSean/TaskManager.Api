using Web.Api.Models;

namespace Web.Api.MaintenanceProcessing
{
    public interface ICompleteTaskWorkflowProcessor
    {
        Task CompleteTask(long taskId);
    }
}
