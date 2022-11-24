namespace TravelManage.Domain.Entities
{
    public class Passageiros : Pessoas
    {
        public Passageiros(string cartaoCredito, string bandeiraCartao, string cidadeOrig)
        {
            CartaoCredito = cartaoCredito;
            BandeiraCartao = bandeiraCartao;
            CidadeOrig = cidadeOrig;
        }

        protected Passageiros() { }

        public string CartaoCredito { get; set; }
        public string BandeiraCartao { get; set; }
        public string CidadeOrig { get; set; }

        public Pessoas Pessoa { get; set; }
        public ICollection<Viagem> Viagems { get; set; }
    }
}
