using NHibernate;
using System.Collections.Generic;
using System.Linq;
using TagHelpersTypes.Models;
using ISession = NHibernate.ISession;
//using System.Web.Mvc;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;
using System;
using NhibernetDemo.Models.NHibernateMappings;
using NhibernetDemo.Models;

namespace TagHelpersTypes.Services
{
    public class EmployeeService : IEmployeeService
    {
        public IList<Employee> GetEmployees()
        {
            try
            {
                using (var session = NHibernateSession2.OpenSession())
                {
                    using (var tx = session.BeginTransaction())
                    {
                        var employees = session.CreateCriteria<Employee>().List<Employee>();
                        tx.Commit();
                        return employees;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
        public Employee GetEmployees(int? id)
        {
            using (ISession session = NHibernateSession2.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var employee = session.Get<Employee>(id);
                    transaction.Commit();
                    return employee;
                }
            }
        }
        public CompanyDTO CreateCompany()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                CompanyDTO company = new CompanyDTO();
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var departments = session.Query<DepartmentDTO>().ToList();
                    foreach (var department in departments)
                    {
                        company.DepartmentList.Add(new SelectListItem { Text = department.DepartmentName, Value = department.DepartmentId.ToString() });
                    }
                    return employee;
                }
            }

        }
        public void CreateEmployee(Employee employee)
        {
            try
            {

                using (ISession session = NHibernateSession2.OpenSession())
                {
                    using (ITransaction transaction = session.BeginTransaction())
                    {
                        var department = session.Get<Department>(employee.DepartmentId);
                        employee.Department = department;
                        session.Save(employee);
                        transaction.Commit();
                    }
                }

            }
            catch (Exception error)
            {

            }
        }
        public void UpdateEmployee(int? id, Employee newEmployee)
        {
            using (ISession session = NHibernateSession2.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                employee.EmployeeFirstName = newEmployee.EmployeeFirstName;
                employee.EmployeeLastName = newEmployee.EmployeeLastName;
                employee.EmployeeAge = newEmployee.EmployeeAge;
                employee.EmployeeMaritalStatus = newEmployee.EmployeeMaritalStatus;
                employee.EmployeeGender = newEmployee.EmployeeGender;

                using (ITransaction transaction = session.BeginTransaction())
                {
                    var department = session.Get<Department>(newEmployee.DepartmentId);
                    employee.Department = department;
                    session.SaveOrUpdate(employee);
                    transaction.Commit();
                }
            }
        }
        public Employee UpdateEmployee(int? id)
        {
            using (ISession session = NHibernateSession2.OpenSession())
            {
                var employee = session.Get<Employee>(id);
                var departments = session.Query<Department>().ToList();
                foreach (var department in departments)
                {
                    employee.Departments.Add(new SelectListItem { Text = department.DepartmentName, Value = department.DepartmentId.ToString() });
                }

                return employee;
            }
        }
        public Employee DeleteEmployee(int? id)
        {
            using (ISession session = NHibernateSession2.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var employee = session.Get<Employee>(id);

                    return employee;
                }
            }
        }
        public void DeleteEmployee(int? id, Employee employee)
        {
            using (ISession session = NHibernateSession2.OpenSession())
            {


                using (ITransaction trans = session.BeginTransaction())
                {
                    employee = session.Get<Employee>(id);
                    session.Delete(employee);
                    trans.Commit();
                }
            }
        }
    }
}
