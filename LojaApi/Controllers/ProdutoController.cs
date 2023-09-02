using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using LojaApi.Models.Produto;
using LojaServicos.Dtos.Produtos;
using LojaServicos.Exceptions;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("api/produtos")]
    public class ProdutoController : ControllerAuthenticatedBase
    {
        private readonly IProdutoServico _produtoServico;
        private readonly IValidator<ProdutoCreateModel> _produtoValidator;

        public ProdutoController(
            IProdutoServico produtoServico,
            IValidator<ProdutoCreateModel> produtoValidator,
            IMapper mapper
            ) : base(mapper)
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

            var dto = _mapper.Map<ProdutoCadastrarDto>(produtoCreateModel);

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
            var dto = _mapper.Map<ProdutoEditarDto>(produtoUpdateModel);
            dto.Id = id;

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
}
