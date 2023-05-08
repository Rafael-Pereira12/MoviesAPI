using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Responses;

namespace MoviesAPI.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole<long>> _roleManager;
        public RoleController(RoleManager<IdentityRole<long>> roleManager)
        {
            _roleManager = roleManager;
        }
        
        [HttpPost]
        [Route("createRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var roleExists = await _roleManager.FindByNameAsync(roleName);
            if (roleExists != null) return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = "Role is already taken" });

            IdentityRole<long> role = new()
            {
                Name = roleName
            };

            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded) return StatusCode(StatusCodes.Status500InternalServerError, new AuthResponse { Status = "Error", Message = "It was not possible to create the role" });

            return Ok(new AuthResponse { Status = "Success", Message = "Role created successfully" });
        }
    }
}
