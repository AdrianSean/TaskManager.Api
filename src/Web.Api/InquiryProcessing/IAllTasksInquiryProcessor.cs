using Data;
using Web.Api.Models;

namespace Web.Api.InquiryProcessing
{
    public interface IAllTasksInquiryProcessor
    {
        PagedDataInquiryResponse<Task> GetTasks(PagedDataRequest requestInfo);
    }
}
