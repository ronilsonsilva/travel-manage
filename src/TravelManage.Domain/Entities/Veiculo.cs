using FluentValidation.Results;

namespace TravelManage.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public Veiculo() { }

        public Veiculo(string placa, string marca, string modelo, int anoFabric, int capacidadePass, string cor, TipoCombustivelEnum tipoCompustivel, int potenciaMotor, int idProprietario)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            AnoFabric = anoFabric;
            CapacidadePass = capacidadePass;
            Cor = cor;
            TipoCombustivel = tipoCompustivel;
            PotenciaMotor = potenciaMotor;
            IdProprietario = idProprietario;
        }

        public int IdProprietario { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int AnoFabric { get; set; }
        public int CapacidadePass { get; set; }
        public string Cor { get; set; }
        public TipoCombustivelEnum TipoCombustivel { get; set; }
        public int PotenciaMotor { get; set; }

        public ICollection<Viagem> Viagems { get; set; }
        public ICollection<MotoristaVeiculo> Motoristas { get; set; }
        public Proprietarios Proprietario { get; set; }

        public override ValidationResult Validate()
        {
            return new ValidationResult();
        }
    }
}
