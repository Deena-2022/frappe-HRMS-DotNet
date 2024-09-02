using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOC.Dto.ResponseDto.BaseDto
{
    public class LoginResponseDto : BaseResponseDto
    {
        public string Token { get; set; }
    }
}
