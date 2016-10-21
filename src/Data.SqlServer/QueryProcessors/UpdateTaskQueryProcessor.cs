using Data.Exceptions;
using Data.QueryProcessors;
using NHibernate;
using System;
using System.Collections.Generic;
using Data.Entities;
using System.Linq;

namespace Data.SqlServer.QueryProcessors
{
    public class UpdateTaskQueryProcessor : IUpdateTaskQueryProcessor
    {
        private readonly ISession _session;

        public UpdateTaskQueryProcessor(ISession session)
        {
            _session = session;
        }


        public Task AddTaskUser(long taskId, long userId)
        {
            var task = GetValidTask(taskId);

            UpdateTaskUsers(task, new[] { userId }, true);

            _session.SaveOrUpdate(task);

            return task;
        }



        public Task DeleteTaskUser(long taskId, long userId)
        {
            var task = GetValidTask(taskId);

            var user = task.Users.FirstOrDefault(u=>u.UserId == userId);

            if (user != null)
            {
                task.Users.Remove(user);
                _session.SaveOrUpdate(task);
            }

            return task;
        }



        public Task DeleteTaskUsers(long taskId)
        {
            var task = GetValidTask(taskId);

            UpdateTaskUsers(task, null, false);

            _session.SaveOrUpdate(task);

           return task;
        }

        public Task ReplaceTaskUsers(long taskId, IEnumerable<long> userIds)
        {
            var task = GetValidTask(taskId);

            UpdateTaskUsers(task, userIds, false);

            _session.SaveOrUpdate(task);

            return task;
        }



        public virtual void UpdateTaskUsers(Task task, IEnumerable<long> userIds, bool appendToExisting)
        {
            if (!appendToExisting)
                task.Users.Clear();

            if (userIds != null)
                foreach (var user in userIds.Select(GetValidUser))
                    if (!task.Users.Contains(user))
                        task.Users.Add(user);

        }

        public virtual Task GetValidTask(long taskId)
        {
            var task = _session.Get<Task>(taskId);
            if (task == null)
                throw new RootObjectNotFoundException("Task not found");

            return task;
        }

        public virtual User GetValidUser(long userId)
        {
            var user = _session.Get<User>(userId);
            if (user == null)
                throw new ChildObjectNotFoundException("User not found");

            return user;
        }
    }
}
