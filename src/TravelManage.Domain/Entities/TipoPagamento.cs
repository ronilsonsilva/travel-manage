using FluentValidation.Results;

namespace TravelManage.Domain.Entities
{
    public class TipoPagamento : BaseEntity
    {
        public TipoPagamento(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }

        protected TipoPagamento() { }

        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public override ValidationResult Validate()
        {
            return new ValidationResult();
        }
    }
}
