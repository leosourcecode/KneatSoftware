using Contracts.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IStarshipService
    {
        Task<IEnumerable<Starship>> GetAllStarshipsAsync(double distanceInMegaLights);
    }
}
