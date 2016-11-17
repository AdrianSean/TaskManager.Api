using Common;
using System.Collections.Generic;
using System.Web.Http;
using Web.Api.MaintenanceProcessing;
using Web.Api.Models;
using Web.Common;
using Web.Common.Routing;

namespace Web.Api.Controllers.V1
{

    [ApiVersion1RoutePrefix("tasks")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles =Constants.RoleNames.SeniorWorker)]
    public class TaskUserController : ApiController
    {
        private readonly ITaskUsersMaintenanceProcessor _taskUsersMaintenanceProcessor;

        public TaskUserController(ITaskUsersMaintenanceProcessor taskUsersMaintenanceProcessor)
        {
            _taskUsersMaintenanceProcessor = taskUsersMaintenanceProcessor;
        }

        [Route("{taskId:long}/users", Name ="ReplaceTaskUsersRoute")]
        [HttpPut]
        public Task ReplaceTaskUsers(long taskId, [FromBody] IEnumerable<long> userIds)
        {
            var task = _taskUsersMaintenanceProcessor.ReplaceTaskUsers(taskId, userIds);
            return task;
        }


        [Route("{taskId:long}/users", Name = "DeleteTaskUsersRoute")]
        [HttpDelete]
        public Task DeleteTaskUsers(long taskId)
        {
            var task = _taskUsersMaintenanceProcessor.DeleteTaskUsers(taskId);
            return task;
        }


        [Route("{taskId:long}/users/{userId:long}", Name = "AddTaskUserRoute")]
        [HttpPut]
        public Task AddTaskUser(long taskId, long userId)
        {
            var task = _taskUsersMaintenanceProcessor.AddTaskUser(taskId, userId);
            return task;
        }


        [Route("{taskId:long}/users/{userId:long}", Name = "DeleteTaskUserRoute")]
        [HttpDelete]
        public Task DeleteTaskUser(long taskId, long userId)
        {
            var task = _taskUsersMaintenanceProcessor.DeleteTaskUser(taskId, userId);
            return task;
        }
    }
}
