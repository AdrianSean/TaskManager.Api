using System.Net.Http;
using System.Web.Http;
using Web.Api.InquiryProcessing;
using Web.Api.MaintenanceProcessing;
using Web.Api.Models;
using Web.Common;
using Web.Common.Routing;

namespace Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("tasks")]
    [UnitOfWorkActionFilter]
    [Authorize(Roles =Constants.RoleNames.JuniorWorker)]
    public class TasksController : ApiController
    {
        private readonly IAddTaskMaintenanceProcessor _addTaskMaintenanceProcessor;
        private readonly ITaskByIdInquiryProcessor _taskByIdInQuiryProcessor;

        public TasksController(IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor,
                               ITaskByIdInquiryProcessor taskByIdInQuiryProcessor)
        {
            _addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
            _taskByIdInQuiryProcessor = taskByIdInQuiryProcessor;
        }

        [Route("", Name ="AddTaskRoute")]
        [HttpPost]
        [Authorize(Roles = Constants.RoleNames.Manager)]
        public Task AddTask(HttpRequestMessage requestMessage, NewTask newTask)
        {
            var task = _addTaskMaintenanceProcessor.AddTask(newTask);
            var result = new TaskCreatedActionResult(task, requestMessage);
            return task;
        }

        [Route("{id:long}", Name ="GetTaskRoute")]       
        public Task GetTask(long id)
        {
            var task = _taskByIdInQuiryProcessor.GetTask(id);
            return task;           
        }              
    }
}
