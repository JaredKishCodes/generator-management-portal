

using AutoMapper;
using MediatR;
using ReecsPortal.Application.DTOs.Customer;
using ReecsPortal.Domain.DTradeModels;
using ReecsPortal.Domain.Interfaces;

namespace ReecsPortal.Application.Customer.Commands
{
    public record CreateCustomerCommand(CustRequest customerRequest) : IRequest<CustResponse>;
    public class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        : IRequestHandler<CreateCustomerCommand, CustResponse>
    {
        public async Task<CustResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if (request == null) 
                throw new ArgumentNullException(nameof(request),"Customer request cannot be null");

            var customer =  mapper.Map<TblCustomer>(request.customerRequest);
            if (customer == null)
                throw new InvalidOperationException("Failed to map customer request to TblCustomer");
            
            var createdCustomer = await customerRepository.CreateCustomer(customer);
                if (createdCustomer == null)
                    throw new ArgumentNullException(nameof(createdCustomer),"Failed to create in customer repository");
            var response = mapper.Map<CustResponse>(createdCustomer);

            return response;


        }
    }
}
