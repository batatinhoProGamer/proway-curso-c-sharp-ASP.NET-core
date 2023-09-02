using LojaRepositorios.repositorios;
using LojaRepositorios.entidades;
using LojaServicos.Dtos.Clientes;
using AutoMapper;

namespace LojaServicos.servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        private readonly IMapper _mapper;

        public ClienteServico(IClienteRepositorio clienteRepositorio, IMapper mapper)
        {
            _clienteRepositorio = clienteRepositorio;
            _mapper = mapper;
        }

        public void Cadastrar(ClienteCadastroDto dto)
        {
            var cliente = _mapper.Map<Cliente>(dto);

            var clienteExistenteComCpf = _clienteRepositorio.ObterPorCpf(dto.Cpf);
            if (clienteExistenteComCpf != null)
                throw new Exception($"Cliente já cadastrado com CPF {dto.Cpf}");

            _clienteRepositorio.Add(cliente);
        }

        public void Apagar(int id)
        {
            _clienteRepositorio.DeleteLogic(id);
        }

        public List<ClienteIndexDto> ObterTodos(string? pesquisa)
        {
            var clientes = _clienteRepositorio.ObterTodos(pesquisa);

            var clientesDto = ConstruirClientesDto(clientes);

            return clientesDto;
        }

        private List<ClienteIndexDto> ConstruirClientesDto(List<Cliente> clientes)
        {
            var dtos = new List<ClienteIndexDto>();

            foreach (var cliente in clientes)
                dtos.Add(ClienteIndexDto.ConstruirComEntidade(cliente));

            return dtos;
        }

        public Cliente? ObterPorId(int id)
        {
            return _clienteRepositorio.GetById(id);
        }

        public void Editar(Cliente cliente)
        {
            _clienteRepositorio.Update(cliente);
        }
    }
}
