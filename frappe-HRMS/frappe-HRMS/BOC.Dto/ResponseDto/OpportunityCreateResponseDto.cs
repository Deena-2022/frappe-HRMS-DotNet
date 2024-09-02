using BOC.Domain.DataEntity;
using BOC.Dto.ResponseDto.BaseDto;

namespace BOC.Dto.ResponseDto
{
    public class OpportunityCreateResponseDto : BaseResponseDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? SalesPersonId { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Action { get; set; }
        public DateTime Due_Date { get; set; }
        public bool IsOpportunity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
