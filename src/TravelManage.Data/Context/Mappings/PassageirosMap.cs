using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelManage.Domain.Entities;

namespace TravelManage.Infra.Data.Context.Mappings
{
    public class PassageirosMap : IEntityTypeConfiguration<Passageiros>
    {
        public void Configure(EntityTypeBuilder<Passageiros> builder)
        {
            builder.ToTable("passageiros");

            builder.Property(x => x.CartaoCredito).HasColumnName("cartaocredito");
            builder.Property(x => x.CidadeOrig).HasColumnName("cidadeorig");
            builder.Property(x => x.BandeiraCartao).HasColumnName("bandeiracartao");

            builder.HasOne<Pessoas>(x => x.Pessoa)
                .WithOne(x => x.Passageiro)
                .HasForeignKey<Passageiros>(x => x.Id);

        }
    }
}
