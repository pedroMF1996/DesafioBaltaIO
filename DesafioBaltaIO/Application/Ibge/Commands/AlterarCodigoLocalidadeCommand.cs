using DesafioBaltaIO.Application.Ibge.Commands.Validations;
using NetDevPack.Messaging;

namespace DesafioBaltaIO.Application.Ibge.Commands
{
    public class AlterarCodigoLocalidadeCommand : Command
    {
        public string CodigoAtual { get; set; }
        public string CodigoNovo { get; set; }

        protected AlterarCodigoLocalidadeCommand()
        {}

        public AlterarCodigoLocalidadeCommand(string codigoAtual, string codigoNovo)
        {
            CodigoAtual = codigoAtual;
            CodigoNovo = codigoNovo;
        }

        public override bool IsValid()
        {
            ValidationResult = new AlterarCodigoLocalidadeCommandValidation().Validate(this);
            return base.IsValid();
        }
    }
}
