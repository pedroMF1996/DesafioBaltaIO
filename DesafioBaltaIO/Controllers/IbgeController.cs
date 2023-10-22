using DesafioBaltaIO.Application.Ibge.Commands;
using DesafioBaltaIO.Application.Ibge.DTOs;
using DesafioBaltaIO.Application.Ibge.Query.Interface;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Mediator;

namespace DesafioBaltaIO.Controllers
{
    public static class IbgeController
    {
        public static WebApplication AddIbgeController(this WebApplication app)
        {
            #region Commands

            app.MapPost("ibge/localidade", [Authorize] async ([FromServices] IMediatorHandler _mediatorHandler,
                [FromBody] CadastrarLocalidadeCommand command) =>
                    CustomResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<IResult>(StatusCodes.Status200OK)
                .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
                .WithName("PostLocalidade")
                .WithTags("IBGE", "Command");

            app.MapPut("ibge/localidade/alterar/cidade", [Authorize] async ([FromServices] IMediatorHandler _mediatorHandler,
                [FromBody] AlterarCidadeLocalidadeCommand command) =>
                    CustomResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<IResult>(StatusCodes.Status200OK)
                .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
                .RequireAuthorization("IBGE_Atualizar")
                .WithName("PutAlterarCidade")
                .WithTags("IBGE", "Command");

            app.MapPut("ibge/localidade/alterar/estado", [Authorize] async ([FromServices] IMediatorHandler _mediatorHandler,
                [FromBody] AlterarEstadoLocalidadeCommand command) =>
                    CustomResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<IResult>(StatusCodes.Status200OK)
                .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
                .RequireAuthorization("IBGE_Atualizar")
                .WithName("PutAlterarEstado")
                .WithTags("IBGE", "Command");

            app.MapPut("ibge/localidade/alterar/codigo", [Authorize] async ([FromServices] IMediatorHandler _mediatorHandler,
                [FromBody] AlterarCodigoLocalidadeCommand command) =>
                    CustomResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<IResult>(StatusCodes.Status200OK)
                .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
                .RequireAuthorization("IBGE_Atualizar")
                .WithName("PutAlterarCodigo")
                .WithTags("IBGE", "Command");

            app.MapDelete("ibge/localidade", [Authorize] async ([FromServices] IMediatorHandler _mediatorHandler,
                [FromBody] RemoverLocalidadeCommand command) =>
                    CustomResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<IResult>(StatusCodes.Status200OK)
                .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
                .RequireAuthorization("IBGE_Remover")
                .WithName("DeleteLocalidade")
                .WithTags("IBGE", "Command");

            #endregion

            #region Queries

            app.MapGet("ibge/localidade/obter-por-codigo/{codigo}", [AllowAnonymous] async ([FromQuery] string codigo,
                [FromServices] ILocalidadeQueries localidadeQueries) =>
                    CustomQueryResponse(await localidadeQueries.ObterLocalizacaoPorCodigo(codigo)))
                .Produces<LocalidadeDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetLocalidadePorCodigo")
                .WithTags("IBGE", "Query");

            app.MapGet("ibge/localidade/obter-por-cidade/{cidade}", [AllowAnonymous] async ([FromQuery] string cidade,
                [FromServices] ILocalidadeQueries localidadeQueries) =>
                    CustomQueryResponse(await localidadeQueries.ObterLocalizacaoPorCidade(cidade)))
                .Produces<LocalidadeDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetLocalidadePorCidade")
                .WithTags("IBGE", "Query");

            app.MapGet("ibge/localidade/obter-por-estado/{estado}", [AllowAnonymous] async ([FromQuery] string estado,
                [FromServices] ILocalidadeQueries localidadeQueries) =>
                    CustomQueryResponse(await localidadeQueries.ObterLocalizacoesPorEstado(estado)))
                .Produces<IEnumerable<LocalidadeDTO>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetLocalidadesPorEstado")
                .WithTags("IBGE", "Query");

            #endregion

            return app;
        }


        #region Metodos_Privados

        private static readonly ICollection<string> Errors = new List<string>();

        private static IResult CustomQueryResponse(object localidade)
        {
            return localidade != null ?
                        Results.Ok(localidade) :
                        Results.NotFound();
        }

        private static IResult CustomQueryResponse(List<object> localidades)
        {
            return localidades != null ?
                        Results.Ok(localidades) :
                        Results.NotFound();
        }

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

        private static IResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AdicionarErroProcessamento(error.ErrorMessage);
            }

            return CustomResponse();
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
