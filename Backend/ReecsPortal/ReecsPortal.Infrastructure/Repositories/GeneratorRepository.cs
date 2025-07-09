using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReecsPortal.Domain.Interfaces;
using ReecsPortal.Infrastructure.Auth.Persistence;
using ReecsPortal.Infrastructure.DTradeModels;

namespace ReecsPortal.Infrastructure.Repositories
{
    public class GeneratorRepository(DtradeDbContext _context) : IGeneratorRepository
    {
        public async Task<TblGenerator> CreateGeneratorAsync(TblGenerator generator)
        {
            try
            {
                if (generator == null)
                    throw new ArgumentNullException(nameof(generator));

                await _context.TblGenerators.AddAsync(generator);
                await _context.SaveChangesAsync();

                return generator;
            }
            catch (DbUpdateException ex)
            {
                // Log or inspect this in debugger
                Console.WriteLine("DB Update Exception: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("Inner Exception: " + ex.InnerException.Message);

                throw; // rethrow to bubble up if needed
            }
        }



        public async Task<bool> DeleteGeneratorAsync(int genCode)
        {
            var gen = await _context.TblGenerators.FirstOrDefaultAsync(g => g.GenCode == genCode);
            if (gen != null) 
            { 
                _context.TblGenerators.Remove(gen);
               await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<TblGenerator>> GetAllGeneratorsAsync()
        {
            return await _context.TblGenerators.ToListAsync();
            
        }

        public async Task<TblGenerator> GetGeneratorByCodeAsync(int genCode)
        {
           return await _context.TblGenerators.FirstOrDefaultAsync(g => g.GenCode == genCode);
        }

        public async Task<TblGenerator?> UpdateGeneratorAsync(TblGenerator generator, int genCode)
        {
            var existingGen = await _context.TblGenerators
                .FirstOrDefaultAsync(g => g.GenCode == genCode); // or use primary key ID

            if (existingGen == null)
                return null;

            // Update fields
            existingGen.GenName = generator.GenName;
            existingGen.GenAddress = generator.GenAddress;
            existingGen.CapacityMw = generator.CapacityMw;
            existingGen.RegPrice = generator.RegPrice;

            await _context.SaveChangesAsync();
            return existingGen;
        }

    }
}
