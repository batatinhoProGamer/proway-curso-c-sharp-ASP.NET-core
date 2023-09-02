using LojaRepositorios.entidades;

namespace LojaRepositorios.repositorios;

public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
{
    Usuario? GetByEmailAndPassword(string email, string senha);
}