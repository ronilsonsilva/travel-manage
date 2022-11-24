namespace TravelManage.Domain.Shared.DTO
{
    public class CreateCarroDto
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabric { get; set; }
        public int CapacidadePass { get; set; }
        public string Cor { get; set; }
        public TipoCombustivelEnumDto TipoCompustivel { get; set; }
        public int PotenciaMotor { get; set; }
    }
}
