// ILegacyMessageProcessor.cs
// Copyright Jamie Kurtz, Brian Wortman 2014.

using System.Xml.Linq;

namespace Web.Api.LegacyProcessing
{
    public interface ILegacyMessageProcessor
    {
        LegacyResponse ProcessLegacyMessage(XDocument request);
    }
}