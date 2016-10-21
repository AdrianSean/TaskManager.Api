using System.Collections.Generic;

namespace Web.Common
{
    public interface IUpdateablePropertyDetector
    {
        IEnumerable<string> GetNamesOfPropertiesToUpdate<TTargetType>(object objectContainingUpdatedData);
    }
}
