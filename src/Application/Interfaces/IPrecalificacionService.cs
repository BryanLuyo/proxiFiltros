using System.Threading.Tasks;
using ProxiFiltros.Domain.Entities;

namespace ProxiFiltros.Application.Interfaces
{
    public interface IPrecalificacionService
    {
        Task<string> EvaluarAsync(PrecalificacionRequest request);
    }
}
