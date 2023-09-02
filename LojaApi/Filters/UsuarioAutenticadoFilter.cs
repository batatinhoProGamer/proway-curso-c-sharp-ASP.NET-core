using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LojaApi.Filters;

public class UsuarioAutenticadoFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var usuarioDaSessao = context.HttpContext.Session.GetString("usuarioSessao");
        if (usuarioDaSessao == null)
        {
            context.Result = new UnauthorizedResult();
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}