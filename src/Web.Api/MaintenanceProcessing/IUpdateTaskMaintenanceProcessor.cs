using Web.Api.Models;

namespace Web.Api.MaintenanceProcessing
{
    public interface IUpdateTaskMaintenanceProcessor
    {
        Task UpdateTask(long taskId, object taskFragment);
    }
}
