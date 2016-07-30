using Data.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Mapping
{
    public abstract class VersionClassMap<T> : ClassMap<T> where T : IVersionEntity
    {
        protected VersionClassMap()
        {
            Version(x => x.Version)
                .Column("ts")
                .CustomSqlType("RowVersion")
                .Generated.Always()
                .UnsavedValue("null");
        }
    }
}
