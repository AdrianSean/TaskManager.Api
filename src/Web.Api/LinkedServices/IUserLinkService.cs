using Web.Api.Models;

namespace Web.Api.LinkedServices
{
    public interface IUserLinkService
    {
        void AddSelfLink(User user);
    }
}
