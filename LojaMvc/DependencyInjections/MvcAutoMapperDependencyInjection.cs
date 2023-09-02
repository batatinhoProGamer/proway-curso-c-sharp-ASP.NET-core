using AutoMapper;
using LojaMvc.Mappers;
using LojaMvc.Models.Produto;
using LojaServicos.Dtos.Produtos;

namespace LojaMvc.DependencyInjections
{
    public static class MvcAutoMapperDependencyInjection
    {
        public static IServiceCollection AddMvcAutoMapper(this IServiceCollection services)
        {
            var mapperConfiguration = new MapperConfiguration(x =>
            {
                x.CreateMap<ProdutoCadastroViewModel, ProdutoCadastrarDto>();
                x.CreateMap<ProdutoIndexDto, ProdutoEditarViewModel>();
                x.CreateMap<ProdutoEditarViewModel, ProdutoEditarDto>();
                x.AddProfile<AutenticacaoMapper>();
            });

            var mapper = mapperConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
