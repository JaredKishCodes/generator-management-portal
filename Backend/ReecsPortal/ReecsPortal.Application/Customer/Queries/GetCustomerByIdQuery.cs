using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReecsPortal.Application.DTOs.Customer;
using ReecsPortal.Domain.Interfaces;

namespace ReecsPortal.Application.Customer.Queries
{
    public record GetCustomerByIdQuery(int CustCode) : IRequest<CustResponse>;
    public class GetCustomerByIdQueryHandler(ICustomerRepository customerRepository,IMapper mapper)
        : IRequestHandler<GetCustomerByIdQuery, CustResponse>
    {
        public async Task<CustResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetCustomerByIdAsync(request.CustCode);
            if(customer == null) { 
                throw new ArgumentException("Customer not found", nameof(request.CustCode));
            }
            return  mapper.Map<CustResponse>(customer);
        }
    }
}
