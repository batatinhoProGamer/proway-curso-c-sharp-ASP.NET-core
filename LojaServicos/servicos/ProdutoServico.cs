using LojaRepositorios.entidades;
using LojaRepositorios.repositorios;
using LojaServicos.Dtos.Produtos;
using LojaServicos.Exceptions;

namespace LojaServicos.servicos
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public int Cadastrar(ProdutoCadastrarDto dto)
        {
            var produto = ConstruirProduto(dto);
            produto = _produtoRepositorio.Add(produto);
            return produto.Id;
        }

        public List<ProdutoIndexDto> ObterTodos(string filtro)
        {
            // Obter a lista de produtos da tabela de produtos
            var produtos = _produtoRepositorio.ObterTodos(filtro);

            var produtoDtos = ConstruirProdutoIndexDto(produtos);
            // Retornar a lista de produtos
            return produtoDtos;
        }

        public void Apagar(int id)
        {
            _produtoRepositorio.DeleteLogic(id);
        }

        public ProdutoIndexDto? ObterPorId(int id)
        {
            var produto = _produtoRepositorio.GetById(id);

            if (produto == null)
            {
                return null;
            }
            return ConstruirProdutoUnicoIndexDto(produto);
        }

        public void Editar(ProdutoEditarDto dto)
        {
            var produto = _produtoRepositorio.GetById(dto.Id);
            
            if (produto == null)
                throw new EntidadeNaoEncontrada();

            produto = AtualizarProduto(dto, produto);
            _produtoRepositorio.Update(produto);
        }

        private List<ProdutoIndexDto> ConstruirProdutoIndexDto(List<Produto> produtos)
        {
            return produtos.Select(x => ConstruirProdutoUnicoIndexDto(x)
                ).ToList();
        }

        private ProdutoIndexDto ConstruirProdutoUnicoIndexDto(Produto x)
        {
            return new ProdutoIndexDto
            {
                Id = x.Id,
                Nome = x.Nome,
                PrecoUnitario = x.PrecoUnitario
            };
        }

        private Produto ConstruirProduto(ProdutoCadastrarDto dto)
        {
            return new Produto
            {
                Nome = dto.Nome,
                PrecoUnitario = dto.PrecoUnitario
            };

        }

        private Produto AtualizarProduto(ProdutoEditarDto dto, Produto produto)
        {
            produto.Nome = dto.Nome;
            produto.PrecoUnitario = dto.PrecoUnitario;

            return produto;
        }
    }
}
