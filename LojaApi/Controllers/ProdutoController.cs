using FluentValidation;
using FluentValidation.Results;
using LojaApi.Validators;
using LojaRepositorios.entidades;
using LojaServicos.Dtos.Produtos;
using LojaServicos.Exceptions;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("produtos")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoServico _produtoServico;
        private readonly IValidator<ProdutoCreateModel> _produtoValidator;

        public ProdutoController(
            IProdutoServico produtoServico,
            IValidator<ProdutoCreateModel> produtoValidator
            )
        {
            _produtoServico = produtoServico;
            _produtoValidator = produtoValidator;
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
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody]ProdutoCreateModel produtoCreateModel)
        {
            var validacao = _produtoValidator.Validate(produtoCreateModel);

            if (!validacao.IsValid)
            {
                var errosDetalhes = ObterDadosValidacao(validacao.Errors);
                return UnprocessableEntity(errosDetalhes);
            }

            var dto = new ProdutoCadastrarDto
            {
                Nome = produtoCreateModel.Nome.Trim(),
                PrecoUnitario = produtoCreateModel.PrecoUnitario,
                Quantidade = produtoCreateModel.Quantidade
            };
            _produtoServico.Cadastrar(dto);
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
            var dto = new ProdutoEditarDto
            {
                Id = id,
                Nome = produtoUpdateModel.Nome.Trim(),
                PrecoUnitario = produtoUpdateModel.PrecoUnitario,
                Quantidade = produtoUpdateModel.Quantidade
            };

            try
            {
                _produtoServico.Editar(dto);
            }
            catch (EntidadeNaoEncontrada)
            {
                return NotFound();
            }

            return Ok();
        }

        private List<object> ObterDadosValidacao(List<ValidationFailure> errors)
        {
            var dados = new List<object>();

            foreach(var error in errors)
            {
                var errorDetail = new
                {
                    Field = error.PropertyName,
                    Message = error.ErrorMessage
                };
                dados.Add(errorDetail);
            }

            return dados;
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
