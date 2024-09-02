using frappe_HRMS.Domain.Base;
using frappe_HRMS.Domain.Company;
using frappe_HRMS.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace frappe_HRMS.Domain.Employee
{
    public class Employee : BaseEntity
    {
        public string Series => $"HR-EMP-00{Id.ToString()}";
        public GenderEnum Gender { get; set; }
        public string? FirsetName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime DateofJoining { get; set; }
        public DateTime DateOfBirth { get; set; }
        public StatusEnum Status { get; set; }
        public SalutationEnum Salutation { get; set; }
        public int? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User? User { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company.Company? Company { get; set; }
        public int? DesignationId { get; set; }
        [ForeignKey(nameof(DesignationId))]
        public virtual Designation? Designation { get; set; }
        public int? BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch? Branch { get; set; }
        public int? EmployeeGradeId { get; set; }
        [ForeignKey(nameof(EmployeeGradeId))]
        public virtual EmployeeGrade? EmployeeGrade { get; set; }
        public int? EmploymentTypeId { get; set; }
        [ForeignKey(nameof(EmploymentTypeId))]
        public virtual EmploymentType? EmploymentType { get; set; }
        public string? ReportsTo { get; set; }
    }
}
