using LojaRepositorios.repositorios;
using LojaRepositorios.entidades;

namespace LojaServicos.servicos
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        public void Cadastrar(Cliente cliente)
        {
            _clienteRepositorio.Cadastrar(cliente);
        }

        public void Apagar(int id)
        {
            _clienteRepositorio.Apagar(id);
        }

        public List<Cliente> ObterTodos(string? pesquisa)
        {
            var clientes = _clienteRepositorio.ObterTodos(pesquisa);
            return clientes;
        }

        public Cliente? ObterPorId(int id)
        {
            return _clienteRepositorio.ObterPorId(id);
        }

        public void Editar(Cliente cliente)
        {
            _clienteRepositorio.Editar(cliente);
        }
    }
}
