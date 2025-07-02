

using ReecsPortal.Application.DTOs;
using ReecsPortal.Application.Interfaces;
using ReecsPortal.Domain.Interfaces;
using ReecsPortal.Infrastructure.DTradeModels;

namespace ReecsPortal.Application.Services
{
    public class GeneratorService(IGeneratorRepository generatorRepository) : IGeneratorService
    {
        public Task<GenResponse> CreateGeneratorAsync(GenRequest generator)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGeneratorAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TblGenerator>> GetAllGeneratorsAsync()
        {
            var gen = await generatorRepository.GetAllGeneratorsAsync();
            if (gen == null) 
            { 
                throw new ArgumentNullException("Generator not found");
            }
            return gen;
        }

        public Task<GenResponse> UpdateGeneratorAsync(GenRequest generator)
        {
            throw new NotImplementedException();
        }
    }
}
