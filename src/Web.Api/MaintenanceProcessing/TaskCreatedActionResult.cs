using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Web.Api.MaintenanceProcessing
{
    public class TaskCreatedActionResult : IHttpActionResult
    {
        private readonly Models.Task _createdTask;
        private readonly HttpRequestMessage _requestMessage;

        public TaskCreatedActionResult(Models.Task createdTask, HttpRequestMessage requestMessage)
        {
            _requestMessage = requestMessage;
            _createdTask = createdTask;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute());
        }


        public HttpResponseMessage Execute()
        {
            var responseMessage = _requestMessage.CreateResponse(System.Net.HttpStatusCode.Created, _createdTask);
            responseMessage.Headers.Location = LocationLinkCalculator.GetLocationLink(_createdTask);
            return responseMessage;
        }
    }
}