// LegacyMessageParser.cs
// Copyright Jamie Kurtz, Brian Wortman 2014.

using Common.Extensions;
using System.Linq;
using System.Xml.Linq;

namespace Web.Api.LegacyProcessing
{
    public class LegacyMessageParser : ILegacyMessageParser
    {
        public XElement GetOperationElement(XDocument soapRequest)
        {
            var body = soapRequest.GetSoapBody();
            var operationElement = GetOperationElement(body);
            return operationElement;
        }

        public XElement GetOperationElement(XElement soapBody)
        {
            var operationElement = soapBody.Elements().First();
            return operationElement;
        }
    }
}