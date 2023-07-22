using LojaRepositorios.entidades;
using LojaRepositorios.repositorios;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace LojaMvc.Controllers
{
    [Route("/cliente")]
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var clienteServico = new ClienteServico();
            var clientes = clienteServico.ObterTodos();
            ViewBag.Clientes = clientes;

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
            [FromForm] DateTime dataNascimento,
            [FromForm] string cpf,
            [FromForm] string cep,
            [FromForm] string numero,
            [FromForm] string estado,
            [FromForm] string cidade,
            [FromForm] string bairro,
            [FromForm] string logradouro,
            [FromForm] string complemento)
        {
            var cliente = new Cliente();
            cliente.Nome = nome;
            cliente.DataNascimento = dataNascimento;
            cliente.Cpf = cpf;
            cliente.Endereco.Estado = estado;
            cliente.Endereco.Cep = cep;
            cliente.Endereco.Cidade = cidade;
            cliente.Endereco.Logradouro = logradouro;
            cliente.Endereco.Bairro = bairro;
            cliente.Endereco.Complemento = complemento;
            cliente.Endereco.Numero = numero;

            var clienteServico = new ClienteServico();
            clienteServico.Cadastrar(cliente);

            return RedirectToAction("index");
        }

        [Route("apagar")]
        [HttpGet]
        public IActionResult Apagar([FromQuery] int id)
        {
            var clienteServico = new ClienteServico();
            clienteServico.Apagar(id);
            
            return RedirectToAction("index");
        }

        [Route("editar")]
        [HttpGet]
        public IActionResult Editar([FromQuery] int id) 
        {
            var clienteServico = new ClienteServico();
            var cliente = clienteServico.ObterPorId(id);
            ViewBag.Cliente = cliente;

            return View();
        }

        [Route("editar")]
        [HttpPost]
        public IActionResult Editar(
            [FromQuery] int id,
            [FromForm] string nome,
            [FromForm] DateTime dataNascimento,
            [FromForm] string cpf,
            [FromForm] string cep,
            [FromForm] string numeroEndereco)
        {
            var cliente = new Cliente();
            cliente.Id = id;
            cliente.Nome = nome;
            cliente.DataNascimento = dataNascimento;
            cliente.Cpf = cpf;
            cliente.Endereco = BuscarEnderecoPorCep(cep);
            cliente.Endereco.Numero = numeroEndereco;

            var clienteServico = new ClienteServico();
            clienteServico.Editar(cliente);

            return RedirectToAction("index");
        }

        private Endereco BuscarEnderecoPorCep(string cep)
        {
            try
            {
                var url = $"https://viacep.com.br/ws/{cep.Replace("-", string.Empty)}/json/";

                var httpCliente = new HttpClient();
                var response = httpCliente.GetAsync(url).GetAwaiter().GetResult();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseTexto = response.Content.ReadAsStringAsync().Result;
                    var endereco = JsonConvert.DeserializeObject
                        <Dictionary<string, string>>(responseTexto);

                    var enderecoObjeto = new Endereco();
                    enderecoObjeto.Estado = endereco["uf"];
                    enderecoObjeto.Cidade = endereco["localidade"];
                    enderecoObjeto.Bairro = endereco["bairro"];
                    enderecoObjeto.Cep = cep;
                    enderecoObjeto.Logradouro = endereco["logradouro"];
                    enderecoObjeto.Numero = "0";
                    enderecoObjeto.Complemento = endereco["complemento"];
                    return enderecoObjeto;
                }
            }
            catch (Exception ex)
            {
                
            }
            return null;
        }
    }
}
