using AutoMapper;
using LojaApi.Models.Autenticacao;
using LojaRepositorios.ExtensionsMethods;
using LojaServicos.Dtos.Autenticacao;

namespace LojaApi.Mappers;

public class AutenticarMapper : Profile
{
    public AutenticarMapper()
    {
        CreateMap<AutenticacaoModel, AutenticarDto>()
            .ForMember(x => x.Senha, opt => opt.MapFrom(y => y.Senha.Hash512()));
    }
}