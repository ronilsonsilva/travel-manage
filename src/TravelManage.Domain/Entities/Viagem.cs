using FluentValidation.Results;

namespace TravelManage.Domain.Entities
{
    public class Viagem : BaseEntity
    {
        public Viagem(int idPassageiro, int idMotorista, int idVeiculo, string localOrigem, string localDestino, DateTime dataHoraInicio, int quantidadePassageiros, int formaPagamento)
        {
            IdPassageiro = idPassageiro;
            IdMotorista = idMotorista;
            IdVeiculo = idVeiculo;
            LocalOrigem = localOrigem;
            LocalDestino = localDestino;
            DataHoraInicio = dataHoraInicio;
            QuantidadePassageiros = quantidadePassageiros;
            FormaPagamento = formaPagamento;
        }

        protected Viagem() { }

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

        public Motoristas Motorista { get; set; }
        public Passageiros Passageiro { get; set; }
        public Veiculo Veiculo { get; set; }

        public override ValidationResult Validate()
        {
            return new ValidationResult();
        }
    }
}
