namespace TravelManage.Domain.Shared.ReportModels
{
    public class VeiculosByViagemReport
    {
        public int VeiculoId { get; set; }
        public int PassageiroId { get; set; }
        public int ViagemId { get; set; }
        public int MotoristaId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string LocalOrigem { get; set; }
        public string LocalDestino { get; set; }
        public string NomeMotorista { get; set; }
        public string NomePassageiro { get; set; }
    }
}
