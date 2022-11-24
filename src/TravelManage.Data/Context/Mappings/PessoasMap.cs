using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TravelManage.Infra.Data.Context.Mappings
{
    public class PessoasMap : BaseMap<Pessoas>
    {
        public PessoasMap(string nomeTabela = "pessoas") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Pessoas> builder)
        {
            builder.Property(x => x.Endereco).HasColumnName("endereco");
            builder.Property(x => x.Sexo).HasColumnName("sexo");
            builder.Property(x => x.Cpf).HasColumnName("cpf");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.Nome).HasColumnName("nome");
            builder.Property(x => x.Telefone).HasColumnName("telefone");

            base.Configure(builder);
        }
    }
}
