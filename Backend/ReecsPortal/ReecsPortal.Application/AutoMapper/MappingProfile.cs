
using AutoMapper;
using ReecsPortal.Application.DTOs;
using ReecsPortal.Application.DTOs.Auth;
using ReecsPortal.Application.DTOs.Customer;
using ReecsPortal.Application.Generators.Query;
using ReecsPortal.Domain.DTradeModels;
using ReecsPortal.Infrastructure.DTradeModels;

namespace ReecsPortal.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthResponseDto, LoginDto>().ReverseMap();
            CreateMap<LoginDto, AuthResponseDto>().ReverseMap();
            CreateMap<GenResponse, GetAllGeneratorsQuery>().ReverseMap();
            CreateMap<GetAllGeneratorsQuery, GenResponse>().ReverseMap();
            CreateMap<TblGenerator, GenResponse>().ReverseMap();
            CreateMap<TblGenerator, GenRequest>().ReverseMap();
            CreateMap<UpdateGenRequest, TblGenerator>().ReverseMap();
            CreateMap<TblCustomer, CustResponse>().ReverseMap();
            CreateMap<TblCustomer, CustRequest>().ReverseMap();
            CreateMap<TblCustomer,UpdateCustRequest>().ReverseMap();

        }
    }
}
 
