using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReecsPortal.Application.DTOs;
using ReecsPortal.Infrastructure.DTradeModels;

namespace ReecsPortal.Application.Interfaces
{
    public interface IGeneratorService
    {
        Task<IEnumerable<TblGenerator>> GetAllGeneratorsAsync();
        Task<GenResponse> CreateGeneratorAsync(GenRequest generator);
        Task<GenResponse> UpdateGeneratorAsync(UpdateGenRequest generator, int genCode);
        Task<bool> DeleteGeneratorAsync(int id);
    }
}
