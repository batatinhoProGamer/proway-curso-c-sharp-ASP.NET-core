using LojaRepositorios.repositorios;
using LojaRepositorios.entidades;

namespace LojaServicos.servicos
{
    public class ClienteServico
    {
        private ClienteRepositorio repositorio { get; set; }

        public ClienteServico()
        {
            repositorio = new ClienteRepositorio();
        }

        public void Cadastrar(Cliente cliente)
        {
            repositorio.Cadastrar(cliente);
        }

        public void Apagar(int id)
        {
            repositorio.Apagar(id);
        }

        public List<Cliente> ObterTodos()
        {
            var clientes = repositorio.ObterTodos();
            return clientes;
        }

        public Cliente ObterPorId(int id)
        {
            return repositorio.ObterPorId(id);
        }

        public void Editar(Cliente cliente)
        {
            repositorio.Editar(cliente);
        }
    }
}
