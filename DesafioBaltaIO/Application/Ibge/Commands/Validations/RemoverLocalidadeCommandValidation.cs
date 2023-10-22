using FluentValidation;

namespace DesafioBaltaIO.Application.Ibge.Commands.Validations
{
    public class RemoverLocalidadeCommandValidation : AbstractValidator<RemoverLocalidadeCommand>
    {
        public RemoverLocalidadeCommandValidation()
        {
            RuleFor(x => x.Codigo)
                .NotEmpty().WithMessage("O codigo da localidade a ser removida nao pode ser vazio")
                .NotNull().WithMessage("O codigo da localidade a ser removida nao pode ser nullo");
        }
    }
}