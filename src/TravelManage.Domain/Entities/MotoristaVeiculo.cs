using FluentValidation.Results;

namespace TravelManage.Domain.Entities
{
    public class MotoristaVeiculo : BaseEntity
    {
        protected MotoristaVeiculo() { }

        public MotoristaVeiculo(int idMotorista, int idVeiculo)
        {
            IdMotorista = idMotorista;
            IdVeiculo = idVeiculo;
        }

        public int IdMotorista { get; set; }
        public int IdVeiculo { get; set; }

        public Motoristas Motoristas { get; set; }
        public Veiculo Veiculo { get; set; }

        public override ValidationResult Validate()
        {
            return new ValidationResult();
        }
    }
}
