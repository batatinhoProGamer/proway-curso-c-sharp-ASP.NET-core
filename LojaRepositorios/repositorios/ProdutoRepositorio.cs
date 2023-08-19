using LojaRepositorios.database;
using LojaRepositorios.entidades;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LojaRepositorios.repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly LojaContexto _lojaContexto;
        private readonly DbSet<Produto> _dbSet;

        public ProdutoRepositorio(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
            _dbSet = _lojaContexto.Set<Produto>();
        }
        // CRUD
        public int Cadastrar(Produto produto)
        {
            _dbSet.Add(produto);
            _lojaContexto.SaveChanges();
            return produto.Id;
        }

        public void Editar(Produto produto)
        {
            _dbSet.Update(produto);
            _lojaContexto.SaveChanges();
        }

        public void Apagar(int id)
        {
            var produto = _dbSet.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                throw new Exception($"Poduto com código {id} não existe");
            }
            _dbSet.Remove(produto);
            _lojaContexto.SaveChanges();
        }

        public List<Produto> ObterTodos(string pesquisa)
        {
            return _dbSet
                .Where(x => x.Nome.Contains(pesquisa))
                .OrderBy(x => x.Nome)
                .ToList();
        }

        public Produto? ObterPorId(int id)
        {
            var produto = _dbSet.FirstOrDefault(x => x.Id == id);
            return produto;
        }
    }
}
