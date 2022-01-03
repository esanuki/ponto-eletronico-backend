using Api.Domain.Dto;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mapper.Mappers
{
    public class FuncionarioMapper : Profile
    {
        public FuncionarioMapper()
        {
            CreateMap<Funcionario, FuncionarioDto>()
                .ForMember(dest => dest.Email, src => src.MapFrom(f => f.Usuario != null ? f.Usuario.Email : ""))
                .ForMember(dest => dest.Senha, src => src.MapFrom(f => f.Usuario != null ? f.Usuario.Senha : ""));
        }
    }
}
