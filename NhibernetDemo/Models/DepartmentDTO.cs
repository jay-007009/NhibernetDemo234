using System;
using System.Collections.Generic;
using System.Text;

namespace NhibernetDemo.Models
{
    public class DepartmentDTO
    {
        public int CompanyID { get; set; }
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentLead { get; set; }
        public string DepartmentBranchAddress { get; set; }

        // public virtual List<CompanyDTO> CompanyList { get; set; }
        public virtual CompanyDTO CompanyList { get; set; }

        public virtual ICollection<EmployeeDTO> EmployeesList { get; set; }
        public DepartmentDTO()
        {
            // EmployeesList = new List<EmployeeDTO>();
            //CompanyList = new List<CompanyDTO>();
            //CompanyList = new CompanyDTO();
        }
    }
}
