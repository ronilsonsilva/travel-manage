namespace TravelManage.Domain.Shared.ReportModels
{
    public class FaturamentoVeiculoReport
    {
        public int IdProprietario { get; set; }
        public string PlacaVeiculo { get; set; }
        public int QuantidadeViagem { get; set; }
        public decimal TotalFaturamento { get; set; }
        public decimal MedioFaturamento
        {
            get
            {
                if (TotalFaturamento != 0 && QuantidadeViagem != 0)
                    return TotalFaturamento / QuantidadeViagem;
                return 0;
            }
        }
        public string NomeProprietario { get; set; }
    }
}
