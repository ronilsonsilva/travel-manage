namespace TravelManage.WebApp.VierwModels
{
    public class ViagemViewModel
    {
        public int Id { get; set; }
        public int IdPassageiro { get; set; }
        public int IdMotorista { get; set; }
        public int IdVeiculo { get; set; }
        public string LocalOrigem { get; set; }
        public string LocalDestino { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public int QuantidadePassageiros { get; set; }
        public int FormaPagamento { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public decimal ValorPagamento { get; set; }
        public bool CaceladoMotorista { get; set; }
        public bool CaceladoPassageiro { get; set; }
    }
}
