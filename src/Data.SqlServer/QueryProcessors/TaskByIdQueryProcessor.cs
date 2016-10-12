using Data.Entities;
using Data.QueryProcessors;
using NHibernate;


namespace Data.SqlServer.QueryProcessors
{
    public class TaskByIdQueryProcessor : ITaskByIdQueryProcessor
    {
        private readonly ISession _session;


        public TaskByIdQueryProcessor(ISession session)
        {
            _session = session;
        }

        public Task GetTask(long id)
        {
            var task = _session.Get<Task>(id);
            return task;
        }
    }
}
