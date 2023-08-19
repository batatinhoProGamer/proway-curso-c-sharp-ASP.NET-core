using LojaRepositorios.entidades;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(IProdutoServico produtoServico)
        {
            _produtoServico = produtoServico;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _produtoServico.ObterTodos(string.Empty);
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _produtoServico.ObterPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ProdutoCreateModel produtoCreateModel)
        {
            var produto = new Produto
            {
                Nome = produtoCreateModel.Nome.Trim(),
                PrecoUnitario = produtoCreateModel.PrecoUnitario,
                Quantidade = produtoCreateModel.Quantidade
            };
            _produtoServico.Cadastrar(produto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _produtoServico.Apagar(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]ProdutoUpdateModel produtoUpdateModel)
        {
            var produto = new Produto
            {
                Id = id,
                Nome = produtoUpdateModel.Nome.Trim(),
                PrecoUnitario = produtoUpdateModel.PrecoUnitario,
                Quantidade = produtoUpdateModel.Quantidade
            };
            _produtoServico.Editar(produto);
            return Ok();
        }
    }

    public class ProdutoUpdateModel
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }

    public class ProdutoCreateModel
    {
        public string Nome { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }
    }

}
