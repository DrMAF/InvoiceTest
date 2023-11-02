using Microsoft.AspNetCore.Mvc;
using Core.ViewModels.Users;
using Core.Interfaces.Services;
using Core.Interfaces.Helpers;

namespace MVCFrontend.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        readonly IUserService _userService;
        readonly IPasswordHasher _passwordHasher;
        readonly IAuthenticationTokenService _authenticationTokenService;

        public UsersController(ILogger<HomeController> logger, IUserService userService, 
        IPasswordHasher passwordHasher, IAuthenticationTokenService authenticationTokenService)
        {
            _logger = logger;
            _userService = userService;
            _passwordHasher = passwordHasher;
            _authenticationTokenService = authenticationTokenService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            var user = _userService.GetByUserName(model.UserName);

            string hashed = _passwordHasher.HashPassword(model.Password);

            if (user == null || !_passwordHasher.VerifyPassword(model.Password, hashed))
            {
                return Unauthorized();
            }

            _authenticationTokenService.AuthenticateUser(user);

            return Redirect("~/");
        }

    }
}
