using System.Collections.Generic;
using Data.Entities;

namespace Data.QueryProcessors
{
    public interface IUpdateTaskQueryProcessor
    {
        Task ReplaceTaskUsers(long taskId, IEnumerable<long> userIds);

        Task DeleteTaskUsers(long taskId);

        Task AddTaskUser(long taskId, long userId);

        Task DeleteTaskUser(long taskId, long userId);
    }
}
