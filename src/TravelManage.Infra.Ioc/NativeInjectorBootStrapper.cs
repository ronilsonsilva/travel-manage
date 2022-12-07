using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelManage.Application.AutoMappper;
using TravelManage.Application.Contracts;
using TravelManage.Application.Services;
using TravelManage.Domain.Contracts.DomainServices;
using TravelManage.Domain.Contracts.Repositories;
using TravelManage.Domain.DomainServices;
using TravelManage.Domain.Entities;
using TravelManage.Infra.Data.Context;
using TravelManage.Infra.Data.Repositories;

namespace TravelManage.Infra.Ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            #region [Configurations]

            var connection = configuration["CONNECTION_STRING:TravelManageContext"];
            services.AddDbContext<TravelManageContext>
                (options =>
                    options.UseNpgsql(connectionString: connection)
                );
            services.AddScoped<TravelManageContext, TravelManageContext>();

            // Configurar Automapper
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            #endregion

            #region [DI]

            services.AddScoped(typeof(IApplicationServices<,,,,>), typeof(ApplicationServices<,,,,>));
            services.AddScoped(typeof(IDomainServices<>), typeof(DomainService<>));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));

            services.AddScoped(typeof(IRepository<TipoPagamento>), typeof(TipoPagamentoRepository));
            services.AddScoped(typeof(IRepository<Viagem>), typeof(ViagemRepository));


            services.AddScoped<IReportApplicationServices, ReportApplicationServices>();
            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<ISeedDataApplication, SeedDataApplication>();

            #endregion
        }
    }
}