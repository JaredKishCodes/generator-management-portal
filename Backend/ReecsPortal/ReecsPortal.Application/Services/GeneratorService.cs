

using System.Reflection.Emit;
using AutoMapper;
using ReecsPortal.Application.DTOs;
using ReecsPortal.Application.Interfaces;
using ReecsPortal.Domain.Interfaces;
using ReecsPortal.Infrastructure.DTradeModels;

namespace ReecsPortal.Application.Services
{
    public class GeneratorService(IGeneratorRepository generatorRepository, IMapper _mapper) : IGeneratorService
    {
        public async Task<GenResponse> CreateGeneratorAsync(GenRequest generator)
        {
            if (generator == null)
                throw new ArgumentNullException(nameof(generator), "Generator request cannot be null.");

            
            if (string.IsNullOrWhiteSpace(generator.GenName))
                throw new ArgumentException("Generator name is required.", nameof(generator.GenName));

            
            var gen = _mapper.Map<TblGenerator>(generator);
            if (gen == null)
                throw new InvalidOperationException("Failed to map GenRequest to TblGenerator.");

            
            var createdGen = await generatorRepository.CreateGeneratorAsync(gen);
            if (createdGen == null)
                throw new Exception("Generator creation failed in the repository.");

           
            var response = _mapper.Map<GenResponse>(createdGen);
            if (response == null)
                throw new InvalidOperationException("Failed to map TblGenerator to GenResponse.");
            return response;

        }

        public async Task<bool> DeleteGeneratorAsync(int genCode)
        {
            Console.WriteLine($"Deleting Generator with Code: {genCode}");
            if (genCode <= 0)
                throw new ArgumentException("GenCode must be a positive number.", nameof(genCode));

            var entity = await generatorRepository.GetGeneratorByCodeAsync(genCode);
            if (entity == null)
                throw new KeyNotFoundException($"Generator with code {genCode} not found.");

            var result = await generatorRepository.DeleteGeneratorAsync(entity.GenCode);

            if (!result)
                throw new Exception("Failed to delete the generator from the repository.");

            return true;
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

        public async Task<GenResponse?> UpdateGeneratorAsync(UpdateGenRequest generator, int genCode)
        {
            var existingGen = await generatorRepository.GetGeneratorByCodeAsync(genCode);
            if (existingGen == null)
                return null;

            // Map values from generator → existingGen
            _mapper.Map(generator, existingGen);

            // Save the updated entity
            var updatedGen = await generatorRepository.UpdateGeneratorAsync(existingGen, genCode);

            // Return mapped response DTO
            return _mapper.Map<GenResponse>(updatedGen);
        }



    }
}
