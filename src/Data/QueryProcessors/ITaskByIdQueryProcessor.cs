using Data.Entities;

namespace Data.QueryProcessors
{
    public interface ITaskByIdQueryProcessor
    {
        Task GetTask(long id);
    }
}
