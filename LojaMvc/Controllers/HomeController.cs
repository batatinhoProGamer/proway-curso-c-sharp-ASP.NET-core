using LojaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ExemploCampos()
        {
            return View();
        }

        public IActionResult CadastroPersonagem()
        {
            return View();
        }

        public IActionResult CadastrarPersonagem(
            [FromQuery] string nome,
            [FromQuery] int idade)
        {
            var anoAtual = DateTime.Now.Year;
            var anoNascimento = anoAtual - idade;
            var status = "";

            if (idade < 18)
            {
                status = "Menor de 18 anos";
            }
            else
            {
                status = "Maior ou igual de 18 anos";
            }
            var mensagem = $"{nome} nasceu em {anoNascimento}. Status: {status}";

            return Ok(mensagem);
        }

        public IActionResult Exercicio1()
        {
            return View();
        }

        public IActionResult Exercicio1Resultado(
            [FromQuery] string nome,
            [FromQuery] string sobrenome) 
        {
            var mensagem = "Nome completo: " + nome + " " + sobrenome;

            return Ok(mensagem);
        }

        [Route("/home/imc")]
        public IActionResult Exercicio2()
        {
            return View();
        }

        [HttpPost]  
        public IActionResult exercicio2Resultado(
            [FromForm] string nome,
            [FromForm] string altura,
            [FromForm] string peso)
        {
            decimal alturaEmMetros = Convert.ToDecimal(altura);
            var imc = Convert.ToDecimal(peso) / (alturaEmMetros * alturaEmMetros);
            Console.WriteLine(alturaEmMetros);

            var mensagem = $"{nome} possui {imc.ToString("##.##")} IMC";
            return Ok(mensagem);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}