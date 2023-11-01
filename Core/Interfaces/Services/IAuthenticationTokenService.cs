using Core.Domain;
using Core.ViewModels.Users;

namespace Core.Interfaces.Services
{
    public interface IAuthenticationTokenService : IBaseService<AuthenticationToken>
    {
        AuthenticationToken GetByRefreshToken(string refreshToken);
        public AuthenticationResponse AuthenticateUser(User user);
        public bool ValidateRefreshToken(string refreshToken);
    }
}
