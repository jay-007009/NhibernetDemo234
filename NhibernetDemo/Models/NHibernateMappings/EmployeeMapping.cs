using FluentNHibernate.Mapping;

namespace NhibernetDemo.Models.NHibernateMappings
{
    public class EmployeeMapping : ClassMap<EmployeeDTO>
    {
        public EmployeeMapping()
        {
            Table("Employees");
            Id(x => x.EmployeeID);
            Map(x => x.EmployeeName);
            Map(x => x.EmployeeUserName);
            Map(x => x.EmployeeGender);
            Map(x => x.EmployeeJoiningDate);
            Map(x => x.EmployeeEmailID);
            Map(x => x.EmployeePhoneNo);
            Map(x => x.EmployeeAddress);
           
            //HasMany(x=>x.Employees)
            //    .KeyColumn("DepartmentId")
            //    .Fetch.Select()
            //    .Cascade.AllDeleteOrphan();

            References(x => x.CompanyList).Column("CompanyID").Not.Nullable().Fetch.Join();
            References(x => x.DepartmentList).Column("DepartmentID").Not.Nullable().Fetch.Join();
            // HasMany(x => x.Employees).Inverse().KeyColumn("DepartmentId").Fetch.Join().Not.LazyLoad();
        }
    }
}