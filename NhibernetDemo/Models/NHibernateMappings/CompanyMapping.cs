using FluentNHibernate.Mapping;
using NhibernetDemo.Models;

namespace TagHelpersTypes.Models.NHibernateMappings
{
    public class CompanyMapping : ClassMap<CompanyDTO>   
    {
        public CompanyMapping()
        {
            Table("Companies");
            Id(x => x.CompanyID);
            Map(x => x.CompanyName);
            Map(x => x.CompanyEmailID);
            Map(x => x.CompanyPhoneNo);
            Map(x => x.CompanyAddress);

            //References(x => x.Department, "DepartmentId")
            //    .ForeignKey("DepartmentId")
            //    .Fetch.Select()
            //    .Cascade.SaveUpdate().Not.LazyLoad();
            //References(x => x.DepartmentList).Column("DepartmentID").Not.Nullable().Fetch.Join();
            HasMany(x => x.DepartmentList).Inverse().KeyColumn("DepartmentID").Fetch.Join().Not.LazyLoad();
        }
    }
}
