using Web.Api.Models;

namespace Web.Api.LinkedServices
{
    public interface ITaskLinkService
    {
        Link GetAllTasksLink();

        void AddSelfLink(Task task);

        void AddLinksToChildObjects(Task task);
    }
}
