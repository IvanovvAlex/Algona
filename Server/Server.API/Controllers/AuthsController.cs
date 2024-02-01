using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Server.Common.Requests.AuthRequests;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;
using Server.Domain.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using static Server.Common.Constants.GlobalConstants;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration config;
        private readonly IUserRepository userRepository;
        private readonly ISharedService sharedService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_userManager"></param>
        /// <param name="_signInManager"></param> 
        /// <param name="_config"></param> 
        /// <param name="_userRepository"></param> 
        public AuthsController(
          UserManager<User> _userManager,
          SignInManager<User> _signInManager,
          IConfiguration _config,
          IUserRepository _userRepository,
          ISharedService _sharedService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            config = _config;
            userRepository = _userRepository;
            sharedService = _sharedService;
        }


        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] CreateLoginRequest userLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(403, new { message = "Not correct data!" });
                }

                var user = await userManager.FindByEmailAsync(userLogin.Email);

                if (user == null)
                {
                    return StatusCode(401, new { message = "Wrong email or password!" });
                }

                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLogin.Password, false, false);

                    if (result.Succeeded)
                    {
                        var token = GenerateToken(userLogin);
                        this.HttpContext.Response.Cookies.Append("token", $"{token}", new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true
                        });

                        return StatusCode(200, new
                        {
                            firstName = user.FirstName,
                            lastName = user.LastName,
                            email = user.Email,
                            isAdmin = User.IsInRole(AdminRole),
                            token = token.ToString()
                        });
                    }
                }

                return StatusCode(401, new { message = "Wrong email or password!" });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error.Message });
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
                    return StatusCode(403, new { message = "Not correct data!" });
                }

                var users = await userRepository.GetAllAsync();
                var findUser = users.FirstOrDefault(x => x.Email == userRegister.Email);

                if (findUser != null)
                {
                    return StatusCode(409, new { message = "Email is already in use!" });
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
                    await userManager.AddToRoleAsync(user, ClientRole);
                    await signInManager.PasswordSignInAsync(user, userRegister.Password, false, false);
                    var token = GenerateToken(new CreateLoginRequest { Email = userRegister.Email, Password = userRegister.Password });
                    this.HttpContext.Response.Cookies.Append("token", $"{token}", new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true
                    });
                    return StatusCode(200, new
                    {
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        email = user.Email,
                        token = token.ToString()
                    });
                }
                return StatusCode(401, new { message = "Wrong input data!" });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error.Message });
            }
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(403, new { message = "Not correct data!" });
                }

                var user = await userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return StatusCode(404, new { message = "User with such email does not exist" });
                }

                var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);
                user.ResetPasswordToken = resetToken;
                user.ResetPasswordTokenExpiration = DateTime.UtcNow.AddDays(1);

                var updateResult = await userManager.UpdateAsync(user);
                if (updateResult.Succeeded)
                {
                    await this.sharedService.SendResetPasswordEmail(email, resetToken);
                    return StatusCode(200, new { message = "Password reset email sent" });
                }
                else
                {
                    return StatusCode(400, new { message = "There was an error. Try again." });
                }
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error.Message });
            }
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(403, new { message = "Not correct data!" });
                }

                var user = await userRepository.GetAsync(u => u.ResetPasswordToken == request.Token);

                if (user == null || user.ResetPasswordTokenExpiration < DateTime.UtcNow)
                {
                    return StatusCode(404, new { message = "Invalid or expired token." });
                }

                var resetPasswordResult = await userManager.ResetPasswordAsync(user, request.Token, request.Password);

                if (resetPasswordResult.Succeeded)
                {
                    user.ResetPasswordToken = null;
                    user.ResetPasswordTokenExpiration = null;

                    await userManager.UpdateAsync(user);

                    return StatusCode(200, new { message = "Password reset successfully" });
                }
                else
                {
                    return StatusCode(400, new { message = "There was an error. Try again." });
                }

            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error.Message });
            }

        }

        [HttpGet("User")]
        public async Task<IActionResult> GetUserWithValidToken()
        {
            try
            {
                var hasCredentials = HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);

                if (!hasCredentials)
                {
                    return StatusCode(401, new { message = "Unauthorized Request!" });
                }

                var returnedEmail = this.ValidateToken(token);
                if (returnedEmail == null)
                {
                    return StatusCode(401, new { message = "Unauthorized Request!" });
                }

                var users = await userRepository.GetAllAsync();
                var findUser = users.FirstOrDefault(x => x.Email == returnedEmail);
                if (findUser == null)
                {
                    return StatusCode(401, new { message = "Unauthorized Request!" });
                }

                return StatusCode(200, new { findUser.FirstName, findUser.LastName, findUser.Email, isAdmin = User.IsInRole(AdminRole), token });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error.Message });
            }
        }

        /// <summary>
        /// Logs the user out only if the user has credentials (in other words the user is currently logged in).
        /// If so deletes authentication cookie attached to the response on Login/Register.
        /// </summary>
        /// <returns></returns>
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                var hasCredentials = HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
                if (!hasCredentials)
                {
                    return StatusCode(401, new { message = "Unauthorized Request!" });
                }
                if (token == "")
                {
                    return StatusCode(401, new { message = "Invalid Credentials!" });
                }

                var jwt = new JwtSecurityTokenHandler();
                var readToken = jwt.ReadJwtToken(token);
                if (readToken != null)
                {
                    HttpContext.Response.Cookies.Delete("token", new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true
                    });

                    return StatusCode(200, new { message = "Logged out!" });
                }
                return StatusCode(401, new { message = "Unauthorized Request!" });
            }
            catch (Exception error)
            {
                return StatusCode(500, new { message = error.Message });
            }
        }

        /// <summary>
        /// Generates a JWT (JSON Web Token) for a user based on their login credentials. The token includes a single claim, which is the user's email. The issuer and audience for the token are also retrieved from the application's configuration. The token is set to expire in 30 minutes. This method returns the serialized form of the JWT.
        /// </summary>
        /// <param name="user">The user's login credentials, primarily used here for the user's email.</param>
        /// <returns>A string representing the serialized JWT.</returns>
        private string GenerateToken(CreateLoginRequest user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.Email)
            };
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Validates JWT. If JWT is valid returns user email via JWT's claims, otherwise returns null
        /// </summary>
        /// <param name="token"></param>
        /// <returns>email(<see langword="string"/>) or null</returns>
        private string? ValidateToken(string token)
        {
            if (token == null || token == "")
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var key = Encoding.UTF8.GetBytes(config["Jwt:Key"]);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var email = jwtToken.Claims.Single(c => c.Type == ClaimTypes.Name).Value;

                return email;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
