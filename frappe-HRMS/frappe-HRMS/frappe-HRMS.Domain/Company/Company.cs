using frappe_HRMS.Domain.Base;

namespace frappe_HRMS.Domain.Company
{
    public class Company : BaseEntity
    {
        public string? CompanyName { get; set; }
        public string? CompanyAbbrevation { get; set; }
        public string? Industry { get; set; }
        public string? NumberOfEmployess { get; set; }
        public string? Designation { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Language { get; set; }
        public string? Country { get; set; }
        public string? TimeZone { get; set; }
        public string? Currency { get; set; }
        public DateTime? FinancialYearBeginsOn { get; set; }
        public bool IsGroup { get; set; }
        public DateTime? DateofEstablishment { get; set; }
        public string? ParentCompany {  get; set; }
        public string? TaxID { get; set; }
        public string? Domain { get; set; }
        public bool IsDemo {  get; set; }
        public string? CompanyDescription => $"{CompanyName} - {CompanyAbbrevation}";
        public List<Employee.Employee>? Employees { get; set; }
    }   
}
