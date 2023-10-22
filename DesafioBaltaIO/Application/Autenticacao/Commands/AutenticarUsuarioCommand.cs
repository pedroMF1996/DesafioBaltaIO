using DesafioBaltaIO.Application.Autenticacao.Commands.Abstract;
using DesafioBaltaIO.Application.Autenticacao.Commands.Validations;


namespace DesafioBaltaIO.Application.Autenticacao.Commands
{
    public class AutenticarUsuarioCommand : Command
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        protected AutenticarUsuarioCommand()
        { }

        public AutenticarUsuarioCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public override bool IsValid()
        {
            ValidationResult = new AutenticarUsuarioCommandValidation().Validate(this);
            return base.IsValid();
        }
    }
}
