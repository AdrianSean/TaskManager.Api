﻿// GetTaskByIdMessageProcessingStrategy.cs
// Copyright Jamie Kurtz, Brian Wortman 2014.

using Common;
using Data.Exceptions;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using Web.Api.InquiryProcessing;
using Web.Api.Models;
using Web.Common;

namespace Web.Api.LegacyProcessing.ProcessingStrategies
{
    public class GetTaskByIdMessageProcessingStrategy : ILegacyMessageProcessingStrategy
    {
        private readonly ITaskByIdInquiryProcessor _inquiryProcessor;

        public GetTaskByIdMessageProcessingStrategy(ITaskByIdInquiryProcessor inquiryProcessor)
        {
            _inquiryProcessor = inquiryProcessor;
        }

        public object Execute(XElement operationElement)
        {
            XNamespace ns = Constants.DefaultLegacyNamespace;

            var id = PrimitiveTypeParser.Parse<long>(operationElement.Descendants(ns + "taskId").First().Value);

            Task task = null;
            try
            {
                task = _inquiryProcessor.GetTask(id);
            }
            catch (RootObjectNotFoundException)
            {
                // Eat it. Just return an empty response.
            }

            using (var stream = new MemoryStream())
            {
                var serializer = new XmlSerializer(typeof (Task), Constants.DefaultLegacyNamespace);
                serializer.Serialize(stream, task);

                stream.Seek(0, 0);

                var xDocument = XDocument.Load(stream, LoadOptions.None);
                var taskAsXElement = xDocument.Descendants(ns + "Task");
                return taskAsXElement.Elements();
            }
        }

        public bool CanProcess(string operationName)
        {
            return operationName == "GetTaskById";
        }
    }
}