using LojaRepositorios.database;
using LojaRepositorios.entidades;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaMvc.Controllers
{
    [Route("/produto")]
    public class ProdutoController : Controller
    {
        public ProdutoController(LojaContexto contexto) 
        {
            var produtos = contexto.Set<Produto>().ToList();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var produtoServico = new ProdutoServico();
            var produtos = produtoServico.ObterTodos();
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
            var produtoServico = new ProdutoServico();
            var produto = new Produto();
            produto.Nome = nome;
            produto.PrecoUnitario = precoUnitario;
            produto.Quantidade = 1;

            produtoServico.Cadastrar(produto);

            return RedirectToAction("Index");
        }

        [Route("apagar")]
        [HttpGet]
        public IActionResult Apagar([FromQuery] int id)
        {
            var produtoServico = new ProdutoServico();
            produtoServico.Apagar(id);

            return RedirectToAction("Index");
        }

        [Route("editar")]
        [HttpGet]
        public IActionResult Editar([FromQuery] int id)
        {
            var produtoServico = new ProdutoServico();
            var produto = produtoServico.ObterPorId(id);

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

            var produtoServico = new ProdutoServico();
            produtoServico.Editar(produto);

            return RedirectToAction("Index");
        }
    }
}
