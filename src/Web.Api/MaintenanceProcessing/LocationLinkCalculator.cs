using System;
using System.Linq;
using Common;
using Web.Api.Models;
using Web.Common;

namespace Web.Api.MaintenanceProcessing
{
    public class LocationLinkCalculator
    {
        public static Uri GetLocationLink(ILinkContaining linkContaining)
        {
            var locationLink = linkContaining.Links.FirstOrDefault(
                x => x.Rel == Constants.CommonLinkRelValues.Self);

            return locationLink == null ? null : new Uri(locationLink.Href);               
        }
    }
}