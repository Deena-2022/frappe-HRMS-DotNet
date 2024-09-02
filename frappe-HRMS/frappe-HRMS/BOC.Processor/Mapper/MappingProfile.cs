using AutoMapper;
using BOC.Domain.DataEntity;
using BOC.Dto.ResponseDto;
using BOC.Processor.Processor.CustomerProcessor.Commands;
using BOC.Processor.Processor.OpportunityProcessor.Commands;
using BOC.Processor.Processor.UserProfileProcessor.Commands;

namespace BOC.Processor.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerCreateCommand, Customer>();

            CreateMap<CustomerUpdateCommand, Customer>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Customer.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer.Name))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Customer.Email))
           .ForMember(dest => dest.Phone_Number, opt => opt.MapFrom(src => src.Customer.Phone_Number))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
           .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Customer.City))
           .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Customer.State))
           .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Customer.PostalCode)); 

            CreateMap<CustomerCreateCommand, CustomerCreateResponseDto>()
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer.Name))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Customer.Email))
           .ForMember(dest => dest.Phone_Number, opt => opt.MapFrom(src => src.Customer.Phone_Number))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
           .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Customer.City))
           .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Customer.State))
           .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Customer.PostalCode));

            CreateMap<CustomerUpdateCommand, CustomerUpdateResponseDto>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Customer.Id))
           .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Customer.Name))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Customer.Email))
           .ForMember(dest => dest.Phone_Number, opt => opt.MapFrom(src => src.Customer.Phone_Number))
           .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Customer.Address))
           .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Customer.City))
           .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Customer.State))
           .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.Customer.PostalCode));

            CreateMap<Customer, CustomerResponseDto>();

            CreateMap<UserCreateCommand, User>();

            CreateMap<UserCreateCommand, UserCreateResponseDto>();

            CreateMap<OpportunityCreateCommand, Opportunity>();

            CreateMap<OpportunityCreateCommand, OpportunityCreateResponseDto>();

            CreateMap<OpportunityUpdateCommand, Opportunity>();

            CreateMap<OpportunityUpdateCommand, OpportunityCreateResponseDto>();

            CreateMap<Opportunity, OpportunityResponseDto>();

            CreateMap<UserUpdateCommand, User>();

            CreateMap<UserUpdateCommand, UserCreateResponseDto>();

            CreateMap<User, UserResponseDto>();
        }
    }
}
