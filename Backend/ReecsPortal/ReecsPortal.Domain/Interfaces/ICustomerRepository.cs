

using ReecsPortal.Domain.DTradeModels;

namespace ReecsPortal.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<TblCustomer>> GetCustomersAsync();
        Task<TblCustomer?> GetCustomerByIdAsync(int custCode);
        Task<TblCustomer?> CreateCustomer(TblCustomer customer);
        Task<TblCustomer?> UpdateCustomer(TblCustomer customer, int custCode);
        Task<bool> DeleteCustomer(int custCode);
    }
}
