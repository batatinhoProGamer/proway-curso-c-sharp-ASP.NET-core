using LojaRepositorios.entidades;

namespace LojaRepositorios.repositorios
{
    public interface IClienteRepositorio : IRepositorioBase<Cliente>
    {
        List<Cliente> ObterTodos(string? pesquisa);
        Cliente? ObterPorCpf(string Cpf);
    }
}
