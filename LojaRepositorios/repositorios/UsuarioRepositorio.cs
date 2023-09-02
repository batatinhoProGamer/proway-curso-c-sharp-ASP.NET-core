using LojaRepositorios.database;
using LojaRepositorios.entidades;

namespace LojaRepositorios.repositorios;

public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
{
    public UsuarioRepositorio(LojaContexto lojaContexto) : base(lojaContexto)
    {
    }

    public Usuario? GetByEmailAndPassword(string email, string senha)
    {
        return _dbSet.FirstOrDefault(x => x.Email == email && x.Senha == senha);
    }
}