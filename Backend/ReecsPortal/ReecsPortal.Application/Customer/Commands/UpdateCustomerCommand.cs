using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using ReecsPortal.Application.DTOs.Customer;
using ReecsPortal.Domain.DTradeModels;
using ReecsPortal.Domain.Interfaces;

namespace ReecsPortal.Application.Customer.Commands
{
    public record UpdateCustomerCommand(int custCode, UpdateCustRequest custRequest) : IRequest<CustResponse>;

    public class UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
     : IRequestHandler<UpdateCustomerCommand, CustResponse>
    {
        public async Task<CustResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomer = await customerRepository.GetCustomerByIdAsync(request.custCode);
            if (existingCustomer == null)
                throw new KeyNotFoundException($"Customer with ID {request.custCode} not found");

            mapper.Map(request.custRequest, existingCustomer);

        
            var updatedCustomer = await customerRepository.UpdateCustomer(existingCustomer, request.custCode);
            if (updatedCustomer == null)
                throw new InvalidOperationException("Failed to update customer in repository");
          
            return mapper.Map<CustResponse>(updatedCustomer);
        }
    }

}
