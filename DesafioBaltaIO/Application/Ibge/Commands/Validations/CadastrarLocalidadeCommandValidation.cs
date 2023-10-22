using FluentValidation;

namespace DesafioBaltaIO.Application.Ibge.Commands.Validations
{
    public class CadastrarLocalidadeCommandValidation : AbstractValidator<CadastrarLocalidadeCommand>
    {
        public CadastrarLocalidadeCommandValidation()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O codigo da localidade nao pode ser vazio")
                .NotNull().WithMessage("O codigo da localidade nao pode ser nullo");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("O estado da localidade nao pode ser vazio")
                .NotNull().WithMessage("O estado da localidade nao pode ser nullo");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("A cidade da localidade nao pode ser vazia")
                .NotNull().WithMessage("A cidade da localidade nao pode ser nulla");
        }
    }
}
