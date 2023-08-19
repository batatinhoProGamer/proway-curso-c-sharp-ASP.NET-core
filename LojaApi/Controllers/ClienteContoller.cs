using LojaServicos.Dtos.Clientes;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("/clientes")]
    public class ClienteContoller : Controller
    {
        private readonly IClienteServico _clienteServico;

        public ClienteContoller(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var clientes = _clienteServico.ObterTodos(string.Empty);
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteServico.ObterPorId(id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Create([FromBody]ClienteCreateModel clienteCreateModel)
        {
            var clienteCadastroDto = new ClienteCadastroDto
            {
                Nome = clienteCreateModel.Nome,
                DataNascimento = clienteCreateModel.DataNascimento,
                Cpf = clienteCreateModel.Cpf,
                Estado = clienteCreateModel.Estado,
                Cep = clienteCreateModel.Cep,
                Cidade = clienteCreateModel.Cidade,
                Logradouro = clienteCreateModel.Logradouro,
                Bairro = clienteCreateModel.Bairro,
                Complemento = clienteCreateModel.Complemento,
                Numero = clienteCreateModel.Numero
            };
            _clienteServico.Cadastrar(clienteCadastroDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clienteServico.Apagar(id);
            return Ok();
        }
    }

    public class ClienteCreateModel
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string? Complemento { get; set; }
        public string Numero { get; set; }
    }
}
