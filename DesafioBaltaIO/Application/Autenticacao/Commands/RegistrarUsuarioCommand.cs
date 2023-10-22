using DesafioBaltaIO.Application.Autenticacao.Commands.Abstract;
using DesafioBaltaIO.Application.Autenticacao.Commands.Validations;


namespace DesafioBaltaIO.Application.Autenticacao.Commands
{
    public class RegistrarUsuarioCommand : Command
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }

        protected RegistrarUsuarioCommand()
        { }

        public RegistrarUsuarioCommand(string email, string senha, string confirmarSenha)
        {
            Email = email;
            Senha = senha;
            ConfirmarSenha = confirmarSenha;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegistrarUsuarioCommandValidation().Validate(this);
            return base.IsValid();
        }
    }
}
