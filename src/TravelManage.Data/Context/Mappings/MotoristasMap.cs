using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelManage.Domain.Entities;

namespace TravelManage.Infra.Data.Context.Mappings
{
    public class MotoristasMap : IEntityTypeConfiguration<Motoristas>
    {
        public void Configure(EntityTypeBuilder<Motoristas> builder)
        {
            builder.ToTable("motoristas");

            builder.Property(x => x.Agencia).HasColumnName("agencia");
            builder.Property(x => x.Banco).HasColumnName("banco");
            builder.Property(x => x.Cnh).HasColumnName("cnh");
            builder.Property(x => x.Conta).HasColumnName("conta");

            builder.HasOne<Pessoas>(x => x.Pessoa)
               .WithOne(x => x.Motorista)
               .HasForeignKey<Motoristas>(x => x.Id);
        }
    }
}
