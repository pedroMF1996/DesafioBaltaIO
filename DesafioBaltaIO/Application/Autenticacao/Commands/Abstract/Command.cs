using DesafioBaltaIO.Application.Autenticacao.DTOs;
using FluentValidation.Results;
using MediatR;

namespace DesafioBaltaIO.Application.Autenticacao.Commands.Abstract
{
    public abstract class Command : IRequest<AutenticarUsuarioResponseDTO>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
