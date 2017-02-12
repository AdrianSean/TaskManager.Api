using Common.TypeMapping;
using Data;
using Data.Entities;

using System.Collections.Generic;
using System.Linq;
using Web.Api.LinkedServices;
using PagedTaskDataInquiryResponse =
Web.Api.Models.PagedDataInquiryResponse<Web.Api.Models.Task>;


namespace Web.Api.InquiryProcessing
{
    public class AllTasksInquiryProcessor : IAllTasksInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly ICommonLinkService _commonLinkService;
        private readonly ITaskLinkService _taskLinkService;
        private readonly IAllTasksQueryProcessor _queryProcessor;

        public const string QueryStringFormat = "pagenumber={0}&pagesize={1}";


        public AllTasksInquiryProcessor(IAutoMapper autoMapper, IAllTasksQueryProcessor queryProcessor,
                                        ICommonLinkService commonLinkService,
                                        ITaskLinkService taskLinkService)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
            _commonLinkService = commonLinkService;
            _taskLinkService = taskLinkService;
        }

        

        public PagedTaskDataInquiryResponse GetTasks(PagedDataRequest requestInfo)
        {
            var queryResult = _queryProcessor.GetTasks(requestInfo);

            var tasks = GetTasks(queryResult.QueriedItems).ToList();

            var inquiryResponse = new PagedTaskDataInquiryResponse
            {
                Items = tasks,
                PageCount = queryResult.TotalPageCount,
                PageNumber = requestInfo.PageNumber,
                PageSize = requestInfo.PageSize
            };

            AddLinksToInquiryResponse(inquiryResponse);

            return inquiryResponse;
        }

     
        public virtual IEnumerable<Models.Task> GetTasks(IEnumerable<Task> taskEntities)
        {
            var tasks = taskEntities.Select(x => _autoMapper.Map<Models.Task>(x)).ToList();
            return tasks;
        }


        public virtual void AddLinksToInquiryResponse(PagedTaskDataInquiryResponse inquiryResponse)
        {
            inquiryResponse.AddLink(_taskLinkService.GetAllTasksLink());
            _commonLinkService.AddPageLinks(inquiryResponse, GetCurrentPageQueryString(inquiryResponse), 
                                                GetPreviousPageQueryString(inquiryResponse),
                                                    GetNextPageQueryString(inquiryResponse));
        }

        public virtual string GetCurrentPageQueryString(PagedTaskDataInquiryResponse inquiryResponse)
        {
            return string.Format(QueryStringFormat, inquiryResponse.PageNumber, inquiryResponse.PageSize);
        }

        public virtual string GetPreviousPageQueryString(PagedTaskDataInquiryResponse inquiryResponse)
        {
            return string.Format(QueryStringFormat, inquiryResponse.PageNumber - 1, inquiryResponse.PageSize);
        }

        public virtual string GetNextPageQueryString(PagedTaskDataInquiryResponse inquiryResponse)
        {
            return string.Format(QueryStringFormat, inquiryResponse.PageNumber + 1, inquiryResponse.PageSize);
        }
    }
}