using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;
using Server.Domain.Interfaces;
using System.Linq;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAdminService adminService;

        public AdminController(
            UserManager<User> _userManager,
            RoleManager<IdentityRole> _roleManager,
            IAdminService _adminService)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            adminService = _adminService;
        }

        [AllowAnonymous]
        [HttpGet("AdminUsers")]
        public async Task<IEnumerable<User>> AdminUsers()
        {
            return await adminService.GetAllUsers();
        }

        //[HttpPost("Add")]
        //public async Task<IActionResult> Add()
        //{
        //    //TODo
        //}

        //[HttpPost("Remove")]
        //public async Task<IActionResult> Remove()
        //{
        //    //TODO
        //}
    }
}
