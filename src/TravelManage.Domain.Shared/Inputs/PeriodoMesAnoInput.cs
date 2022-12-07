namespace TravelManage.Domain.Shared.Inputs
{
    public class PeriodoMesAnoInput
    {
        public PeriodoMesAnoInput()
        {

        }
        public PeriodoMesAnoInput(int ano, int mes)
        {
            Ano = ano;
            Mes = mes;
        }

        public int Ano { get; set; }
        public int Mes { get; set; }
    }
}
