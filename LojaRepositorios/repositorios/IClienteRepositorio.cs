using LojaRepositorios.entidades;

namespace LojaRepositorios.repositorios
{
    public interface IClienteRepositorio
    {
        void Cadastrar(Cliente cliente);
        void Apagar(int id);
        List<Cliente> ObterTodos(string? pesquisa);
        Cliente? ObterPorId(int id);
        void Editar(Cliente cliente);
    }
}
