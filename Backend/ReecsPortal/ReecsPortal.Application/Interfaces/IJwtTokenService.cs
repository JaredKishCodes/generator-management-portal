

using ReecsPortal.Domain.Entities;
using ReecsPortal.Infrastructure.DTradeModels;


namespace ReecsPortal.Application.Interfaces
{
    public interface IJwtTokenService
    {
        Task<string> CreateTokenAsync(TblUser user);
    }
}
