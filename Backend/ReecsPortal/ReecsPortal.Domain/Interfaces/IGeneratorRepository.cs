

using ReecsPortal.Infrastructure.DTradeModels;

namespace ReecsPortal.Domain.Interfaces
{
    public interface IGeneratorRepository
    {
        Task<IEnumerable<TblGenerator>> GetAllGeneratorsAsync();

        Task<TblGenerator> GetGeneratorByCodeAsync(int genCode);
        Task<TblGenerator> CreateGeneratorAsync(TblGenerator generator);
        Task<TblGenerator> UpdateGeneratorAsync(TblGenerator generator, int genCode);
        Task<bool> DeleteGeneratorAsync(int genCode);

    }
}
