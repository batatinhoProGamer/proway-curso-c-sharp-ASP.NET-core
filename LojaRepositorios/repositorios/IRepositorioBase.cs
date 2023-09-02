namespace LojaRepositorios.repositorios
{
    public interface IRepositorioBase<TEntity>
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity DeleteLogic(int id);
        TEntity DeletePhisically(int id);
        bool Any(int id);
    }
}