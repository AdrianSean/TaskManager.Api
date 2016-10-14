using Common.TypeMapping;
using Data.Exceptions;
using Data.QueryProcessors;
using Web.Api.Models;

namespace Web.Api.InquiryProcessing
{
    public class TaskByIdInquiryProcessor : ITaskByIdInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ITaskByIdQueryProcessor _queryProcessor;


        public TaskByIdInquiryProcessor(IAutoMapper autoMapper, ITaskByIdQueryProcessor queryProcessor)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
        }


        public Task GetTask(long taskId)
        {
            var taskEntity = _queryProcessor.GetTask(taskId);
            if (taskEntity == null)
                throw new RootObjectNotFoundException("Task not found");

            var task = _autoMapper.Map<Task>(taskEntity);
            return task;
        }
    }
}