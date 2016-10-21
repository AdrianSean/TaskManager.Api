using Data.Entities;
using FluentNHibernate.Mapping;

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
