using System.Collections.Generic;
using TagHelpersTypes.Models;

namespace TagHelpersTypes.Services
{
    public interface IEmployeeService
    {
        Employee CreateEmployee();
        void CreateEmployee(Employee employee);
        Employee DeleteEmployee(int? id);
        void DeleteEmployee(int? id, Employee employee);
        IList<Employee> GetEmployees();
        Employee GetEmployees(int? id);
        Employee UpdateEmployee(int? id);
        void UpdateEmployee(int? id, Employee newEmployee);
    }
}