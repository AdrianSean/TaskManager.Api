using Web.Api.InquiryProcessing;
using Web.Api.MaintenanceProcessing;

namespace Web.Api.Controllers.V1
{
    public interface ITasksControllerDependencyBlock
    {
        IAddTaskMaintenanceProcessor AddTaskMaintenanceProcessor { get; }

        ITaskByIdInquiryProcessor TaskByIdInquiryProcessor { get; }

        IUpdateTaskMaintenanceProcessor UpdateTaskMaintenanceProcessor { get; }

        IPagedDataRequestFactory PagedDataRequestFactory { get; }

        IAllTasksInquiryProcessor AllTasksInquiryProcessor { get; }

    }
}
