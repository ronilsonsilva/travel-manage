using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApp.VierwModels
{
    public class PassageiroViewModel
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public SexoEnumDto Sexo { get; set; }
        public string Email { get; set; }
        public string CartaoCredito { get; set; }
        public string BandeiraCartao { get; set; }
        public string CidadeOrig { get; set; }
    }
}
