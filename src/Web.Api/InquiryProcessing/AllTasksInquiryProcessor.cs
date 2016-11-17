using Common.TypeMapping;
using Data;

using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

using PagedTaskDataInquiryResponse =
Web.Api.Models.PagedDataInquiryResponse<Web.Api.Models.Task>;


namespace Web.Api.InquiryProcessing
{
    public class AllTasksInquiryProcessor : IAllTasksInquiryProcessor
    {
        private readonly IAutoMapper _autoMapper;
        private readonly IAllTasksQueryProcessor _queryProcessor;


        public AllTasksInquiryProcessor(IAutoMapper autoMapper, IAllTasksQueryProcessor queryProcessor)
        {
            _autoMapper = autoMapper;
            _queryProcessor = queryProcessor;
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

            return inquiryResponse;
        }

     
        public virtual IEnumerable<Models.Task> GetTasks(IEnumerable<Task> taskEntities)
        {
            var tasks = taskEntities.Select(x => _autoMapper.Map<Models.Task>(x)).ToList();
            return tasks;
        }
    }
}