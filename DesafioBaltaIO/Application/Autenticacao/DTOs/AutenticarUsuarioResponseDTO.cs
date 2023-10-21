using FluentValidation.Results;

namespace DesafioBaltaIO.Application.Autenticacao.DTOs
{
    public class AutenticarUsuarioResponseDTO
    {
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();
        public LoginResponseDTO AutenticacaoResponse { get; set; }
    }
}
