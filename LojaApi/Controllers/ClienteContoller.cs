using AutoMapper;
using LojaApi.Models.Cliente;
using LojaServicos.Dtos.Clientes;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers
{
    [Route("/clientes")]
    public class ClienteContoller : Controller
    {
        private readonly IClienteServico _clienteServico;
        private readonly IMapper _mapper;

        public ClienteContoller(IClienteServico clienteServico, IMapper mapper)
        {
            _clienteServico = clienteServico;
            _mapper = mapper;
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
            var clienteCadastroDto = _mapper.Map<ClienteCadastroDto>(clienteCreateModel);
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
}
