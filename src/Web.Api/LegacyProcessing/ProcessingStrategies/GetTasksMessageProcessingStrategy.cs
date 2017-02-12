// GetTasksMessageProcessingStrategy.cs
// Copyright Jamie Kurtz, Brian Wortman 2014.

using Common;
using Data;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using Web.Api.InquiryProcessing;
using Web.Api.Models;

namespace Web.Api.LegacyProcessing.ProcessingStrategies
{
    public class GetTasksMessageProcessingStrategy : ILegacyMessageProcessingStrategy
    {
        private readonly IAllTasksInquiryProcessor _inquiryProcessor;

        public GetTasksMessageProcessingStrategy(IAllTasksInquiryProcessor inquiryProcessor)
        {
            _inquiryProcessor = inquiryProcessor;
        }


        public bool CanProcess(string operationName)
        {
            return operationName == "GetTasks";
        }
        
        public object Execute(XElement operationElement)
        {
            var modelTasks =    _inquiryProcessor.GetTasks(new PagedDataRequest(1, 500) {ExcludedLinks = true}).Items.ToArray();

            XNamespace ns = Constants.DefaultLegacyNamespace;

            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof (Task[]), Constants.DefaultLegacyNamespace);
                serializer.Serialize(stream, modelTasks);

                stream.Seek(0, 0);

                var xDocument = XDocument.Load(stream, LoadOptions.None);
                var categoriesAsXElements = xDocument.Descendants(ns + "Task");
                return categoriesAsXElements;
            }
        }
    }
}