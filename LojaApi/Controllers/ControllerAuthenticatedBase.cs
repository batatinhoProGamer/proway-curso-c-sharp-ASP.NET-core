using AutoMapper;
using LojaApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LojaApi.Controllers;

[ServiceFilter(typeof(UsuarioAutenticadoFilter))]
public class ControllerAuthenticatedBase : Controller
{
    protected readonly IMapper _mapper;

    public ControllerAuthenticatedBase(IMapper mapper)
    {
        _mapper = mapper;
    }
}