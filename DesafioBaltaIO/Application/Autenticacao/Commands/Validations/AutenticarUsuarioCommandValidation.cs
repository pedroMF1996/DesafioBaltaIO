using FluentValidation;

namespace DesafioBaltaIO.Application.Autenticacao.Commands.Validations
{
    public class AutenticarUsuarioCommandValidation : AbstractValidator<AutenticarUsuarioCommand>
    {
        public AutenticarUsuarioCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                    .WithMessage("O campo Email é obrigatório")
                .EmailAddress()
                    .WithMessage("O campo Email está em formato inválido");

            RuleFor(x => x.Senha)
                .NotEmpty()
                .NotNull()
                    .WithMessage("O campo Senha é obrigatório")
                .MaximumLength(100)
                .MinimumLength(6)
                    .WithMessage("O campo Senha precisa ter entre 6 e 100 caracteres");
        }
    }
}
