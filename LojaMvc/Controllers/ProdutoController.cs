using AutoMapper;
using LojaMvc.Models.Produto;
using LojaRepositorios.entidades;
using LojaServicos.Dtos.Produtos;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaMvc.Controllers
{
    [Route("/produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _produtoServico;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoServico produtoServico, IMapper mapper) 
        {
            _produtoServico = produtoServico;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var produtosIndexDtos = _produtoServico.ObterTodos("");

            return View(produtosIndexDtos);
        }

        [Route("cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            var model = new ProdutoCadastroViewModel();

            return View(model);
        }

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar(
            [FromForm] ProdutoCadastroViewModel model)
        {
            var produtoCadastrarDto = _mapper.Map<ProdutoCadastrarDto>(model);

            _produtoServico.Cadastrar(produtoCadastrarDto);

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
            var produtoIndexDto = _produtoServico.ObterPorId(id);

            var produtoEditarViewModel = _mapper.Map<ProdutoEditarViewModel>(produtoIndexDto);

            return View(produtoEditarViewModel);
        }

        [Route("editar")]
        [HttpPost]
        public IActionResult Editar(
            [FromForm] ProdutoEditarViewModel model)
        {
            var produtoEditarDto = _mapper.Map<ProdutoEditarDto>(model);

            _produtoServico.Editar(produtoEditarDto);

            return RedirectToAction("Index");
        }
    }
}
