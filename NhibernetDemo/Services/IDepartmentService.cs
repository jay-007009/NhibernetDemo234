using System.Collections.Generic;
using TagHelpersTypes.Models;

namespace TagHelpersTypes.Services
{
    public interface IDepartmentService
    {
        IList<Department> GetDepartments();
    }
}