using AutoMapper;
using LojaApi.Models.Autenticacao;
using LojaServicos.Dtos.Autenticacao;
using LojaServicos.servicos;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers;

[Route("api/autenticacao")]
public class AutenticacaoController : Controller
{
    private readonly IAutenticacaoServico _autenticacaoServico;
    private readonly IMapper _mapper;

    public AutenticacaoController(IAutenticacaoServico autenticacaoServico, IMapper mapper)
    {
        _autenticacaoServico = autenticacaoServico;
        _mapper = mapper;
    }

    [HttpPost("login")]
    public IActionResult login([FromBody] AutenticacaoModel autenticacaoModel)
    {
        try
        {
            var autenticacaoDto = _mapper.Map<AutenticarDto>(autenticacaoModel);
            _autenticacaoServico.Autenticar(autenticacaoDto, HttpContext.Session);
            return NoContent();
        }
        catch
        {
            return Unauthorized();
        }
    }
}