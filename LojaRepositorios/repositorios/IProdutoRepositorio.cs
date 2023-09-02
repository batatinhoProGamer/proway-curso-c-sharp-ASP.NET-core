using LojaRepositorios.entidades;

namespace LojaRepositorios.repositorios
{
    public interface IProdutoRepositorio : IRepositorioBase<Produto>
    {
        List<Produto> ObterTodos(string pesquisa);
    }
}
