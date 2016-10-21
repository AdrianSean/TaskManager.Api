using Web.Api.Models;

namespace Web.Api.MaintenanceProcessing
{ 
    public interface IReactivateTaskWorkflowProcessor
    {
        Task ReactivateTask(long taskId);
    }
}
