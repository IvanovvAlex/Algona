using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Server.Common.Requests.AuthRequests;
using Server.Data.Entites;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AuthController(
          UserManager<User> _userManager,
          SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        [HttpPost]
        public async Task Register(CreateRegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new NotImplementedException();
            }

            var user = new User()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                await signInManager.PasswordSignInAsync(user, request.Password, false, false);
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        [HttpPost]
        public async Task Login(CreateLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                throw new NotImplementedException();
            }

            var user = await userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                ModelState.AddModelError("", "Wrong user!");
                throw new NotImplementedException();
            }

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, request.Password, false, false);

                if (result.Succeeded)
                {
                    throw new NotImplementedException();

                  //TODO
                }
            }

            ModelState.AddModelError("", "Invalid login!");
        }
    }
}
