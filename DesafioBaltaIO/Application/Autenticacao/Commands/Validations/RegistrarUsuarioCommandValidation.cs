using FluentValidation;

namespace DesafioBaltaIO.Application.Autenticacao.Commands.Validations
{
    public class RegistrarUsuarioCommandValidation : AbstractValidator<RegistrarUsuarioCommand>
    {
        public RegistrarUsuarioCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Nome é obrigatório");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .NotNull()
                .WithMessage("O campo Cpf é obrigatório");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
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

            RuleFor(x => x.ConfirmarSenha)
                .NotEmpty()
                .NotNull()
                    .WithMessage("O campo ConfirmarSenha é obrigatório")
                .Equal(x => x.Senha)
                    .WithMessage("As senhas não conferem");
        }
    }
}
