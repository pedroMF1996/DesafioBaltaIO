using DesafioBaltaIO.Application.Ibge.Commands.Validations;
using NetDevPack.Messaging;
using System.Text.Json.Serialization;

namespace DesafioBaltaIO.Application.Ibge.Commands
{
    public class AlterarEstadoLocalidadeCommand : Command
    {
        public string Codigo { get; set; }
        public string Estado { get; set; }

        [JsonIgnore]
        public DateTime DataEdicao { get; set; }

        protected AlterarEstadoLocalidadeCommand()
        { }

        public AlterarEstadoLocalidadeCommand(string codigo, string estado)
        {
            Codigo = codigo;
            Estado = estado;
        }

        public override bool IsValid()
        {
            ValidationResult = new AlterarEstadoLocalidadeCommandValidation().Validate(this);
            return base.IsValid();
        }
    }
}
