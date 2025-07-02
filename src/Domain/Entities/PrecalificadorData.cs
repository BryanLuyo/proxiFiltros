namespace ProxiFiltros.Domain.Entities
{
    public class PrecalificadorData
    {
        public string NumeroCotizacion { get; set; }
        public string NumeroDocumento { get; set; }
        public string I062TipoDocumento { get; set; }
        public string ApellidoPaterno { get; set; }
        public string FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string I309EstadoCivil { get; set; }
        public string I067TipoPersona { get; set; }
        public string FechaInicioLabores { get; set; }
        public string FechaFinLabores { get; set; }
        public decimal TotalIngresoMensualSoles { get; set; }
        public decimal TotalIngresoMensualConyugalSoles { get; set; }
        public string I815CategoriaLaboral { get; set; }
        public string PlanCredito { get; set; }
        public string MonedaCredito { get; set; }
        public int Plazo { get; set; }
        public decimal MontoVehiculoDolar { get; set; }
        public int PorcentajeCuotaInicial { get; set; }
        public decimal MontoCuotaInicialMoneda { get; set; }
        public decimal MontoSeguroMoneda { get; set; }
        public decimal MontoCuotaMoneda { get; set; }
        public decimal CuotaReprogramadaDolar { get; set; }
        public decimal TipoCambioCalculo { get; set; }
        public int PuntajeScore { get; set; }
        public string? NivelScore { get; set; }
    }
}
