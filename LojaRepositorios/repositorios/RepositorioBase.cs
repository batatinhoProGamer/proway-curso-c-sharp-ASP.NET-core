using LojaRepositorios.database;
using LojaRepositorios.entidades;
using Microsoft.EntityFrameworkCore;

namespace LojaRepositorios.repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> 
        where TEntity : EntidadeBase
    { 
        protected readonly LojaContexto _lojaContexto;
        protected readonly DbSet<TEntity> _dbSet;
        public RepositorioBase(LojaContexto lojaContexto)
        {
            _lojaContexto = lojaContexto;
            _dbSet = lojaContexto.Set<TEntity>();
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _lojaContexto.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _lojaContexto.SaveChanges();
            return entity;
        }

        public TEntity DeleteLogic(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new Exception("");
            
            entity.Ativo = false;
            _dbSet.Update(entity);
            _lojaContexto.SaveChanges();
            return entity;
        }

        public TEntity DeletePhisically(int id)
        {
            var entity = GetById(id);
            if (entity == null)
                throw new Exception("");

            _dbSet.Remove(entity);
            _lojaContexto.SaveChanges();
            return entity;
        }

        public bool Any(int id)
        {
            throw new NotImplementedException();
        }
    }
}
