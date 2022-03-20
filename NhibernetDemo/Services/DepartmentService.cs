using System.Collections.Generic;
using System.Linq;
using TagHelpersTypes.Models;

namespace TagHelpersTypes.Services
{
    public class DepartmentService : IDepartmentService
    {
        public IList<Department> GetDepartments()
        {
            using (NHibernate.ISession session = NHibernateSession.OpenSession())
            {
                var departments = session.Query<Department>().ToList();
                return departments;
            }
        }
    }
}
