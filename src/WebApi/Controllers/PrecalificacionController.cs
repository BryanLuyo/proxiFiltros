using Microsoft.AspNetCore.Mvc;
using ProxiFiltros.Application.Interfaces;
using ProxiFiltros.Domain.Entities;
using System.Threading.Tasks;

namespace ProxiFiltros.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrecalificacionController : ControllerBase
    {
        private readonly IPrecalificacionService _service;

        public PrecalificacionController(IPrecalificacionService service)
        {
            _service = service;
        }

        [HttpPost("evaluar")]
        public async Task<IActionResult> Evaluar([FromBody] PrecalificacionRequest request)
        {
            var result = await _service.EvaluarAsync(request);
            return Ok(new { soapResponse = result });
        }
    }
}
