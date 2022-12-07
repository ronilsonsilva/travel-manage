namespace TravelManage.Domain.Shared.ReportModels
{
    public class TopFaturamentoReport
    {
        public int IdProprietario { get; set; }
        public int QuantidadeViagem { get; set; }
        public decimal Faturamento { get; set; }
        public string NomeProprietario { get; set; }
    }
}
