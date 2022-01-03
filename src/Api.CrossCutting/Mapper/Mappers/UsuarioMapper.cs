using Api.Domain.Dto;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mapper.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
