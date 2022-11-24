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
using TravelManage.Domain.Shared.DTO;
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
            

            

            //services.AddScoped(typeof(IApplicationServices<PassageiroDto, CreatePassageiroDto, UpdatePassageiroDto, PassageiroDto>), typeof(ApplicationServices<Passageiros, PassageiroDto, CreatePassageiroDto, CreatePassageiroDto, PassageiroDto>));
            //services.AddScoped(typeof(IApplicationServices<MotoristaDto, CreateMotoristaDto, UpdateMotoristaDto, MotoristaDto>), typeof(ApplicationServices<Motoristas, MotoristaDto, CreateMotoristaDto, CreateMotoristaDto, MotoristaDto>));
            //services.AddScoped(typeof(IApplicationServices<ProprietarioDto, CreateProprietarioDto, UpdateProprietarioDto, ProprietarioDto>), typeof(ApplicationServices<Proprietarios, ProprietarioDto, CreateProprietarioDto, UpdateProprietarioDto, ProprietarioDto>));
            //services.AddScoped(typeof(IApplicationServices<TipoPagamentoDto, CreateTipoPagamentoDto, UpdateTipoPagamentoDto, TipoPagamentoDto>), typeof(ApplicationServices<TipoPagamento, TipoPagamentoDto, CreateTipoPagamentoDto, UpdateTipoPagamentoDto, TipoPagamentoDto>));
            //services.AddScoped(typeof(IApplicationServices<VeiculoDto, CreateVeiculoDto, UpdateVeiculoDto, VeiculoDto>), typeof(ApplicationServices<Veiculo, VeiculoDto, CreateVeiculoDto, UpdateVeiculoDto, PassageiroDto>));
            //services.AddScoped(typeof(IApplicationServices<ViagemDto, CreateViagemDto, UpdateViagemDto, ViagemDto>), typeof(ApplicationServices<Viagem, ViagemDto, CreateViagemDto, UpdateViagemDto, ViagemDto>));

            #endregion
        }
    }
}