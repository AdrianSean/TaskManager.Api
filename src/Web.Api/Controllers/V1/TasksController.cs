using System.Net.Http;
using System.Web.Http;
using Web.Api.Models;
using Web.Common.Routing;

namespace Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("tasks")]
    public class TasksController : ApiController
    {
        [Route("", Name ="AddTaskRoute")]
        [HttpPost]
        public Task AddTask(HttpRequestMessage requestMessage, Task newTask)
        {
            return new Task
            {
                Subject = string.Format("In v1, newTask.Subject = {0}", newTask.Subject)
            };
        }        
    }
}
