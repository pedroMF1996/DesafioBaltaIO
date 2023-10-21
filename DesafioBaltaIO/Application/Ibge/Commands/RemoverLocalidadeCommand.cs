using DesafioBaltaIO.Application.Ibge.Commands.Validations;
using NetDevPack.Messaging;

namespace DesafioBaltaIO.Application.Ibge.Commands
{
    public class RemoverLocalidadeCommand : Command
    {
        public string Codigo { get; set; }

        protected RemoverLocalidadeCommand()
        { }

        public RemoverLocalidadeCommand(string codigo)
        {
            Codigo = codigo;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverLocalidadeCommandValidation().Validate(this);
            return base.IsValid();
        }
    }
}