using Data.QueryProcessors;
using System.Web.Http;
using Web.Api.Models;
using Web.Common;
using Web.Common.Routing;

namespace Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles = Constants.RoleNames.SeniorWorker)]
    public class TaskWorkflowController : ApiController
    {
        private readonly IStartTaskWorkflowProcessor _startTaskWorkflowProcessor;
        private readonly ICompleteTaskWorkflowProcessor _completeTaskWorkflowProcessor;

        public TaskWorkflowController(IStartTaskWorkflowProcessor startTaskWorkflowProcessor,
                                      ICompleteTaskWorkflowProcessor completeTaskWorkflowProcessor)
        {
            _startTaskWorkflowProcessor = startTaskWorkflowProcessor;
            _completeTaskWorkflowProcessor = completeTaskWorkflowProcessor;
        }


        [HttpPost]       
        [Route("tasks/{taskId:long}/activations", Name = "StartTaskRoute")]
        public Task StartTask(long taskId)
        {
            var task = _startTaskWorkflowProcessor.StartTask(taskId);
            return task;
        }

        [HttpPost]        
        [Route("tasks/{taskId:long}/completions", Name = "CompleteTaskRoute")]
        public Task CompleteTask(long taskId)
        {
            var task = _completeTaskWorkflowProcessor.CompleteTask(taskId);
            return task;
        }


    }
}
