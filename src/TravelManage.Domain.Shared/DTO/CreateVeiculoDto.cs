namespace TravelManage.Domain.Shared.DTO
{
    public class CreateVeiculoDto
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
        //public ICollection<int> Motoristas { get; set; }
    }

}
