

using ReecsPortal.Infrastructure.DTradeModels;

namespace ReecsPortal.Domain.Interfaces
{
    public interface IGeneratorRepository
    {
        Task<IEnumerable<TblGenerator>> GetAllGeneratorsAsync();

        Task<TblGenerator> GetGeneratorByCodeAsync(TblGenerator generator);
        Task<TblGenerator> CreateGeneratorAsync(TblGenerator generator);
        Task<TblGenerator> UpdateGeneratorAsync(TblGenerator generator);
        Task<bool> DeleteGeneratorAsync(int id);

    }
}
