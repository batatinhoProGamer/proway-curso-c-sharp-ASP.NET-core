using AutoMapper;
using LojaApi.Controllers;
using LojaApi.Models.Cliente;
using LojaApi.Models.Produto;
using LojaServicos.Dtos.Clientes;
using LojaServicos.Dtos.Produtos;
using LojaServicos.Mappers;

namespace LojaApi.DependencyInjections
{
    public static class ApiAutoMapperDependencyInjections
    {
        public static IServiceCollection AddApiAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<ClienteCreateModel, ClienteCadastroDto>();
                x.CreateMap<ProdutoCreateModel, ProdutoCadastrarDto>();
                x.CreateMap<ProdutoUpdateModel, ProdutoEditarDto>();
                x.AddProfile<ClienteMapper>();
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
