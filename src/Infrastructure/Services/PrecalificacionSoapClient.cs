using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ProxiFiltros.Application.Interfaces;
using ProxiFiltros.Domain.Entities;

namespace ProxiFiltros.Infrastructure.Services
{
    public class PrecalificacionSoapClient : IPrecalificacionSoapClient
    {
        private readonly HttpClient _httpClient;
        private const string SoapAction = "http://tempuri.org/EvaluarPwcPrecalificacion";

        public PrecalificacionSoapClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> SendRequestAsync(PrecalificacionRequest request)
        {
            var envelope = BuildEnvelope(request);
            var content = new StringContent(envelope, Encoding.UTF8, "text/xml");
            content.Headers.Add("SOAPAction", SoapAction);
            var response = await _httpClient.PostAsync(string.Empty, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private static string BuildEnvelope(PrecalificacionRequest request)
        {
            var bodyBuilder = new StringBuilder();
            var data = request.ToDatosPrecalificador;
            bodyBuilder.Append($"<NumeroCotizacion>{data.NumeroCotizacion}</NumeroCotizacion>");
            bodyBuilder.Append($"<NumeroDocumento>{data.NumeroDocumento}</NumeroDocumento>");
            bodyBuilder.Append($"<I062TipoDocumento>{data.I062TipoDocumento}</I062TipoDocumento>");
            bodyBuilder.Append($"<ApellidoPaterno>{data.ApellidoPaterno}</ApellidoPaterno>");
            bodyBuilder.Append($"<FechaNacimiento>{data.FechaNacimiento}</FechaNacimiento>");
            bodyBuilder.Append($"<Nacionalidad>{data.Nacionalidad}</Nacionalidad>");
            bodyBuilder.Append($"<I309EstadoCivil>{data.I309EstadoCivil}</I309EstadoCivil>");
            bodyBuilder.Append($"<I067TipoPersona>{data.I067TipoPersona}</I067TipoPersona>");
            bodyBuilder.Append($"<FechaInicioLabores>{data.FechaInicioLabores}</FechaInicioLabores>");
            bodyBuilder.Append($"<FechaFinLabores>{data.FechaFinLabores}</FechaFinLabores>");
            bodyBuilder.Append($"<TotalIngresoMensualSoles>{data.TotalIngresoMensualSoles}</TotalIngresoMensualSoles>");
            bodyBuilder.Append($"<TotalIngresoMensualConyugalSoles>{data.TotalIngresoMensualConyugalSoles}</TotalIngresoMensualConyugalSoles>");
            bodyBuilder.Append($"<I815CategoriaLaboral>{data.I815CategoriaLaboral}</I815CategoriaLaboral>");
            bodyBuilder.Append($"<PlanCredito>{data.PlanCredito}</PlanCredito>");
            bodyBuilder.Append($"<MonedaCredito>{data.MonedaCredito}</MonedaCredito>");
            bodyBuilder.Append($"<Plazo>{data.Plazo}</Plazo>");
            bodyBuilder.Append($"<MontoVehiculoDolar>{data.MontoVehiculoDolar}</MontoVehiculoDolar>");
            bodyBuilder.Append($"<PorcentajeCuotaInicial>{data.PorcentajeCuotaInicial}</PorcentajeCuotaInicial>");
            bodyBuilder.Append($"<MontoCuotaInicialMoneda>{data.MontoCuotaInicialMoneda}</MontoCuotaInicialMoneda>");
            bodyBuilder.Append($"<MontoSeguroMoneda>{data.MontoSeguroMoneda}</MontoSeguroMoneda>");
            bodyBuilder.Append($"<MontoCuotaMoneda>{data.MontoCuotaMoneda}</MontoCuotaMoneda>");
            bodyBuilder.Append($"<CuotaReprogramadaDolar>{data.CuotaReprogramadaDolar}</CuotaReprogramadaDolar>");
            bodyBuilder.Append($"<tem:TipoCambioCalculo>{data.TipoCambioCalculo}</tem:TipoCambioCalculo>");
            bodyBuilder.Append($"<tem:PuntajeScore>{data.PuntajeScore}</tem:PuntajeScore>");
            if (!string.IsNullOrEmpty(data.NivelScore))
            {
                bodyBuilder.Append($"<tem:NivelScore>{data.NivelScore}</tem:NivelScore>");
            }
            var toDatos = bodyBuilder.ToString();
            var soap = new StringBuilder();
            soap.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            soap.Append("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:tem=\"http://tempuri.org/\">");
            soap.Append("<soapenv:Header/>");
            soap.Append("<soapenv:Body>");
            soap.Append("<tem:EvaluarPwcPrecalificacion>");
            soap.Append($"<tem:toDatosPrecalificador>{toDatos}</tem:toDatosPrecalificador>");
            soap.Append($"<tem:idOpcion>{request.IdOpcion}</tem:idOpcion>");
            soap.Append("</tem:EvaluarPwcPrecalificacion>");
            soap.Append("</soapenv:Body></soapenv:Envelope>");
            return soap.ToString();
        }
    }
}
