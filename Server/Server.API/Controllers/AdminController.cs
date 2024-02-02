using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Server.Data.Entites;
using Server.Data.Interfaces.Repositories;
using Server.Domain.Interfaces;
using System.Linq;
using Type = Server.Core.Enums.Type;
using static Server.Common.Constants.GlobalConstants;
using System.Data;

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

        [Authorize(Roles = AdminRole)]
        [HttpGet("AdminUsers")]
        public async Task<IEnumerable<User>> AdminUsers()
        {
           IEnumerable<User> users = await adminService.GetAllUsers();

            return users.Where(u => u.Type == Type.Admin)
                .ToList();               
        }

        [Authorize(Roles = AdminRole)]
        [HttpGet("NonAdminUsers")]
        public async Task<IEnumerable<User>> NonAdminUsers()
        {
            IEnumerable<User> users = await adminService.GetAllUsers();

            return users.Where(u => u.Type != Type.Admin)
                .ToList();
        }

        [Authorize(Roles = AdminRole)]
        [HttpGet("AllUsers")]
        public async Task<IEnumerable<User>> AllUsers()
        {
            return await adminService.GetAllUsers();
        }

        [Authorize(Roles = AdminRole)]
        [HttpPost("Add")]
        public async Task<IActionResult> Add(string userId)
        {
            try
            {
                await this.adminService.MakeAdminAsync(userId);

                return Ok(new { message = $"User with ID '{userId}' is now an administrator." });
            }
            catch (InvalidOperationException ioe)
            {
                return BadRequest(ioe.Message);
            }
        }

        [Authorize(Roles = AdminRole)]
        [HttpPost("Remove")]
        public async Task<IActionResult> Remove(string userId)
        {
            try
            {
                await this.adminService.RemoveFromAdminAsync(userId);

                return Ok(new { message = $"User with ID '{userId}' is no longer an administrator." });
            }
            catch (InvalidOperationException ioe)
            {
                return BadRequest(ioe.Message);
            }
        }
    }
}
