using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Core.Configurations;
using Core.Domain;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.ViewModels.Users;

namespace BLL.Services
{
    public class AuthenticationTokenService : BaseService<AuthenticationToken>, IAuthenticationTokenService
    {
        readonly IBaseRepository<AuthenticationToken> _repository;
        readonly AuthSettings _settings;

        public AuthenticationTokenService(IBaseRepository<AuthenticationToken> repository, IOptions<AuthSettings> settings) : base(repository)
        {
            _repository = repository;
            _settings = settings.Value;
        }

        public AuthenticationToken GetByRefreshToken(string refreshToken)
        {
            return _repository.GetAll(null).FirstOrDefault(tkn => tkn.RefreshToken == refreshToken);
        }

        public AuthenticationResponse AuthenticateUser(User user)
        {
            Delete(tkn => tkn.UserId == user.Id);

            List<Claim> Claims = new List<Claim>()
                                    {
                                        new Claim("Id", user.Id.ToString()),
                                        new Claim("UserName", user.UserName),
                                        new Claim("Name",  $"{user.FirstName} {user.LastName}"),
                                        new Claim("Email", user.Email)
            };

            string accessToken = GenerateAccessToken(_settings.Issuer, _settings.Audience, _settings.TokenSecret, _settings.TokenExpirationMunites, Claims);
            string refreshToken = RefreshToken();

            Add(new AuthenticationToken
            {
                UserId = user.Id,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });

            return new AuthenticationResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                Roles = new List<string> {"admin", "editor" }
            };
        }

        private string GenerateAccessToken(string issuer, string audience, string tokenSecret, double expirationMin, List<Claim> Claims = null)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSecret));
            SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer,
                audience,
                Claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(expirationMin),
            signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string RefreshToken()
        {
            return GenerateAccessToken(_settings.Issuer, _settings.Audience, _settings.RefreshedTokenSecret, _settings.RefreshedTokenExpirationMunites, null);
        }

        public bool ValidateRefreshToken(string refreshToken)
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.RefreshedTokenSecret)),
                // ValidIssuer = _config.Issuer,
                //  ValidAudience = _config.Audience,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.Zero
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                jwtSecurityTokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out var securityToken);
                return true;
            }
            catch (Exception ex)
            {
                //ex.LogError();
                return false;
            }
        }
    }
}
