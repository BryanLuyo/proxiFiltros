using System.Threading.Tasks;
using ProxiFiltros.Domain.Entities;

namespace ProxiFiltros.Application.Interfaces
{
    public interface IPrecalificacionSoapClient
    {
        Task<string> SendRequestAsync(PrecalificacionRequest request);
    }
}
