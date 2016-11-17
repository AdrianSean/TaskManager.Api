using Common;
using Common.TypeMapping;
using Data.Entities.QueryProcessors;
using System;
using System.Net.Http;
using Web.Api.Models;
using Web.Common;

namespace Web.Api.MaintenanceProcessing
{
    public class AddTaskMaintenanceProcessor : IAddTaskMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAddTaskQueryProcessor _queryProcessor;



        public AddTaskMaintenanceProcessor(IAddTaskQueryProcessor queryProcessor, IAutoMapper autoMapper)
        {
            _queryProcessor = queryProcessor;
            _autoMapper = autoMapper;
        }


        public Task AddTask(NewTask newTask)
        {
            var taskEntity = _autoMapper.Map<Data.Entities.Task>(newTask);
            _queryProcessor.AddTask(taskEntity);
            var task = _autoMapper.Map<Task>(taskEntity);

            task.AddLink(new Link {
                Method = HttpMethod.Get.Method,
                Href = "http://localhost:61589/api/v1/tasks/" + task.TaskId,
                Rel = Constants.CommonLinkRelValues.Self
            });
            
            return task;
        }
    }
}