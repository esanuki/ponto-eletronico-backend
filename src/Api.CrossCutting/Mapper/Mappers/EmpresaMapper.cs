using Api.Domain.Dto;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mapper.Mappers
{
    public class EmpresaMapper : Profile
    {
        public EmpresaMapper()
        {
            CreateMap<Empresa, EmpresaDto>()
                .ForMember(dest => dest.Email, src => src.MapFrom(e => e.Usuario != null ? e.Usuario.Email : ""))
                .ForMember(dest => dest.Senha, src => src.MapFrom(e => e.Usuario != null ? e.Usuario.Senha : ""));

        }
    }
}
