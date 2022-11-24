using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelManage.Domain.Entities;

namespace TravelManage.Infra.Data.Context.Mappings
{
    public class ProprietariosMap : IEntityTypeConfiguration<Proprietarios>
    {
        public void Configure(EntityTypeBuilder<Proprietarios> builder)
        {
            builder.ToTable("proprietarios");

            builder.Property(x => x.Agencia).HasColumnName("agencia");
            builder.Property(x => x.Banco).HasColumnName("banco");
            builder.Property(x => x.Cnh).HasColumnName("cnh");
            builder.Property(x => x.Conta).HasColumnName("conta");

            builder.HasOne<Pessoas>(x => x.Pessoa)
               .WithOne(x => x.Proprietario)
               .HasForeignKey<Proprietarios>(x => x.Id);
        }
    }
}
