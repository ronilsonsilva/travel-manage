using FluentValidation.Results;

namespace TravelManage.Domain.Entities
{
    public class Pessoas : BaseEntity
    {
        public Pessoas() { }

        public Pessoas(string cpf, string nome, string endereco, string telefone, SexoEnum sexo, string email)
        {
            Cpf = cpf;
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Sexo = sexo;
            Email = email;
        }

        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public SexoEnum Sexo { get; set; }
        public string Email { get; set; }

        public Passageiros Passageiro { get; set; }
        public Motoristas Motorista { get; set; }
        public Proprietarios Proprietario { get; set; }

        public override ValidationResult Validate()
        {
            return new ValidationResult();
        }
    }
}
