using frappe_HRMS.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace frappe_HRMS.Domain.Company
{
    public class Designation : BaseEntity
    {
        public string? DesignationName { get; set; }
    }
}
