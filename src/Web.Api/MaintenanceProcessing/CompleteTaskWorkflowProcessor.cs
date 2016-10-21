using Common.TypeMapping;
using Data.Exceptions;
using Data.QueryProcessors;
using System;
using Web.Api.Models;
using Web.Common;

namespace Web.Api.MaintenanceProcessing
{
    public class CompleteTaskWorkflowProcessor : ICompleteTaskWorkflowProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _taskByIdQueryProcessor;
        private readonly IUpdateTaskStatusQueryProcessor _updateTaskStatusQueryProcessor;
        private readonly IDateTime _dateTime;


        public CompleteTaskWorkflowProcessor(IAutoMapper autoMapper, ITaskByIdQueryProcessor taskByIdQueryProcessor,
                                            IDateTime dateTime, IUpdateTaskStatusQueryProcessor updateTaskStatusQueryProcessor)
        {
            _autoMapper = autoMapper;
            _taskByIdQueryProcessor = taskByIdQueryProcessor;
            _updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
            _dateTime = dateTime;
        }


        public Task CompleteTask(long taskId)
        {
            var taskEntity = _taskByIdQueryProcessor.GetTask(taskId);
            if (taskEntity == null)
                throw new RootObjectNotFoundException("Task not found");

            //Simulate some workflow logic
            if (taskEntity.Status.Name != "In Progress")
                throw new BusinessRuleViolationException("Incorrect task status.  Expected status of 'In Progress'.");

            taskEntity.CompletedDate = DateTime.UtcNow;
            _updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "Completed");

            var task = _autoMapper.Map<Task>(taskEntity);

            return task;
        }
    }
}
