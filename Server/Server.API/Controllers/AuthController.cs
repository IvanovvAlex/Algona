using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Server.Common.Requests.AuthRequests;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration config;
        private readonly IUserRepository userRepository;

        public AuthController(
          UserManager<User> _userManager,
          SignInManager<User> _signInManager,
          IConfiguration _config,
          IUserRepository _userRepository)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            config = _config;
            userRepository = _userRepository;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] CreateLoginRequest userLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(403, "Not correct data");
                }

                var user = await userManager.FindByEmailAsync(userLogin.Email);

                if (user == null)
                {
                    return StatusCode(401, "Wrong email or password");
                }

                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLogin.Password, false, false);

                    if (result.Succeeded)
                    {
                        var token = GenerateToken(userLogin);
                        this.HttpContext.Response.Cookies.Append($"{user.Id}", $"{token}", new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true
                        });
                        return StatusCode(200, $"{token}");
                    }
                }

                return StatusCode(401, "Wrong email or password");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateRegisterRequest userRegister)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(403, "Not correct data");
                }

                var users = await userRepository.GetAllAsync();
                var findUser = users.FirstOrDefault(x => x.Email == userRegister.Email);

                if (findUser != null)
                {
                    return StatusCode(409, "Email is already in use");
                }

                var user = new User()
                {
                    FirstName = userRegister.FirstName,
                    LastName = userRegister.LastName,
                    Email = userRegister.Email,
                    UserName = userRegister.Email
                };

                var result = await userManager.CreateAsync(user, userRegister.Password);

                if (result.Succeeded)
                {
                    await signInManager.PasswordSignInAsync(user, userRegister.Password, false, false);
                    var token = GenerateToken(new CreateLoginRequest { Email = userRegister.Email, Password = userRegister.Password });
                    this.HttpContext.Response.Cookies.Append($"{user.Id}", $"{token}", new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true
                    });
                    return StatusCode(200, $"{token}");
                }
                return StatusCode(401, "Wrong input data");
            }
            catch (Exception)
            {
                throw;
            }

        }

        private string GenerateToken(CreateLoginRequest user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Email),
                //new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
