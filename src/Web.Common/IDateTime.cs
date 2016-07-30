using System;


namespace Web.Common
{
    public interface IDateTime
    {
        DateTime UtcNow { get; }
    }
}
