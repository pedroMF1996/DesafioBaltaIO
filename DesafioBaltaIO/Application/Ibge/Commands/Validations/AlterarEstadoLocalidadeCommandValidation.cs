using FluentValidation;

namespace DesafioBaltaIO.Application.Ibge.Commands.Validations
{
    public class AlterarEstadoLocalidadeCommandValidation : AbstractValidator<AlterarEstadoLocalidadeCommand>
    {
        public AlterarEstadoLocalidadeCommandValidation()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O codigo da localidade a ser atualizada nao pode ser vazio")
                .NotNull().WithMessage("O codigo da localidade a ser atualizada nao pode ser nullo");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("O novo estado da localidade nao pode ser vazio")
                .NotNull().WithMessage("O novo estado da localidade nao pode ser nullo");
        }
    }
}
