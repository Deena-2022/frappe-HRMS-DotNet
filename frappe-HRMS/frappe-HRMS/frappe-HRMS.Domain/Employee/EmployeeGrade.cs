using frappe_HRMS.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frappe_HRMS.Domain.Employee
{
    public class EmployeeGrade : BaseEntity
    {
        public string? Grade { get; set; }
        public string? DefaultSalaryStructure { get; set; }

    }
}
