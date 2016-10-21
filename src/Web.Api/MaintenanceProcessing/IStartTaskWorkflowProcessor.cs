using Web.Api.Models;

namespace Web.Api.MaintenanceProcessing
{
    public interface IStartTaskWorkflowProcessor
    {
        Task StartTask(long taskId);
    }
}
