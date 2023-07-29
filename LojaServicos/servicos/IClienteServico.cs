using LojaRepositorios.entidades;

namespace LojaServicos.servicos
{
    public interface IClienteServico
    {
        void Apagar(int id);
        void Cadastrar(Cliente cliente);
        void Editar(Cliente cliente);
        Cliente? ObterPorId(int id);
        List<Cliente> ObterTodos(string? pesquisa);
    }
}