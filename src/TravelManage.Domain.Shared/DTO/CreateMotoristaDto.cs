namespace TravelManage.Domain.Shared.DTO
{
    public class CreateMotoristaDto
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public SexoEnumDto Sexo { get; set; }
        public string Email { get; set; }
        public string Cnh { get; set; }
        public int Banco { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
    }
}
