using BOC.Domain.Base;

namespace BOC.Domain.DataEntity
{
    public class Customer : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone_Number { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public bool IsDeleted { get; set; }
    }
}
