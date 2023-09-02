using LojaServicos.Dtos.Produtos;

namespace LojaServicos.servicos
{
    public interface IProdutoServico
    {
        void Apagar(int id);
        int Cadastrar(ProdutoCadastrarDto produto);
        void Editar(ProdutoEditarDto produto);
        ProdutoIndexDto? ObterPorId(int id);
        List<ProdutoIndexDto> ObterTodos(string filtro);
    }
}