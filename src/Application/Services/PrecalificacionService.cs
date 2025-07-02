using System.Threading.Tasks;
using ProxiFiltros.Application.Interfaces;
using ProxiFiltros.Domain.Entities;

namespace ProxiFiltros.Application.Services
{
    public class PrecalificacionService : IPrecalificacionService
    {
        private readonly IPrecalificacionSoapClient _client;

        public PrecalificacionService(IPrecalificacionSoapClient client)
        {
            _client = client;
        }

        public Task<string> EvaluarAsync(PrecalificacionRequest request)
        {
            return _client.SendRequestAsync(request);
        }
    }
}
