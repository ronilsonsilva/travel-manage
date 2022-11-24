using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TravelManage.Infra.Data.Context.Mappings
{
    public class ViagemMap : BaseMap<Viagem>
    {
        public ViagemMap(string nomeTabela = "viagem") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Viagem> builder)
        {
            builder.Property(x => x.IdVeiculo).HasColumnName("idveiculo");
            builder.Property(x => x.IdMotorista).HasColumnName("idmotorista");
            builder.Property(x => x.CaceladoMotorista).HasColumnName("canceladomotorista");
            builder.Property(x => x.CaceladoPassageiro).HasColumnName("canceladopassageiro");
            builder.Property(x => x.DataHoraFim).HasColumnName("datahorafim");
            builder.Property(x => x.DataHoraInicio).HasColumnName("datahorainicio");
            builder.Property(x => x.FormaPagamento).HasColumnName("formapagamento");
            builder.Property(x => x.LocalDestino).HasColumnName("localdestino");
            builder.Property(x => x.LocalOrigem).HasColumnName("localorigem");
            builder.Property(x => x.QuantidadePassageiros).HasColumnName("quantidadepassageiros");
            builder.Property(x => x.ValorPagamento).HasColumnName("valorpagamento");
            builder.Property(x => x.IdPassageiro).HasColumnName("idpassageiro");

            builder.HasOne(x => x.Motorista)
                .WithMany(x => x.Viagems)
                .HasForeignKey(x => x.IdMotorista);

            builder.HasOne(x => x.Veiculo)
                .WithMany(x => x.Viagems)
                .HasForeignKey(x => x.IdVeiculo);

            builder.HasOne(x => x.Passageiro)
                .WithMany(x => x.Viagems)
                .HasForeignKey(x => x.IdPassageiro);

            base.Configure(builder);
        }
    }
}
