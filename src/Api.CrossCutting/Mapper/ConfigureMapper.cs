using Api.CrossCutting.Mapper.Mappers;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CrossCutting.Mapper
{
    public static class ConfigureMapper
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsuarioMapper());
                cfg.AddProfile(new EmpresaMapper());
                cfg.AddProfile(new FuncionarioMapper());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
