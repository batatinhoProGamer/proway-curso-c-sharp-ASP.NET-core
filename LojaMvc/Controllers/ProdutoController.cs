using LojaRepositorios.entidades;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaMvc.Controllers
{
    [Route("/produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _produtoServico;
        public ProdutoController(IProdutoServico produtoServico) 
        {
            _produtoServico = produtoServico;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var produtos = _produtoServico.ObterTodos("");
            ViewBag.produtos = produtos;

            return View();
        }

        [Route("cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar(
            [FromForm] string nome,
            [FromForm] decimal precoUnitario)
        {
            var produto = new Produto();
            produto.Nome = nome;
            produto.PrecoUnitario = precoUnitario;
            produto.Quantidade = 1;

            _produtoServico.Cadastrar(produto);

            return RedirectToAction("Index");
        }

        [Route("apagar")]
        [HttpGet]
        public IActionResult Apagar([FromQuery] int id)
        {
            _produtoServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [Route("editar")]
        [HttpGet]
        public IActionResult Editar([FromQuery] int id)
        {
            var produto = _produtoServico.ObterPorId(id);

            ViewBag.Produto = produto;

            return View();
        }

        [Route("editar")]
        [HttpPost]
        public IActionResult Editar(
            [FromQuery] int id,
            [FromForm] string nome,
            [FromForm] decimal precoUnitario)
        {
            var produto = new Produto();
            produto.Id = id;
            produto.Nome = nome;
            produto.PrecoUnitario = precoUnitario;
            produto.Quantidade = 1;

            _produtoServico.Editar(produto);

            return RedirectToAction("Index");
        }
    }
}
