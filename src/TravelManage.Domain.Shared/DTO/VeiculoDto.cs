namespace TravelManage.Domain.Shared.DTO
{
    public class VeiculoDto : BaseDto
    {
        public int IdProprietario { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabric { get; set; }
        public int CapacidadePass { get; set; }
        public string Cor { get; set; }
        public TipoCombustivelEnumDto TipoCombustivel { get; set; }
        public int PotenciaMotor { get; set; }

        public string Descricao => $"{Placa} - {Marca} - {Modelo}";
    }
}
