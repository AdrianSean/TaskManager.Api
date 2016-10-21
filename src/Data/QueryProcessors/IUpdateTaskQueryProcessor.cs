using System.Collections.Generic;
using Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace Data.QueryProcessors
{
    public interface IUpdateTaskQueryProcessor
    {
        Task ReplaceTaskUsers(long taskId, IEnumerable<long> userIds);

        Task DeleteTaskUsers(long taskId);

        Task AddTaskUser(long taskId, long userId);

        Task DeleteTaskUser(long taskId, long userId);

        Task GetUpdatedTask(long taskId, PropertyValueMapType updatedPropertyValueMap);
    }
}
