using AutoMapper;
using LojaRepositorios.entidades;
using LojaServicos.Dtos.Clientes;

namespace LojaServicos.Mappers
{
    public class ClienteMapper : Profile
    {
        public ClienteMapper()
        {
            CreateMap<ClienteCadastroDto, Cliente>()
                .ForMember(cliente => cliente.Nome, opt => opt.MapFrom(dto => dto.Nome.Trim()))
                .ForPath(cliente => cliente.Endereco.Estado, opt => opt.MapFrom(dto => dto.Estado))
                .ForPath(cliente => cliente.Endereco.Cidade, opt => opt.MapFrom(dto => dto.Cidade))
                .ForPath(cliente => cliente.Endereco.Bairro, opt => opt.MapFrom(dto => dto.Bairro))
                .ForPath(cliente => cliente.Endereco.Cep, opt => opt.MapFrom(dto => dto.Cep))
                .ForPath(cliente => cliente.Endereco.Logradouro, opt => opt.MapFrom(dto => dto.Logradouro))
                .ForPath(cliente => cliente.Endereco.Numero, opt => opt.MapFrom(dto => dto.Numero))
                .ForPath(cliente => cliente.Endereco.Complemento, opt => opt.MapFrom(dto => dto.Complemento));
        }
    }
}
