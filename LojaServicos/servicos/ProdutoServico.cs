using LojaRepositorios.entidades;
using LojaRepositorios.repositorios;

namespace LojaServicos.servicos
{
    public class ProdutoServico
    {
        private readonly ProdutoRepositorio _produtoRepositorio;

        public ProdutoServico()
        {
            _produtoRepositorio = new ProdutoRepositorio();
        }

        public void Cadastrar(Produto produto)
        {
            _produtoRepositorio.Cadastrar(produto);
        }

        public List<Produto> ObterTodos()
        {
            // Obter a lista de produtos da tabela de produtos
            var produtos = _produtoRepositorio.ObterTodos();
            // Retornar a lista de produtos
            return produtos;
        }

        public void Apagar(int id)
        {
            // Instanciando um objeto da class ProdutoRepositorio
            // Chamar o método Apagar do ProdutoRepositorio(que irá executar o DELETE)
            _produtoRepositorio.Apagar(id);
        }

        public Produto ObterPorId(int id)
        {
            var produto = _produtoRepositorio.ObterPorId(id);
            return produto;
        }

        public void Editar(Produto produto)
        {
            _produtoRepositorio.Editar(produto);
        }
    }
}
