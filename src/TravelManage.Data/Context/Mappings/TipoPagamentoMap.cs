using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TravelManage.Domain.Entities;

namespace TravelManage.Infra.Data.Context.Mappings
{
    public class TipoPagamentoMap : IEntityTypeConfiguration<TipoPagamento>
    {
        public void Configure(EntityTypeBuilder<TipoPagamento> builder)
        {
            builder.ToTable("tipopagamento");

            builder.HasKey(x => x.Codigo);

            builder.Property(x => x.Descricao).HasColumnName("descricao");
            builder.Property(x => x.Codigo).HasColumnName("codigo");

            builder.Ignore(x => x.Id);
        }
    }
}
