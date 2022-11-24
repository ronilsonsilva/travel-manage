using AutoMapper;
using TravelManage.Domain.Entities;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.Application.AutoMappper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Motoristas, MotoristaDto>().ReverseMap();
            CreateMap<Motoristas, CreateMotoristaDto>().ReverseMap();
            CreateMap<Motoristas, UpdateMotoristaDto>().ReverseMap();

            CreateMap<Passageiros, PassageiroDto>().ReverseMap();
            CreateMap<Passageiros, CreatePassageiroDto>().ReverseMap();
            CreateMap<Passageiros, UpdatePassageiroDto>().ReverseMap();

            CreateMap<Proprietarios, ProprietarioDto>().ReverseMap();
            CreateMap<Proprietarios, CreateProprietarioDto>().ReverseMap();
            CreateMap<Proprietarios, UpdateProprietarioDto>().ReverseMap();

            CreateMap<TipoPagamento, TipoPagamentoDto>().ReverseMap();
            CreateMap<TipoPagamento, CreateTipoPagamentoDto>().ReverseMap();
            CreateMap<TipoPagamento, UpdateTipoPagamentoDto>().ReverseMap();

            CreateMap<Veiculo, VeiculoDto>().ReverseMap();
            CreateMap<Veiculo, CreateVeiculoDto>().ReverseMap();
            CreateMap<Veiculo, UpdateVeiculoDto>().ReverseMap();

            CreateMap<Viagem, ViagemDto>().ReverseMap();
            CreateMap<Viagem, CreateViagemDto>().ReverseMap();
            CreateMap<Viagem, UpdateViagemDto>().ReverseMap();
            CreateMap<Viagem, ListViagemDto>()
                .ForMember(x => x.NomePassageiro, t => t.MapFrom(viagem => viagem.Passageiro.Nome))
                .ForMember(x => x.CpfPassageiro, t => t.MapFrom(viagem => viagem.Passageiro.Cpf))
                .ForMember(x => x.NomeMotorista, t => t.MapFrom(viagem => viagem.Motorista.Nome))
                .ForMember(x => x.CpfMotorista, t => t.MapFrom(viagem => viagem.Motorista.Cpf))
                .ForMember(x => x.PlacaVeiculo, t => t.MapFrom(viagem => viagem.Veiculo.Placa));
        }
    }
}
