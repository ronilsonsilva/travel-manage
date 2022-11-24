using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelManage.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TravelManage.Infra.Data.Context.Mappings
{
    public class VeiculosMap : BaseMap<Veiculo>
    {
        public VeiculosMap(string nomeTabela = "veiculo") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.Property(x => x.Modelo).HasColumnName("modelo");
            builder.Property(x => x.AnoFabric).HasColumnName("anofabric");
            builder.Property(x => x.CapacidadePass).HasColumnName("capacidadepass");
            builder.Property(x => x.TipoCombustivel).HasColumnName("tipocombustivel");
            builder.Property(x => x.Placa).HasColumnName("placa");
            builder.Property(x => x.Cor).HasColumnName("cor");
            builder.Property(x => x.Marca).HasColumnName("marca");
            builder.Property(x => x.PotenciaMotor).HasColumnName("potenciamotor");
            builder.Property(x => x.IdProprietario).HasColumnName("idproprietario");

            builder.HasOne(x => x.Proprietario)
                .WithMany(x => x.Veiculos)
                .HasForeignKey(x => x.IdProprietario);

            base.Configure(builder);
        }
    }
}
