using LojaRepositorios.repositorios;
using LojaRepositorios.entidades;
using LojaServicos.Dtos.Clientes;

namespace LojaServicos.servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Cadastrar(ClienteCadastroDto dto)
        {
            var cliente = ConstruirCliente(dto);

            var clienteExistenteComCpf = _clienteRepositorio.ObterPorCpf(dto.Cpf);
            if (clienteExistenteComCpf != null)
                throw new Exception($"Cliente já cadastrado com CPF {dto.Cpf}");

            _clienteRepositorio.Cadastrar(cliente);
        }

        public void Apagar(int id)
        {
            _clienteRepositorio.Apagar(id);
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
            return _clienteRepositorio.ObterPorId(id);
        }

        public void Editar(Cliente cliente)
        {
            _clienteRepositorio.Editar(cliente);
        }

        private Cliente ConstruirCliente(ClienteCadastroDto dto)
        {
            return new Cliente
            {
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento,
                Cpf = dto.Cpf,
                Endereco = new Endereco
                {
                    Estado = dto.Estado,
                    Cep = dto.Cep,
                    Cidade = dto.Cidade,
                    Logradouro = dto.Logradouro,
                    Bairro = dto.Bairro,
                    Numero = dto.Numero,
                    Complemento = dto.Complemento
                }
            };
        }
    }
}
