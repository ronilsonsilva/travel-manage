using Microsoft.EntityFrameworkCore;
using TravelManage.Infra.Data.Context.Mappings;

namespace TravelManage.Infra.Data.Context
{
    public class TravelManageContext : DbContext
    {
        public TravelManageContext()
        {
        }

        public TravelManageContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var connection = "Server=localhost,1433;Database=car_shop;User Id=sa;Password=Sig@2022;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;Connection Timeout=30;";
            //optionsBuilder.UseSqlServer(connection);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MotoristasMap());
            modelBuilder.ApplyConfiguration(new MotoristaVeiculoMap());
            modelBuilder.ApplyConfiguration(new PassageirosMap());
            modelBuilder.ApplyConfiguration(new ProprietariosMap());
            modelBuilder.ApplyConfiguration(new TipoPagamentoMap());
            modelBuilder.ApplyConfiguration(new VeiculosMap());
            modelBuilder.ApplyConfiguration(new ViagemMap());
            modelBuilder.ApplyConfiguration(new PessoasMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
