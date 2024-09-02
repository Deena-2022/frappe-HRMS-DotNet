using BOC.Dto.ResponseDto.BaseDto; 

namespace BOC.Dto.ResponseDto
{
    public class CustomerUpdateResponseDto : BaseResponseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone_Number { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
    }
}
