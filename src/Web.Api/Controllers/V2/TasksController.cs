using System.Net.Http;
using System.Web.Http;

using Web.Api.Models;

namespace Web.Api.Controllers.V2
{
    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/tasks")]
    public class TasksController : ApiController
    {
        [Route("", Name = "AddTaskRouteV2")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, NewTaskV2 newTask)
        {
            return new Task
            {
                Subject = string.Format("In v2, newTask.Subject = {0}", newTask.Subject)
            };
        }
    }
}
