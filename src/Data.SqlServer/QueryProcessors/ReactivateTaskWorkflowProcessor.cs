using Common.TypeMapping;
using Data.Exceptions;
using Data.QueryProcessors;
using System;
using Web.Api.Models;
using Web.Common;

namespace Data.SqlServer.QueryProcessors
{
    public class ReactivateTaskWorkflowProcessor : IReactivateTaskWorkflowProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _taskByIByIdQueryProcessor;
        private readonly IUpdateTaskStatusQueryProcessor _updateTaskStatusQueryProcessor;


        public ReactivateTaskWorkflowProcessor(IAutoMapper autoMapper, ITaskByIdQueryProcessor taskByIByIdQueryProcessor,
                                                IUpdateTaskStatusQueryProcessor updateTaskStatusQueryProcessor)
        {
            _autoMapper = autoMapper;
            _taskByIByIdQueryProcessor = taskByIByIdQueryProcessor;
            _updateTaskStatusQueryProcessor = updateTaskStatusQueryProcessor;
        }

        public Task ReactivateTask(long taskId)
        {
            var taskEntity = _taskByIByIdQueryProcessor.GetTask(taskId);
            if (taskEntity == null)
                throw new RootObjectNotFoundException("Task not found");

            // Simulate some work flow logic
            if (taskEntity.Status.Name != "Completed")
                throw new BusinessRuleViolationException("Incorrect task status.  Expected status of completed.");


            taskEntity.CompletedDate = null;
            _updateTaskStatusQueryProcessor.UpdateTaskStatus(taskEntity, "In Progress");

            var task = _autoMapper.Map<Task>(taskEntity);
            return task;
        }
    }
}
