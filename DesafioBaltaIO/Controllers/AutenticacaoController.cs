using DesafioBaltaIO.Application.Autenticacao.Commands;
using DesafioBaltaIO.Application.Autenticacao.DTOs;
using DesafioBaltaIO.Application.Autenticacao.mediatorHandler;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBaltaIO.Controllers
{
    public static class AutenticacaoController
    {
        public static WebApplication AddAutenticacaoController(this WebApplication app)
        {
            #region Commands

            app.MapPost("/registrar", async ([FromServices] IMediatorHandlerAutenticacao _mediatorHandler,
                [FromBody] RegistrarUsuarioCommand command) =>
                    CustomAutenticacaoResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<IResult>(StatusCodes.Status200OK)
                .Produces<ValidationProblemDetails>(StatusCodes.Status500InternalServerError)
                .WithName("PostRegistrar")
                .WithTags("Autenticacao", "Command");

            app.MapPost("/autenticar", async ([FromServices] IMediatorHandlerAutenticacao _mediatorHandler,
                [FromBody] AutenticarUsuarioCommand command) =>
                    CustomAutenticacaoResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<IResult>(StatusCodes.Status200OK)
                .Produces<ValidationProblemDetails>(StatusCodes.Status500InternalServerError)
                .WithName("PostAutenticar")
                .WithTags("Autenticacao", "Command");

            #endregion

            return app;
        }

        #region Metodos_Privados

        private static readonly ICollection<string> Errors = new List<string>();

        private static IResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Results.Ok(result);
            }

            return Results.BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>()
            {
                {"Mensagens", Errors.ToArray() }
            }));
        }

        private static IResult CustomAutenticacaoResponse(AutenticarUsuarioResponseDTO response)
        {
            if (!response.ValidationResult.IsValid)
                foreach (var error in response.ValidationResult.Errors)
                {
                    AdicionarErroProcessamento(error.ErrorMessage);
                }

            return CustomResponse(response);
        }

        private static bool OperacaoValida()
        {
            return !Errors.Any();
        }

        private static void AdicionarErroProcessamento(string erro)
        {
            Errors.Add(erro);
        }

        #endregion
    }
}
