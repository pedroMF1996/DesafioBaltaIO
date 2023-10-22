using DesafioBaltaIO.Application.Ibge.Commands.Validations;
using NetDevPack.Messaging;
using System.Text.Json.Serialization;

namespace DesafioBaltaIO.Application.Ibge.Commands
{
    public class AlterarCidadeLocalidadeCommand : Command
    {
        public string Codigo { get; set; }
        public string Cidade { get; set; }

        [JsonIgnore]
        public DateTime DataEdicao { get; set; }
        protected AlterarCidadeLocalidadeCommand()
        { }

        public AlterarCidadeLocalidadeCommand(string codigo, string cidade)
        {
            Codigo = codigo;
            Cidade = cidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new AlterarCidadeLocalidadeCommandValidation().Validate(this);
            return base.IsValid();
        }
    }
}
