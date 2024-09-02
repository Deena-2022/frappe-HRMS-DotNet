using frappe_HRMS.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frappe_HRMS.Domain.Company
{
    public class Department : BaseEntity
    {
        public string? DepartmentName { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company? Company { get; set; }
        public string? DepartmentDescription => $"{DepartmentName} - {Company?.CompanyAbbrevation}";
        public string? ParentDepartment {  get; set; }
        public string? PayrollCostCenter { get; set; }
        public bool IsGroup { get; set; }
        public bool Disabled { get; set; }

    }
}
