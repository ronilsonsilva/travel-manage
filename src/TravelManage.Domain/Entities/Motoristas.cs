namespace TravelManage.Domain.Entities
{
    public class Motoristas : Pessoas
    {
        public Motoristas(string cnh, int banco, int agencia, int conta)
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
