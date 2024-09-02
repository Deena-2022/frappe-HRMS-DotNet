using BOC.Domain.DataEntity;

namespace BOC.Dto.ResponseDto
{
    public class OpportunityResponseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int? SalesPersonId { get; set; }
        public User? SalesPerson { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Action { get; set; }
        public DateTime Due_Date { get; set; }
        public bool IsOpportunity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
