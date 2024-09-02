using System.ComponentModel.DataAnnotations;

namespace frappe_HRMS.Domain.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get;set; }
        public DateTime? CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public bool Enable {  get; set; } = true;
    }
}
