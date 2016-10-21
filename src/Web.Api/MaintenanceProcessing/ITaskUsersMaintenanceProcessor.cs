using System.Collections.Generic;
using Web.Api.Models;

namespace Web.Api.MaintenanceProcessing
{
    public interface ITaskUsersMaintenanceProcessor
    {
        Task ReplaceTaskUsers(long taskId, IEnumerable<long> userIds);

        Task DeleteTaskUsers(long taskId);

        Task AddTaskUser(long taskId, long userId);

        Task DeleteTaskUser(long taskId, long userId);
    }
}
