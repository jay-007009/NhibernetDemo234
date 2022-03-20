using FluentNHibernate.Mapping;

namespace NhibernetDemo.Models.NHibernateMappings
{
    public class DepartmentMapping : ClassMap<DepartmentDTO>
    {
        public DepartmentMapping()
        {
            Table("Departments");
            Id(x => x.DepartmentID);
            Map(x=> x.DepartmentName);
            Map(x => x.DepartmentName);
            Map(x => x.DepartmentName);
            Map(x => x.DepartmentName);
            //HasMany(x=>x.Employees)
            //    .KeyColumn("DepartmentId")
            //    .Fetch.Select()
            //    .Cascade.AllDeleteOrphan();
            References(x => x.CompanyList).Column("CompanyID").Not.Nullable().Fetch.Join();
            HasMany(x => x.EmployeesList).Inverse().KeyColumn("EmployeeId").Fetch.Join().Not.LazyLoad();
        }
    }
}
