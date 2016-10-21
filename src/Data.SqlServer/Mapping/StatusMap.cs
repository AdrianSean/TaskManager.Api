using Data.Entities;

namespace Data.SqlServer.Mapping
{
    public class StatusMap : VersionClassMap<Status>
    {
        public StatusMap()
        {
            Id(x => x.StatusId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Ordinal).Not.Nullable();
        }
    }
}
