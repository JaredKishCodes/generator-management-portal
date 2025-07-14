

using MediatR;
using ReecsPortal.Domain.Interfaces;

namespace ReecsPortal.Application.Customer.Commands
{
    public record DeleteCustomerCommand(int CustCode) : IRequest<bool>;
    public class DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
        : IRequestHandler<DeleteCustomerCommand, bool>
    {
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetCustomerByIdAsync(request.CustCode);
            if (customer == null) 
                throw new ArgumentNullException(nameof(customer), $"Customer with ID {request.CustCode} not found.");

           var response =  await customerRepository.DeleteCustomer(request.CustCode);
            if (!response)
                throw new InvalidOperationException($"Failed to delete customer with ID {request.CustCode}.");

            return response;
        }
    }
}
