using LojaRepositorios.entidades;
using LojaServicos.Dtos.Clientes;

namespace LojaServicos.servicos
{
    public interface IClienteServico
    {
        void Apagar(int id);
        void Cadastrar(ClienteCadastroDto cliente);
        void Editar(Cliente cliente);
        Cliente? ObterPorId(int id);
        List<ClienteIndexDto> ObterTodos(string? pesquisa);
    }
}