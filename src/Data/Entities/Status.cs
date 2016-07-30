using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Status : IVersionEntity
    {
        public virtual long StatusId { get; set; }
        public virtual string Name { get; set; }
        public virtual int  Ordinal { get; set; }
        public virtual byte[] Version { get; set; } // will be used by nhibernate to detect dirty data
    }
}
