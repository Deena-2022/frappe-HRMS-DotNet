using frappe_HRMS.Domain.Base;

namespace frappe_HRMS.Domain
{
    public class User : BaseEntity
    {
        public string? SiteName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }       
        public string? Email { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public string? Password { get; set; }
    }
}
