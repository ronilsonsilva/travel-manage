namespace TravelManage.Domain.Shared.Inputs
{
    public record VeiculoByIntervaloInput
    {
        public VeiculoByIntervaloInput()
        {

        }

        public VeiculoByIntervaloInput(string placa, DateTime inicio, DateTime fim)
        {
            Placa = placa;
            Inicio = inicio;
            Fim = fim;
        }

        public string Placa { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
    }
}
