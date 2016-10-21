using System;
using Common.TypeMapping;
using Data.QueryProcessors;
using Newtonsoft.Json.Linq;
using Web.Api.Models;
using Web.Common;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;
using System.Linq;

namespace Web.Api.MaintenanceProcessing
{
    public class UpdateTaskMaintenanceProcessor : IUpdateTaskMaintenanceProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IUpdateTaskQueryProcessor _queryProcessor;
        private readonly IUpdateablePropertyDetector _updateablePropertyDetector;

        public UpdateTaskMaintenanceProcessor(IAutoMapper autoMapper,
                                                IUpdateTaskQueryProcessor queryProcessor,
                                                  IUpdateablePropertyDetector updateablePropertyDetector)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _updateablePropertyDetector = updateablePropertyDetector;
        }



        public Task UpdateTask(long taskId, object taskFragment)
        {
            var taskFragmentAsJObject = (JObject)taskFragment;

            var taskContainingUpdateData = taskFragmentAsJObject.ToObject<Task>();

            var updatedPropertyValueMap = GetPropertyValueMap(taskFragmentAsJObject, taskContainingUpdateData);

            var updatedTaskEntity = _queryProcessor.GetUpdatedTask(taskId, updatedPropertyValueMap);

            var task = _autoMapper.Map<Task>(updatedTaskEntity);

            return task;
        }



        public virtual PropertyValueMapType GetPropertyValueMap(JObject taskFragment, Task taskContainingUpdateData)
        {
            var namesOfModifiedProperties = _updateablePropertyDetector
                                    .GetNamesOfPropertiesToUpdate<Task>(taskFragment).ToList();

            var propertyInfos = typeof(Task).GetProperties();

            var updatedPropertyValueMap = new PropertyValueMapType();

            foreach (var propertyName in namesOfModifiedProperties)
            {
                var propertyValue = propertyInfos.Single(
                        x => x.Name == propertyName)
                            .GetValue(taskContainingUpdateData);
                                updatedPropertyValueMap.Add(propertyName, propertyValue);
            }

            return updatedPropertyValueMap;
        }
    }
}