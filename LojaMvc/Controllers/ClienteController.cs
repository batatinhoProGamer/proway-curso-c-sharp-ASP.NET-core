using LojaMvc.Models.Cliente;
using LojaRepositorios.entidades;
using LojaServicos.Dtos.Clientes;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace LojaMvc.Controllers
{
    [Route("/cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string? pesquisa)
        {
            var dtos = _clienteServico.ObterTodos(pesquisa);

            var viewModel = ConstruirClienteIndexViewModel(dtos, pesquisa);

            return View(viewModel);
        }

        private object ConstruirClienteIndexViewModel(List<ClienteIndexDto> dtos, string? pesquisa)
        {
            var viewModel = new ClienteIndexViewModel
            {
                Pesquisa = pesquisa,
                Clientes = ConstruirClienteViewModel(dtos)
            };

            return viewModel;
        }

        private List<ClienteViewModel> ConstruirClienteViewModel(List<ClienteIndexDto> dtos)
        {
            var viewModels = new List<ClienteViewModel>();
            foreach (var dto in dtos)
            {
                viewModels.Add(new ClienteViewModel
                {
                    Id = dto.Id,
                    Nome = dto.Nome,
                    Endereco = dto.Endereco,
                    Cpf = dto.Cpf
                });
            }

            return viewModels;
        }

        [Route("cadastrar")]
        [HttpGet]
        public IActionResult Cadastrar()
        {
            var viewModel = new ClienteCadastroViewModel();
            return View(viewModel);
        }

        [Route("cadastrar")]
        [HttpPost]
        public IActionResult Cadastrar([FromForm] ClienteCadastroViewModel clienteCadastro)
        {
            if (ModelState.IsValid == false)
            {
                return View("Cadastrar", clienteCadastro);
            }

            var cliente = ConstruirClienteCadastroDto(clienteCadastro);

            _clienteServico.Cadastrar(cliente);

            return RedirectToAction("index");
        }

        public ClienteCadastroDto ConstruirClienteCadastroDto(ClienteCadastroViewModel clienteCadastro)
        {
            return new ClienteCadastroDto
            {
                Nome = clienteCadastro.Nome,
                DataNascimento = clienteCadastro.DataNascimento.GetValueOrDefault(),
                Cpf = clienteCadastro.Cpf,
                Estado = clienteCadastro.Estado,
                Cep = clienteCadastro.Cep,
                Cidade = clienteCadastro.Cidade,
                Logradouro = clienteCadastro.Logradouro,
                Bairro = clienteCadastro.Bairro,
                Complemento = clienteCadastro.Complemento,
                Numero = clienteCadastro.Numero
            };
        }

        [Route("apagar")]
        [HttpGet]
        public IActionResult Apagar([FromQuery] int id)
        {
            _clienteServico.Apagar(id);
            
            return RedirectToAction("index");
        }

        [Route("editar")]
        [HttpGet]
        public IActionResult Editar([FromQuery] int id) 
        {
            var cliente = _clienteServico.ObterPorId(id);
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

            _clienteServico.Editar(cliente);

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
