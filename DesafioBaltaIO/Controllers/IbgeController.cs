using DesafioBaltaIO.Application.Ibge.Commands;
using DesafioBaltaIO.Application.Ibge.DTOs;
using DesafioBaltaIO.Application.Ibge.Query.Interface;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using NetDevPack.Mediator;

namespace DesafioBaltaIO.Controllers
{
    public static class IbgeController
    {
        public static WebApplication AddIbgeController(this WebApplication app)
        {
            #region Commands

            app.MapPost("/localidade", async (IMediatorHandler _mediatorHandler,
                CadastrarLocalidadeCommand command) =>
                    CustomResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<ValidationResult>(StatusCodes.Status200OK)
                .Produces<ValidationResult>(StatusCodes.Status500InternalServerError)
                .WithName("PostLocalidade")
                .WithTags("IBGE");

            app.MapPut("/localidade/alterar/cidade", async (IMediatorHandler _mediatorHandler,
                AlterarCidadeLocalidadeCommand command) =>
                    CustomResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<ValidationResult>(StatusCodes.Status200OK)
                .Produces<ValidationResult>(StatusCodes.Status500InternalServerError)
                .WithName("PutAlterarCidade")
                .WithTags("IBGE");

            app.MapPut("/localidade/alterar/estado", async (IMediatorHandler _mediatorHandler,
                AlterarEstadoLocalidadeCommand command) =>
                    CustomResponse(await _mediatorHandler.SendCommand(command)))
                .Produces<ValidationResult>(StatusCodes.Status200OK)
                .Produces<ValidationResult>(StatusCodes.Status500InternalServerError)
                .WithName("PutAlterarEstado")
                .WithTags("IBGE");

            app.MapPut("/localidade/alterar/codigo", async (IMediatorHandler _mediatorHandler,
                AlterarCodigoLocalidadeCommand command) =>
                    CustomResponse(await _mediatorHandler.SendCommand(command)))
                .Produces(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithName("PutAlterarCodigo")
                .WithTags("IBGE");

            #endregion

            #region Queries

            app.MapGet("/localidade/{codigo}", (string codigo,
                ILocalidadeQueries localidadeQueries) =>
            {
                var localidade = localidadeQueries.ObterLocalizacaoPorCodigo(codigo);
                return localidade != null ?
                            Results.Ok(localidade) :
                            Results.NotFound();
            })
                .Produces<LocalidadeDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetLocalidadePorCodigo")
                .WithTags("IBGE");

            app.MapGet("/localidade/{cidade}", async (string cidade,
                ILocalidadeQueries localidadeQueries) =>
            {
                var localidade = await localidadeQueries.ObterLocalizacaoPorCidade(cidade);
                return localidade != null ?
                            Results.Ok(localidade) :
                            Results.NotFound();
            })
                .Produces<LocalidadeDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetLocalidadePorCidade")
                .WithTags("IBGE");

            app.MapGet("/localidade/{estado}", async (string estado,
                ILocalidadeQueries localidadeQueries) =>
            {
                var localidades = await localidadeQueries.ObterLocalizacoesPorEstado(estado);
                return localidades != null ?
                            Results.Ok(localidades) :
                            Results.NotFound();
            })
                .Produces<IEnumerable<LocalidadeDTO>>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound)
                .WithName("GetLocalidadesPorEstado")
                .WithTags("IBGE");

            #endregion


            return app;
        }


        #region Private_Methods

        private static readonly ICollection<string> Errors = new List<string>();

        private static IResult CustomResponse(object? result = null)
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
