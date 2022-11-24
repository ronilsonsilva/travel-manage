namespace TravelManage.Domain.Shared.DTO
{
    public class ListViagemDto : ViagemDto
    {
        public string NomeMotorista { get; set; }
        public string CpfMotorista { get; set; }
        public string Motorista => CpfMotorista + " - " + NomeMotorista;
        public string Passageiro => CpfPassageiro + " - " + NomePassageiro;
        public string NomePassageiro { get; set; }
        public string CpfPassageiro { get; set; }
        public string PlacaVeiculo { get; set; }
    }
}
