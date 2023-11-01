using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core.Domain;
using Core.Interfaces.Helpers;
using Core.Interfaces.Services;
using Core.ViewModels.Users;
using Core.ViewModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        readonly IUserService _userService;
        readonly IPasswordHasher _passwordHasher;
        readonly IAuthenticationTokenService _authenticationTokenService;

        public UsersController(IUserService userService, IPasswordHasher passwordHasher, IAuthenticationTokenService authenticationTokenService)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _authenticationTokenService = authenticationTokenService;
        }

        [AllowAnonymous]
        [HttpGet("GetUsers")]
        public IActionResult GetUsers()
        {
            try
            {                
                return Ok(_userService.GetAll().ToList());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Register model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestWithModelState();
                }

                if (model.Password != model.ConfirmPassword)
                {
                    return BadRequest(new ErrorResponse("Password doesnot match."));
                }

                var existingUser = _userService.GetByUserName(model.UserName);

                if (existingUser != null)
                {
                    return Conflict(new ErrorResponse("Username already exists."));
                }

                //existingUser = _userService.GetByEmail(model.Email);

                //if (existingUser != null)
                //{
                //    return Conflict(new ErrorResponse("Email already exists."));
                //}

                //existingUser = _userService.GetByPhone(model.Phone);

                //if (existingUser != null)
                //{
                //    return Conflict(new ErrorResponse("Phone already exists."));
                //}

                string hashedPassword = _passwordHasher.HashPassword(model.Password);

                int userId = _userService.Add(new User
                {
                    UserName = model.UserName,
                    //Email = model.Email,
                    //Phone = model.Phone,
                    Password = hashedPassword,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    SecondName = model.SecondName
                });

                return Ok(userId);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred in registration");
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] Login model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestWithModelState();
                }

                var user = _userService.GetByUserName(model.UserName);

                if (user == null || !_passwordHasher.VerifyPassword(model.Password, user.Password))
                {
                    return Unauthorized();
                }

                return Ok(_authenticationTokenService.AuthenticateUser(user));
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred in generating the token");
            }
        }

        [AllowAnonymous]
        [HttpGet("RefreshToken")]
        public IActionResult RefreshToken(string refreshToken /*[FromBody] VerifyRefreshToken model*/)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequestWithModelState();
                }

                bool isValidRefresh = _authenticationTokenService.ValidateRefreshToken(refreshToken);

                if (!isValidRefresh)
                {
                    return BadRequest(new ErrorResponse("Invalid refresh token."));
                }

                AuthenticationToken token = _authenticationTokenService.GetByRefreshToken(refreshToken);

                if (token == null)
                {
                    return BadRequest(new ErrorResponse("Invalid refresh token."));
                }

                _authenticationTokenService.Delete(token.Id);

                User user = _userService.GetByID(token.UserId);

                if (user == null)
                {
                    return BadRequest(new ErrorResponse("Invalid user."));
                }

                return Ok(_authenticationTokenService.AuthenticateUser(user));
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred in generating the token");
            }
        }

        [HttpDelete("Logout")]
        public IActionResult Logout()
        {
            try
            {
                if (UserId == 0)
                {
                    return Unauthorized();
                }

                _authenticationTokenService.Delete(tkn => tkn.UserId == UserId);

                HttpContext.Session.Clear();

                Response.Headers.Remove("Authorization");

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred in generating the token");
            }
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            try
            {
                //string id = HttpContext.User.FindFirstValue("Id");
                //string email = HttpContext.User.FindFirstValue("email");
                //string userName = HttpContext.User.FindFirstValue("UserName");
                //string name = HttpContext.User.FindFirstValue("Name");

                return Ok(UserId);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private IActionResult BadRequestWithModelState()
        {
            return BadRequest(ModelState.Values.SelectMany(val => val.Errors.Select(err => err.ErrorMessage)));
        }
    }
}