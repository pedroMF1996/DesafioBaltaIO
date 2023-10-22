using FluentValidation;

namespace DesafioBaltaIO.Application.Ibge.Commands.Validations
{
    public class AlterarCodigoLocalidadeCommandValidation : AbstractValidator<AlterarCodigoLocalidadeCommand>
    {
        public AlterarCodigoLocalidadeCommandValidation()
        {
            RuleFor(x => x.CodigoAtual)
                .NotEmpty().WithMessage("O codigo atual da localidade a ser atualizada nao pode ser vazio")
                .NotNull().WithMessage("O codigo atual da localidade a ser atualizada nao pode ser nullo");

            RuleFor(x => x.CodigoNovo)
                .NotEmpty().WithMessage("O codigo novo da localidade a ser atualizada nao pode ser vazio")
                .NotNull().WithMessage("O codigo novo da localidade a ser atualizada nao pode ser nullo")
                .NotEqual(x => x.CodigoAtual).WithMessage("O codigo novo da localidade a ser atualizada nao pode ser igual ao antigo");
        }
    }
}
