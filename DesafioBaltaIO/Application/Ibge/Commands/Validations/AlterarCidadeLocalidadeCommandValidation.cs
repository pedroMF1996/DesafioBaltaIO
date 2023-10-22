using FluentValidation;

namespace DesafioBaltaIO.Application.Ibge.Commands.Validations
{
    public class AlterarCidadeLocalidadeCommandValidation : AbstractValidator<AlterarCidadeLocalidadeCommand>
    {
        public AlterarCidadeLocalidadeCommandValidation()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O codigo da localidade a ser atualizada nao pode ser vazio")
                .NotNull().WithMessage("O codigo da localidade a ser atualizada nao pode ser nullo");

            RuleFor(x => x.Cidade)
                .NotEmpty().WithMessage("A nova cidade da localidade nao pode ser vazia")
                .NotNull().WithMessage("A nova cidade da localidade nao pode ser nulla");
        }
    }
}
