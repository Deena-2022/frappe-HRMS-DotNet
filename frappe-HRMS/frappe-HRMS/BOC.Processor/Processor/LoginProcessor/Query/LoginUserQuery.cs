using BOC.Authentication;
using BOC.Dto.ResponseDto.BaseDto;
using Database.MSSQL.Context;
using Database.MSSQL.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;

namespace BOC.Processor.Processor.LoginProcessor.Query
{
    public class LoginUserQuery : IRequest<LoginResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginResponseDto>
        {
            private readonly IUnitOfWork unitOfWork;
            private readonly BOCContext context;
            private readonly Auth auth;
            public LoginUserQueryHandler(IUnitOfWork unitOfWork , BOCContext context)
            {
                this.unitOfWork = unitOfWork;
                this.context = context;
                this.auth = new Auth("25E8A7A58A9EE040EB651692F12D8B3A0B3D952DF04B54C8DE125C8E0155A9F6", context);
            }
            public async Task<LoginResponseDto> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                var token = auth.Authentication(request.Email, request.Password);
                return new LoginResponseDto { Token = token , Message = "Login Successfully!"};
            }
        }
    }
}
