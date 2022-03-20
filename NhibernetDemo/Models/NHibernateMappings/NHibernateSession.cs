using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Http;
using NHibernate;
using NHibernate.Tool.hbm2ddl;


namespace NhibernetDemo.Models.NHibernateMappings
{
    public class NHibernateSession
    {
        public static NHibernate.ISession OpenSession()
        {
            string connectionString = "Server=.;database=EmployeeManagementDatabase;Integrated Security=SSPI;";

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(connectionString).ShowSql())

                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CompanyDTO>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<DepartmentDTO>())
                 .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeDTO>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }
}
