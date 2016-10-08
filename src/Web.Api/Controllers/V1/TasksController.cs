using System.Net.Http;
using System.Web.Http;
using Web.Api.MaintenanceProcessing;
using Web.Api.Models;
using Web.Common;
using Web.Common.Routing;

namespace Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("tasks")]
    [UnitOfWorkActionFilter]
    public class TasksController : ApiController
    {
        private readonly IAddTaskMaintenanceProcessor _addTaskMaintenanceProcessor;

        public TasksController(IAddTaskMaintenanceProcessor addTaskMaintenanceProcessor)
        {
            _addTaskMaintenanceProcessor = addTaskMaintenanceProcessor;
        }

        [Route("", Name ="AddTaskRoute")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, NewTask newTask)
        {
            var task = _addTaskMaintenanceProcessor.AddTask(newTask);
            return task;
        }        
    }
}
