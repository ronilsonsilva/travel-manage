namespace TravelManage.Domain.Entities
{
    public class Motoristas : Pessoas
    {
        public Motoristas(string cnh, int banco, int agencia, int conta, string cpf, string nome, string endereco, string telefone, SexoEnum sexo, string email) : base(cpf, nome, endereco, telefone, sexo, email)
        {
            Cnh = cnh;
            Banco = banco;
            Agencia = agencia;
            Conta = conta;
        }

        protected Motoristas() { }


        public string Cnh { get; set; }
        public int Banco { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }

        public Pessoas Pessoa { get; set; }
        public ICollection<Viagem> Viagems { get; set; }
        public ICollection<MotoristaVeiculo> Veiculos { get; set; }

    }
}
