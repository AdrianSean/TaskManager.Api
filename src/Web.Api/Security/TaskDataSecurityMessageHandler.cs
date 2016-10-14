using Common.Security;
using log4net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Web.Common;
using Web.Common.Logging;
using Task = Web.Api.Models.Task;


namespace Web.Api.Security
{
    public class TaskDataSecurityMessageHandler : DelegatingHandler
    {
        private readonly ILog _log;
        private readonly IUserSession _userSession;

        public TaskDataSecurityMessageHandler(ILogManager logManager, IUserSession userSession)
        {
            _userSession = userSession;
            _log = logManager.GetLog(typeof(TaskDataSecurityMessageHandler));


        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, 
                                                                     CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            if (CanHandleResponse(response))
                ApplySecurityToResponseData((ObjectContent) response.Content);

            return response;
        }


        public void ApplySecurityToResponseData(ObjectContent responseObjectContent)
        {
            var removeSensitiveData = !_userSession.IsInRole(Constants.RoleNames.SeniorWorker);
            if (removeSensitiveData)
                _log.DebugFormat("Applying security data masking for user { 0}", _userSession.Username);

            ((Task)responseObjectContent.Value).SetShouldSerializeAssignees(!removeSensitiveData);
        }



        public bool CanHandleResponse(HttpResponseMessage response)
        {
            var objectContent = response.Content as ObjectContent;
            var canHandleResponse = objectContent != null && objectContent.ObjectType == typeof(Task);

            return canHandleResponse;
        }





    }
}