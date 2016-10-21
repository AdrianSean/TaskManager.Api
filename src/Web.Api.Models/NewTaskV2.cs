using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Models
{
    /// <summary>
    ///     Web model used to support creation of a new task.
    /// </summary>
    /// <remarks>
    ///     Normally this would be separated from the V1 models... in a separate
    ///     assembly, or at least in a separate namespece. We're focusing on
    ///     Web API, so to keep this contrived example simple we'll just use
    ///     a class name that indicates the intent.
    /// </remarks>
    public class NewTaskV2
    {
        public string Subject { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public List<User> Assignees { get; set; }

    }
}
