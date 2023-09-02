using LojaRepositorios.database;
using LojaRepositorios.entidades;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LojaRepositorios.repositorios
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(LojaContexto lojaContexto) : base(lojaContexto)
        {
        }

        public List<Produto> ObterTodos(string pesquisa)
        {
            return _dbSet
                .Where(x => x.Nome.Contains(pesquisa))
                .OrderBy(x => x.Nome)
                .ToList();
        }
    }
}
