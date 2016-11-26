using System.Net.Http;
using Web.Api.Models;

namespace Web.Api.LinkedServices
{
    public interface ICommonLinkService
    {
        void AddPageLinks(IPageLinkContaining linkContainer,
        string currentPageQueryString,
        string previousPageQueryString,
        string nextPageQueryString);
        Link GetLink(string pathFragment, string relValue, HttpMethod httpMethod);
    }
}