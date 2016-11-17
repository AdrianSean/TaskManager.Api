using Data;
using System;

namespace Web.Api.InquiryProcessing
{
    public interface IPagedDataRequestFactory
    {
        PagedDataRequest Create(Uri requestUri);
    }
}
