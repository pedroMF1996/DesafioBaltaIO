using DesafioBaltaIO.Application.Autenticacao.Commands.Abstract;
using DesafioBaltaIO.Application.Autenticacao.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioBaltaIO.Application.Autenticacao.Commands
{
    public class AutenticacaoCommandHandler : CommandHandler,
                                              IRequestHandler<RegistrarUsuarioCommand, AutenticarUsuarioResponseDTO>,
                                              IRequestHandler<AutenticarUsuarioCommand, AutenticarUsuarioResponseDTO>
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;

        public AutenticacaoCommandHandler(SignInManager<IdentityUser> signInManager, 
                                          UserManager<IdentityUser> userManager, 
                                          IOptions<AppSettings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<AutenticarUsuarioResponseDTO> Handle(RegistrarUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                UpdateValidationResult(message.ValidationResult);
                return _response;
            }

            var user = new IdentityUser()
            {
                UserName = message.Email,
                Email = message.Email,
                EmailConfirmed = true,
            };

            var result = await _userManager.CreateAsync(user, message.Senha);

            if (!result.Succeeded)
            {
                AddError("Erro ao cadastrar o usuario");
                return _response;
            }

            await _userManager.AddClaimsAsync(user, SetIbgeClaims());

            SetLoginResponse(await GerarJWT(message.Email));
            return _response;
        }

        public async Task<AutenticarUsuarioResponseDTO> Handle(AutenticarUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                UpdateValidationResult(message.ValidationResult);
                return _response;
            }

            var result = await _signInManager.PasswordSignInAsync(message.Email, message.Senha, false, true);
            
            if (result.IsLockedOut)
            {
                AddError("Usuario temporariamente bloqueado por tentativas invalidas");
            }

            if (!result.Succeeded)
            {
                AddError("Usuario ou senha incorretos");
            }

            if (HasErrors()) return _response;

            SetLoginResponse(await GerarJWT(message.Email));
            return _response;
        }

        #region Metodos_Privados
        private async Task<LoginResponseDTO> GerarJWT(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var claims = await _userManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimsUsuarioAsync(user, claims);

            var encodedToken = CodificarToken(identityClaims);

            return ObterRespostaToken(encodedToken, user, claims);
        }

        private static long ToUnixEpochDate(DateTime utcNow)
        {
            return (long)Math.Round((utcNow.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }

        private List<Claim> SetIbgeClaims()
        {
            List<Claim> claims = new();
            
            claims.Add(new Claim("IBGE_Ler", "permitido"));
            claims.Add(new Claim("IBGE_Cadastrar", "permitido"));
            claims.Add(new Claim("IBGE_Atualizar", "permitido"));
            claims.Add(new Claim("IBGE_Remover", "permitido"));

            return claims;
        }

        private async Task<ClaimsIdentity> ObterClaimsUsuarioAsync(IdentityUser user, IList<Claim> claims)
        {
            var roles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString())); //quando vai espirar 
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)); //quando foi emitido

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            return new ClaimsIdentity(claims);
        }

        private string CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor()
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        private LoginResponseDTO ObterRespostaToken(string encodedToken, IdentityUser user, IEnumerable<Claim> claims)
        {
            return new LoginResponseDTO()
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenDTO()
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimDTO() { Type = c.Type, Value = c.Value })
                }
            };
        } 
        #endregion
    }
}
