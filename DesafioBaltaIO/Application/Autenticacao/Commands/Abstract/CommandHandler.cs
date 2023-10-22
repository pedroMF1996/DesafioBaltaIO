using DesafioBaltaIO.Application.Autenticacao.DTOs;
using FluentValidation.Results;
using NetDevPack.Data;

namespace DesafioBaltaIO.Application.Autenticacao.Commands.Abstract
{
    public abstract class CommandHandler
    {
        protected readonly AutenticarUsuarioResponseDTO _response;
        protected ValidationResult ValidationResult => _response.ValidationResult;
        protected LoginResponseDTO AutenticacaoResponse => _response.AutenticacaoResponse;

        protected CommandHandler()
        {
            _response = new();
        }

        protected void SetLoginResponse(LoginResponseDTO loginResponse)
        {
            _response.AutenticacaoResponse = loginResponse;
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected bool HasErrors()
        {
            return !ValidationResult.IsValid;
        }

        protected void UpdateValidationResult(ValidationResult validationResult)
        {
            _response.ValidationResult = validationResult;
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
        {
            if (!(await uow.Commit()))
            {
                AddError(message);
            }

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow)
        {
            return await Commit(uow, "Um erro ocorreu ao persistir os dados").ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
