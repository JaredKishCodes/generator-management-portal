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
           await _context.TblGenerators.AddAsync(generator);
           await _context.SaveChangesAsync();
           return generator;
                
        }

        public async Task<bool> DeleteGeneratorAsync(int id)
        {
            var gen = await _context.TblGenerators.FindAsync(id);
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

        public async Task<TblGenerator> GetGeneratorByCodeAsync(TblGenerator generator)
        {
           return await _context.TblGenerators.FirstOrDefaultAsync(g => g.GenCode == generator.GenCode);
        }

        public async Task<TblGenerator> UpdateGeneratorAsync(TblGenerator generator)
        {
            _context.TblGenerators.Update(generator);
            await _context.SaveChangesAsync();
            return generator;
        }
    }
}
