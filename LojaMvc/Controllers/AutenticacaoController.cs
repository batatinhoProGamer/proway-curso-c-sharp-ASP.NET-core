using AutoMapper;
using LojaMvc.Models.Autenticacao;
using LojaServicos.Dtos.Autenticacao;
using LojaServicos.Exceptions;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaMvc.Controllers;

[Route("login")]
public class AutenticacaoController : Controller
{
    private readonly IAutenticacaoServico _autenticacaoServico;
    private readonly IMapper _mapper;

    public AutenticacaoController(IAutenticacaoServico autenticacaoServico, IMapper mapper)
    {
        _autenticacaoServico = autenticacaoServico;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Login()
    {
        var viewModel = new AutenticacaoViewModel();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Login([FromForm] AutenticacaoViewModel viewModel)
    {
        try
        {
            var autenticarDto = _mapper.Map<AutenticarDto>(viewModel);
            _autenticacaoServico.Autenticar(autenticarDto, HttpContext.Session);
            return RedirectToAction("Index", "Home");
        }
        catch
        {
            return View(viewModel);
        }
    }

    [HttpGet("logout")]
    public IActionResult Logout()
    {
        _autenticacaoServico.Sair(HttpContext.Session);
        return RedirectToAction("Login");
    }
}