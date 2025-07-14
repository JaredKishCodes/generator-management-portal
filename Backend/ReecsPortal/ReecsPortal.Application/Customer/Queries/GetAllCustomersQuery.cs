

using AutoMapper;
using MediatR;
using ReecsPortal.Application.DTOs.Customer;
using ReecsPortal.Domain.DTradeModels;
using ReecsPortal.Domain.Interfaces;

namespace ReecsPortal.Application.Customer.Queries
{
    public record GetAllCustomersQuery : IRequest<IEnumerable<CustResponse>>;
    public class GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper) : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustResponse>>
    {
        public async Task<IEnumerable<CustResponse>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {

            var customers =  await customerRepository.GetCustomersAsync();

            return mapper.Map<IEnumerable<CustResponse>>(customers);
        }
    }
}
