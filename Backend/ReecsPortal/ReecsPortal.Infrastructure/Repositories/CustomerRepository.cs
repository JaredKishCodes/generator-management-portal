using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReecsPortal.Domain.DTradeModels;
using ReecsPortal.Domain.Interfaces;
using ReecsPortal.Infrastructure.Auth.Persistence;

namespace ReecsPortal.Infrastructure.Repositories
{
    public class CustomerRepository(DtradeDbContext _context) : ICustomerRepository
    {
        public async Task<TblCustomer?> CreateCustomer(TblCustomer customer)
        {
          await _context.AddAsync(customer);
         await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteCustomer(int custCode)
        {
          var customer =   await _context.TblCustomers.FirstOrDefaultAsync(c => c.CustCode == custCode);
            if(customer != null)
            {
                _context.TblCustomers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<TblCustomer?> GetCustomerByIdAsync(int custCode)
        {
            var customer = await _context.TblCustomers.FirstOrDefaultAsync(c => c.CustCode == custCode);
            if (customer == null)
                throw new Exception($"Customer with ID {custCode} not found.");

            return customer;
        }

        public async Task<IEnumerable<TblCustomer>> GetCustomersAsync()
        {
            return await _context.TblCustomers.ToListAsync();
        }

        public async Task<TblCustomer?> UpdateCustomer(TblCustomer updatedCustomer, int custCode)
        {
            var existingCustomer = await _context.TblCustomers.FindAsync(custCode);
            if (existingCustomer == null)
                throw new Exception("Customer not found for update.");

            existingCustomer.CustName = updatedCustomer.CustName;
            existingCustomer.CustAddress = updatedCustomer.CustAddress;
            existingCustomer.DemandMw = updatedCustomer.DemandMw;
            existingCustomer.RegPrice = updatedCustomer.RegPrice;
            existingCustomer.ModifiedBy = updatedCustomer.ModifiedBy;
            existingCustomer.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return existingCustomer;
        }

    }
}
