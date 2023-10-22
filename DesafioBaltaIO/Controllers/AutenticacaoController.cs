using DesafioBaltaIO.Application.Ibge.Commands;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Mediator;

namespace DesafioBaltaIO.Controllers
{
    public static class AutenticacaoController
    {
        public static WebApplication AddAutenticacaoController(this WebApplication app)
        {
            app.MapPost("/registrar", async ([FromServices] IMediatorHandler _mediatorHandler,
                [FromBody] CadastrarLocalidadeCommand command) =>
                {
                    //return CustomResponse(await _mediatorHandler.SendCommand(command));
                })
                .Produces<IResult>(StatusCodes.Status200OK)
                .Produces<ValidationProblemDetails>(StatusCodes.Status500InternalServerError)
                .WithName("PostRegistrar")
                .WithTags("Autenticacao", "Command");

            app.MapPost("/autenticar", async ([FromServices] IMediatorHandler _mediatorHandler,
                [FromBody] CadastrarLocalidadeCommand command) =>
                {
                    //return CustomResponse(await _mediatorHandler.SendCommand(command));
                })
                .Produces<IResult>(StatusCodes.Status200OK)
                .Produces<ValidationProblemDetails>(StatusCodes.Status500InternalServerError)
                .WithName("PostAutenticar")
                .WithTags("Autenticacao", "Command");

            return app;
        }
    }
}
