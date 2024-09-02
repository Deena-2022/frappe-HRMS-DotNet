using frappe_HRMS.Domain.Base;

namespace frappe_HRMS.Domain.Company
{
    public class Branch : BaseEntity
    {
        public string? BranchName { get; set; }
    }
}
