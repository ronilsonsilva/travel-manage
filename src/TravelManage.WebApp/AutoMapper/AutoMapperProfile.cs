using AutoMapper;
using TravelManage.Domain.Shared.DTO;

namespace TravelManage.WebApp.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateViagemDto, ViagemDto>().ReverseMap();
            CreateMap<UpdateViagemDto, ViagemDto>().ReverseMap();
            CreateMap<UpdateMotoristaDto, MotoristaDto>().ReverseMap();
            CreateMap<UpdatePassageiroDto, PassageiroDto>().ReverseMap();
            CreateMap<UpdateProprietarioDto, ProprietarioDto>().ReverseMap();
            CreateMap<UpdateTipoPagamentoDto, TipoPagamentoDto>().ReverseMap();
            CreateMap<UpdateVeiculoDto, VeiculoDto>().ReverseMap();
        }
    }
}
