using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelManage.Domain.Entities;

namespace TravelManage.Infra.Data.Context.Mappings
{
    public class MotoristaVeiculoMap : BaseMap<MotoristaVeiculo>
    {
        public MotoristaVeiculoMap(string nomeTabela = "motoristaVeiculo") : base(nomeTabela)
        {
        }

        public override void Configure(EntityTypeBuilder<MotoristaVeiculo> builder)
        {
            builder.Property(x => x.IdVeiculo).HasColumnName("idveiculo");
            builder.Property(x => x.IdMotorista).HasColumnName("idmotorista");


            builder.HasOne(x => x.Veiculo)
                .WithMany(x => x.Motoristas)
                .HasForeignKey(x => x.IdMotorista);
            
            builder.HasOne(x => x.Motoristas)
                .WithMany(x => x.Veiculos)
                .HasForeignKey(x => x.IdVeiculo);


            base.Configure(builder);
        }
    }
}
