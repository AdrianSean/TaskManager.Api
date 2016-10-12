using Data.QueryProcessors;
using Common.TypeMapping;
using Web.Common;
using Data.Exceptions;
using Web.Api.Models;

namespace Data.SqlServer.QueryProcessors
{
    public class StartTaskWorkflowProcessor : IStartTaskWorkflowProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _taskByIdQueryProcessor;
        private readonly IDateTime _dateTime;
        private readonly IUpdateTaskStatusQueryProcessor _updateTaskQueryProcessor;



        public StartTaskWorkflowProcessor(IUpdateTaskStatusQueryProcessor updateTaskQueryProcessor, IDateTime dateTime, ITaskByIdQueryProcessor taskByIdQueryProcessor, IAutoMapper automapper)
        {
            _updateTaskQueryProcessor = updateTaskQueryProcessor;
            _dateTime = dateTime;
            _taskByIdQueryProcessor = taskByIdQueryProcessor;
            _autoMapper = automapper;
        }


        public Task StartTask(long taskId)
        {
            var taskEntity = _taskByIdQueryProcessor.GetTask(taskId);
            if (taskEntity == null)
                throw new RootObjectNotFoundException("Task not found");

            // Simulate some workflow logic
            if (taskEntity.Status.Name != "Not Started")            
                throw new BusinessRuleViolationException("Incorrect task status. Expected status of 'Not Started'.");

            taskEntity.StartDate = _dateTime.UtcNow;
            _updateTaskQueryProcessor.UpdateTaskStatus(taskEntity, "In Progress");
            var task = _autoMapper.Map<Task>(taskEntity);

            return task;
        }
    }
}
